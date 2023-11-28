using System;
using System.Data.SqlClient;

namespace SpecialProjectInventory
{
    public static class SalesUtility
    {
        public static void RecordSale(int productId, int quantitySold, decimal totalAmount, DateTime saleDate, int customerId)
        {
            string connectionString = SpecialProjectInventory.DatabaseConfig.ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                var query = "INSERT INTO tbSales (productId, quantitySold, totalAmount, saleDate, customerId) VALUES (@productId, @quantitySold, @totalAmount, @saleDate, @customerId)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@productId", productId);
                    command.Parameters.AddWithValue("@quantitySold", quantitySold);
                    command.Parameters.AddWithValue("@totalAmount", totalAmount);
                    command.Parameters.AddWithValue("@saleDate", saleDate);
                    command.Parameters.AddWithValue("@customerId", customerId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public static decimal GetTotalRevenue(DateTime startDate, DateTime endDate)
        {
            using (var connection = new SqlConnection(DatabaseConfig.ConnectionString))
            {
                var query = @"
                SELECT SUM(total) 
                FROM tbOrder 
                WHERE odate BETWEEN @startDate AND @endDate";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endDate", endDate);

                    connection.Open();
                    var result = command.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
            }
        }
    }
}
