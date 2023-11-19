using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SpecialProjectInventory
{
    public class AlertManager
    {

        private readonly string _connectionString;

        public AlertManager(string connectionString)
        {
            _connectionString = connectionString;
        }


        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public int LowStockThreshold { get; set; }
            public DateTime? ExpirationDate { get; set; }
            public DateTime? LastCheckedOn { get; set; }
        }
        public class Order
        {
            public int Id { get; set; }
            public DateTime OrderDate { get; set; }
            public DateTime DueDate { get; set; }
            public string Status { get; set; }
            public decimal TotalAmount { get; set; }

            // The identifier of the customer who placed the order
            public int CustomerId { get; set; }
            public string Details { get; set; }
        }

        public class ExpiringProduct
        {
            
            public int Id { get; set; }

            
            public string Name { get; set; }

           
            public int Quantity { get; set; }

            
            public DateTime ExpirationDate { get; set; }

          
            public string Details { get; set; }

           
            public bool AlertSent { get; set; }
        }

        public void LogAlert(string message, int alertID, int entityID)
        {
            if (alertID == -1)
            {
                MessageBox.Show("No valid alertID found for the given alert type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Starts a transaction to ensure both commands are executed together
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Inserts the alert log
                        var logCommand = new SqlCommand("INSERT INTO tbAlertLog (alertID, Message, TriggeredOn, IsResolved) VALUES (@alertID, @message, @triggeredOn, @isResolved)", connection, transaction);
                        logCommand.Parameters.AddWithValue("@alertID", alertID);
                        logCommand.Parameters.AddWithValue("@message", message);
                        logCommand.Parameters.AddWithValue("@triggeredOn", DateTime.Now);
                        logCommand.Parameters.AddWithValue("@isResolved", false);
                        logCommand.ExecuteNonQuery();

                        // Updates the LastCheckedOn field for the product

                        var updateCommand = new SqlCommand("UPDATE tbProduct SET LastCheckedOn = @LastCheckedOn WHERE pid = @entityID", connection, transaction);
                        updateCommand.Parameters.AddWithValue("@LastCheckedOn", DateTime.Now);
                        updateCommand.Parameters.AddWithValue("@entityID", entityID);
                        updateCommand.ExecuteNonQuery();

                        // Commits the transaction
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Attempts to roll back the transaction
                        try
                        {
                            transaction.Rollback();
                        }
                        catch (Exception exRollback)
                        {
                            MessageBox.Show("Error in LogAlert rollback: " + exRollback.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        MessageBox.Show("Error in LogAlert: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void ResolveAlert(int logID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("UPDATE tbAlertLog SET IsResolved = 1, LastCheckedOn = @Now WHERE logID = @LogID AND IsResolved = 0", connection);
                command.Parameters.AddWithValue("@Now", DateTime.Now);
                command.Parameters.AddWithValue("@LogID", logID);

                connection.Open();
                int affectedRows = command.ExecuteNonQuery();

                if (affectedRows == 0)
                {
                    // Handles the case where the alert was already resolved or the logID was not found
                    MessageBox.Show("Alert has already been resolved or not found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Alert resolved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }



        public List<Product> GetAllProductsWithLowStockThreshold(DateTime lastCheckedTime)
        {
            var productsWithLowStock = new List<Product>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(@"
            SELECT pid, pname, pqty, pprice, pdescription, pcategory, lowstockthreshold 
            FROM tbProduct 
            WHERE pqty <= lowstockthreshold AND 
            (lastCheckedOn IS NULL OR lastCheckedOn < @lastCheckedTime)", connection);

                SqlParameter lastCheckedParam = new SqlParameter("@lastCheckedTime", SqlDbType.DateTime)
                {
                    Value = (lastCheckedTime == DateTime.MinValue) ? (object)DBNull.Value : lastCheckedTime
                };
                command.Parameters.Add(lastCheckedParam);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Product
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("pid")),
                            Name = reader.GetString(reader.GetOrdinal("pname")),
                            Quantity = reader.GetInt32(reader.GetOrdinal("pqty")),
                            Price = reader.GetDecimal(reader.GetOrdinal("pprice")),
                            Description = reader.IsDBNull(reader.GetOrdinal("pdescription")) ? null : reader.GetString(reader.GetOrdinal("pdescription")),
                            Category = reader.GetString(reader.GetOrdinal("pcategory")),
                            LowStockThreshold = reader.GetInt32(reader.GetOrdinal("lowstockthreshold"))
                        };
                        productsWithLowStock.Add(product);
                    }
                }
            }

            return productsWithLowStock;
        }


        public void UpdateProductLastCheckedTime(int productId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("UPDATE tbProduct SET lastCheckedOn = @Now WHERE pid = @ProductId", connection);
                command.Parameters.AddWithValue("@Now", DateTime.Now);
                command.Parameters.AddWithValue("@ProductId", productId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void CheckExpiringProductAlerts(DateTime lastCheckedTime)
        {
            int alertID = GetAlertID("Expiring-Product");
            var expiringProducts = GetAllExpiringProducts(lastCheckedTime); 

            foreach (var product in expiringProducts)
            {
                // Checks whether the ExpirationDate has a value and if it's within the threshold period
                if (product.ExpirationDate.HasValue && product.ExpirationDate.Value <= DateTime.Now.AddDays(3))
                {

                    LogAlert($"Expiring product alert for {product.Name}. Expiration date: {product.ExpirationDate.Value.ToShortDateString()}.", alertID, product.Id);
                }
            }
        }

        // Method to check for pending orders
        public void CheckPendingOrdersAlerts(DateTime lastCheckedTime)
        {
            int alertID = GetAlertID("Pending-Order");
            var pendingOrders = GetAllPendingOrders(lastCheckedTime);

            foreach (var order in pendingOrders)
            {

                if (order.DueDate <= DateTime.Now)
                {
                    LogAlert($"Pending order alert for order ID {order.Id}. Order due on: {order.DueDate.ToShortDateString()}.", alertID, order.Id);
                }
            }
        }

        public int GetAlertID(string alertType)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT alertID FROM tbAlertSettings WHERE alertType = @alertType AND isEnabled = 1", connection);
                command.Parameters.AddWithValue("@alertType", alertType);

                connection.Open();
                var result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int alertID))
                {
                    return alertID;
                }
            }
            return -1; // Returns an invalid ID in case of error or if not found
        }

        public DateTime GetLastCheckedTime()
        {
            DateTime lastCheckedTime = new DateTime(1753, 1, 1);
            //DateTime lastCheckedTime = DateTime.MinValue;

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT MAX(LastCheckedOn) FROM tbAlertLog", connection);

                connection.Open();
                var result = command.ExecuteScalar();

                // Checks whether the result is not DBNull (if there are no records yet)
                if (result != DBNull.Value && result != null)
                {
                    lastCheckedTime = Convert.ToDateTime(result);
                }
            }

            return lastCheckedTime;
        }


        public void CheckLowStockAlerts(DateTime lastCheckedTime)
        {
            int defaultThreshold = GetDefaultThreshold("Low-Stock");
            var products = GetAllProductsWithLowStockThreshold(lastCheckedTime);
            
            foreach (var product in products)
            {
                int effectiveThreshold = product.LowStockThreshold > 0 ? product.LowStockThreshold : defaultThreshold;
                if(product.Quantity <= effectiveThreshold)
                {
                    int alertID = GetAlertID("Low-Stock");
                    if(alertID != -1)
                    {
                        LogAlert($"Low stock alert for product {product.Name}. Only {product.Quantity} left in stock.", alertID, product.Id);
                    }
                    
                }
                
            }
        }
        public bool IsAlertResolved(int logID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT IsResolved FROM tbAlertLog WHERE logID = @LogID", connection);
                command.Parameters.AddWithValue("@LogID", logID);

                connection.Open();
                var result = command.ExecuteScalar();

                return result != null && Convert.ToBoolean(result);
            }
        }

        public bool CanResolveAlert(int productID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT pqty, lowstockthreshold FROM tbProduct WHERE pid = @ProductID", connection);
                command.Parameters.AddWithValue("@ProductID", productID);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int currentQuantity = reader.GetInt32(reader.GetOrdinal("pqty"));
                        int threshold = reader.GetInt32(reader.GetOrdinal("lowstockthreshold"));
                        return currentQuantity > threshold;
                    }
                }
            }
            return false;
        }

        private List<Product> GetAllExpiringProducts(DateTime lastCheckedTime)
        {
            var expiringProducts = new List<Product>();

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT pid, pname, pqty, pprice, pdescription, pcategory, expiredate FROM tbProduct WHERE expiredate IS NOT NULL AND expiredate <= @ThresholdDate", connection);

                // Sets the threshold date, for example, 3 days from now
                command.Parameters.AddWithValue("@ThresholdDate", DateTime.Now.AddDays(3));

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Product
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("pid")),
                            Name = reader.GetString(reader.GetOrdinal("pname")),
                            Quantity = reader.GetInt32(reader.GetOrdinal("pqty")),
                            Price = reader.GetDecimal(reader.GetOrdinal("pprice")),
                            Description = reader.GetString(reader.GetOrdinal("pdescription")),
                            Category = reader.GetString(reader.GetOrdinal("pcategory")),
                            LowStockThreshold = reader.GetInt32(reader.GetOrdinal("lowstockthreshold")), 
                            ExpirationDate = reader.GetDateTime(reader.GetOrdinal("expiredate")),
                            LastCheckedOn = reader.GetDateTime(reader.GetOrdinal("lastCheckedOn"))
                        };

                        // Check if the ExpirationDate is not null before adding the product
                        if (product.ExpirationDate.HasValue)
                        {
                            expiringProducts.Add(product);
                        }
                    }
                }
            }

            return expiringProducts;
        }

        private List<Order> GetAllPendingOrders(DateTime lastCheckedTime)
        {
            var pendingOrders = new List<Order>();

            // Defines the SQL query to select orders that are pending.
            string query = @"SELECT Id, OrderDate, DueDate, Status, TotalAmount, CustomerId, Details 
            FROM tbOrder 
            WHERE DueDate <= @Today AND Status NOT IN ('Completed', 'Shipped')
            AND (LastCheckedOn IS NULL OR LastCheckedOn < @LastCheckedTime)";

            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LastCheckedTime", lastCheckedTime);

                // Adds a parameter to prevent SQL Injection
                command.Parameters.AddWithValue("@Today", DateTime.Now);


                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var order = new Order
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            OrderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate")),
                            DueDate = reader.GetDateTime(reader.GetOrdinal("DueDate")),
                            Status = reader.GetString(reader.GetOrdinal("Status")),
                            TotalAmount = reader.GetDecimal(reader.GetOrdinal("TotalAmount")),
                            CustomerId = reader.GetInt32(reader.GetOrdinal("CustomerId")),
                            Details = reader.IsDBNull(reader.GetOrdinal("Details")) ? null : reader.GetString(reader.GetOrdinal("Details")),

                        };
                        pendingOrders.Add(order);
                    }
                }
            }

            return pendingOrders;
        }

        private int GetDefaultThreshold(string alertType)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT threshold FROM tbAlertSettings WHERE alertType = @alertType", connection);
                command.Parameters.AddWithValue("@alertType", alertType);

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int threshold))
                {
                    return threshold;
                }
            }
            return 0; 
        }

        

    }
}
