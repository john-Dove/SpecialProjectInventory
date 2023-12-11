using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Windows.Forms;
using static SpecialProjectInventory.ProjectUtility;

namespace SpecialProjectInventory
{

    public class AlertManager
    {
    
        private readonly string _connectionString;

      
        public AlertManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public class AlertLogEntry
        {

            public int LogID { get; set; }
            public int AlertID { get; set; }
            public DateTime TriggeredOn { get; set; }
            public string Message { get; set; }
            public bool IsResolved { get; set; }
            public int ProductID { get; set; }
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

       
        public void LogAlert(string message, int alertID, int productID)
        {
            if (alertID == -1)
            {
                Logger.LogMessage("No valid alertID found for the given alert type, not logging alert.", nameof(LogAlert));
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

                        // Inserts the alert log with productID
                        Logger.LogMessage($"Logging Alert: {message} for AlertID: {alertID}, ProductID: {productID}", nameof(LogAlert));
                        var logCommand = new SqlCommand("INSERT INTO tbAlertLog (alertID, TriggeredOn, Message, IsResolved, productID) VALUES (@alertID, @triggeredOn, @message, @isResolved, @productID)", connection, transaction);
                        logCommand.Parameters.AddWithValue("@alertID", alertID);
                        logCommand.Parameters.AddWithValue("@triggeredOn", DateTime.Now);
                        logCommand.Parameters.AddWithValue("@message", message);
                        logCommand.Parameters.AddWithValue("@isResolved", false);
                        logCommand.Parameters.AddWithValue("@productID", productID);
                        logCommand.ExecuteNonQuery();

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
                        catch (Exception rollbackEx)
                        {
                            // Logs the rollback exception if it fails, 
                            Logger.LogException(rollbackEx, nameof(LogAlert) + " - Rollback");
                        }

                        // Logs the original exception
                        Logger.LogException(ex, nameof(LogAlert));
                    }

                }
            }
        }
       
        public void ResolveAlert(int logID, int productID)
        {
            // Retrieves the expiry date for the product
            DateTime? expiryDate = GetProductExpiryDate(productID);

            // Retrieves the threshold for the product
            int threshold = GetProductThreshold(productID);

            // Checks if the product's quantity is above the threshold and the expiry date is valid and in the future
            if (CanResolveAlert(productID, threshold) && expiryDate.HasValue && expiryDate.Value > DateTime.Now)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var command = new SqlCommand("UPDATE tbAlertLog SET IsResolved = 1 WHERE logID = @LogID", connection);
                    command.Parameters.AddWithValue("@LogID", logID);
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Alert resolved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // If the stock is still below the threshold or the expiry date is not updated, display a warning
                MessageBox.Show("Alert cannot be resolved as the stock is still below the threshold or the expiry date is not updated.", "Alert Not Resolved", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

  
        public DateTime? GetProductExpiryDate(int productID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT expiredatee FROM tbProduct WHERE pid = @productID", connection);
                command.Parameters.AddWithValue("@productID", productID);

                connection.Open();
                var result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToDateTime(result);
                }
                else
                {
                    return null;
                }
            }
        }

 
        public int GetProductThreshold(int productID)
        {
            int threshold = default;
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var command = new SqlCommand("SELECT LowStockThreshold FROM tbProduct WHERE pid = @productID", connection);
                    command.Parameters.AddWithValue("@productID", productID);

                    connection.Open();
                    var result = command.ExecuteScalar();

                    if (result != DBNull.Value && result != null)
                    {
                        threshold = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                // Logs the exception 
                Logger.LogException(ex, nameof(GetProductThreshold));
            }

            return threshold;
        }

        public List<Product> GetAllProductsWithLowStockThreshold(DateTime lastCheckedTime)
        {
            var productsWithLowStock = new List<Product>();

            try
            {
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
                            // Uses a default value for lowstockthreshold if it's NULL
                            int defaultLowStockThreshold = 0;

                            var product = new Product
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("pid")),
                                Name = reader.GetString(reader.GetOrdinal("pname")),
                                Quantity = reader.GetInt32(reader.GetOrdinal("pqty")),
                                Price = reader.GetDecimal(reader.GetOrdinal("pprice")),
                                Description = reader.IsDBNull(reader.GetOrdinal("pdescription")) ? null : reader.GetString(reader.GetOrdinal("pdescription")),
                                Category = reader.GetString(reader.GetOrdinal("pcategory")),
                                LowStockThreshold = reader.IsDBNull(reader.GetOrdinal("lowstockthreshold")) ? defaultLowStockThreshold : reader.GetInt32(reader.GetOrdinal("lowstockthreshold"))
                            };
                            productsWithLowStock.Add(product);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex, nameof(GetAllProductsWithLowStockThreshold));
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

        public bool CheckExpiringProductAlerts(DateTime lastCheckedTime)
        {
            bool newAlertsLogged = false; // Indicates if new alerts were logged

            try
            {
                int expiringAlertID = GetAlertID("Expiring-Product");
                int expiredAlertID = GetAlertID("Expired-Product");
                var expiringProducts = GetAllExpiringProducts(lastCheckedTime);


                foreach (var product in expiringProducts)
                {
                    
                    // Checks if the product's last checked time is before today to prevent duplicate alerts.
                    if (!product.LastCheckedOn.HasValue || product.LastCheckedOn.Value.Date < DateTime.Now.Date)
                    {
                        if (product.ExpirationDate.HasValue)
                        {
                            if (product.ExpirationDate.Value.Date == DateTime.Now.Date)
                            {
                                // If the product expires today
                                LogAlert($"Product expires today alert for {product.Name}. Expiration date: {product.ExpirationDate.Value.ToShortDateString()}.", expiringAlertID, product.Id);
                                newAlertsLogged = true;
                            }
                            else if (product.ExpirationDate.Value < DateTime.Now)
                            {
                                // If the product has already expired
                                LogAlert($"Expired product alert for {product.Name}. Expiration date: {product.ExpirationDate.Value.ToShortDateString()}.", expiredAlertID, product.Id);
                                newAlertsLogged = true;
                            }
                            else if (product.ExpirationDate.Value <= DateTime.Now.AddDays(3))
                            {
                                // If the product is expiring within the next 3 days
                                LogAlert($"Expiring product alert for {product.Name}. Expiration date: {product.ExpirationDate.Value.ToShortDateString()}.", expiringAlertID, product.Id);
                                newAlertsLogged = true;
                            }
                        }
                        else
                        {
                            Logger.LogMessage($"Product {product.Name} with ID {product.Id} has no expiration date set.", nameof(CheckExpiringProductAlerts));
                            
                        }
                    }
                    else
                    {
                        Logger.LogMessage($"Product {product.Name} with ID {product.Id} was already checked today.", nameof(CheckExpiringProductAlerts));
                    }

                    // Updates the last checked time regardless of whether an alert was logged to prevent duplicate alerts
                    UpdateProductLastCheckedTime(product.Id);
                }
            }
            catch (Exception ex)
            {
                // Logs the exception 
                Logger.LogException(ex, "Error in CheckExpiringProductAlerts");
                
            }

            return newAlertsLogged; // Returns true if any new alerts were logged
        }


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
                    Logger.LogMessage($"Retrieved AlertID: {alertID} for AlertType: {alertType}", nameof(GetAlertID));
                    return alertID;
                }
            }
            return -1; // Returns an invalid ID in case of error or if not found
        }

        
        public DateTime GetLastCheckedTime()
        {
            DateTime lastCheckedTime = new DateTime(1753, 1, 1);

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
                if (product.Quantity <= effectiveThreshold)
                {
                    int alertID = GetAlertID("Low-Stock");
                    if (alertID != -1)
                    {
                        string message = $"Low stock alert for product {product.Name}. Only {product.Quantity} left in stock.";
                        LogAlert(message, alertID, product.Id);
                    }
                    else
                    {
                        Logger.LogMessage("Invalid AlertID received, not logging alert.", nameof(CheckLowStockAlerts));
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
       

        public bool CanResolveAlert(int productID, int threshold)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT pqty FROM tbProduct WHERE pid = @productID", connection);
                command.Parameters.AddWithValue("@productID", productID);

                connection.Open();
                var result = command.ExecuteScalar();

                // Checks whether the result is null before converting to int
                if (result != DBNull.Value && result != null)
                {
                    int currentQuantity = Convert.ToInt32(result);
                    return currentQuantity > threshold;
                }
                else
                {
                    // Handles the case where no matching product was found or quantity is null

                    return false;
                }
            }
        }

        
        public List<AlertLogEntry> GetActiveAlerts()
        {
            var alerts = new List<AlertLogEntry>();

            using (var connection = new SqlConnection(_connectionString))
            {
                // Ensure the SQL query selects the ProductID column.
                var command = new SqlCommand("SELECT LogID, AlertID, TriggeredOn, Message, IsResolved, ProductID FROM tbAlertLog WHERE IsResolved = 0", connection);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var alert = new AlertLogEntry
                        {
                            LogID = Convert.ToInt32(reader["LogID"]),
                            AlertID = Convert.ToInt32(reader["AlertID"]),
                            TriggeredOn = Convert.ToDateTime(reader["TriggeredOn"]),
                            Message = reader["Message"].ToString(),
                            IsResolved = Convert.ToBoolean(reader["IsResolved"]),
                            ProductID = Convert.ToInt32(reader["ProductID"]) // Now retrieving ProductID
                        };
                        alerts.Add(alert);
                    }
                }
            }

            return alerts;
        }

        private List<Product> GetAllExpiringProducts(DateTime thresholdDate)
        {
            var expiringProducts = new List<Product>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var command = new SqlCommand("SELECT pid, pname, pqty, pprice, pdescription, pcategory, lowstockthreshold, expiredatee, lastCheckedOn FROM tbProduct WHERE expiredatee IS NOT NULL AND expiredatee >= @ThresholdDate", connection);

                    // Ensure that the threshold date is within the SQL DateTime range.
                    if (thresholdDate < (DateTime)SqlDateTime.MinValue)
                    {
                        thresholdDate = (DateTime)SqlDateTime.MinValue;
                    }

                    // Uses the threshold date in the SQL query.
                    command.Parameters.AddWithValue("@ThresholdDate", thresholdDate);

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
                                LowStockThreshold = reader.GetInt32(reader.GetOrdinal("lowstockthreshold")),
                                ExpirationDate = reader.IsDBNull(reader.GetOrdinal("expiredatee")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("expiredatee")),
                                LastCheckedOn = reader.IsDBNull(reader.GetOrdinal("lastCheckedOn")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("lastCheckedOn"))
                            };

                            expiringProducts.Add(product);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex, nameof(GetAllExpiringProducts));
                MessageBox.Show("An error occurred. Please contact support.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
