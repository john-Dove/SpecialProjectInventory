using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using System.Data;
using System.IO;
using System.Linq;
using System.Data.SqlClient;
using System;

namespace SpecialProjectInventory
{
    public static class ProjectUtility
    {
        public static MaskedTextBox CreatePhoneNumberMaskedTextBox()
        {
            MaskedTextBox phoneMaskedTextBox = new MaskedTextBox
            {
                Mask = "(999) 000-0000",
                PromptChar = '_',
                ValidatingType = typeof(string)
            };
            return phoneMaskedTextBox;
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // This is a computeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Converts byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public static DataTable GetInventoryData()
        {
            DataTable dataTable = new DataTable();
            string connectionString = DatabaseConfig.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT orderid, odate, pid, cid, qty, price, total FROM tbOrder";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine(sqlEx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return dataTable;
        }

        public static void GenerateInventoryReport(DataTable inventoryData, string reportPath)
        {
            if (inventoryData == null || inventoryData.Rows.Count == 0)
            {
                throw new InvalidOperationException("No data available to generate the report.");
            }

            StringBuilder csvContent = new StringBuilder();

            // Column headers
            string[] columnNames = inventoryData.Columns.Cast<DataColumn>()
                                        .Select(column => "\"" + column.ColumnName.Replace("\"", "\"\"") + "\"").ToArray();
            csvContent.AppendLine(string.Join(",", columnNames));

            // Rows data
            foreach (DataRow row in inventoryData.Rows)
            {
                string[] fields = row.ItemArray.Select(field => "\"" + field.ToString().Replace("\"", "\"\"") + "\"").ToArray();
                csvContent.AppendLine(string.Join(",", fields));
            }

            // Summary data
            decimal totalSales = inventoryData.AsEnumerable().Sum(row => row.Field<decimal>("total"));
            int totalUnitsSold = inventoryData.AsEnumerable().Sum(row => row.Field<int>("qty"));

            // Adds a blank line before the summary for readability
            csvContent.AppendLine();
            csvContent.AppendLine("Summary");
            csvContent.AppendLine($"\"Total Sales\",\"{totalSales}\"");
            csvContent.AppendLine($"\"Total Units Sold\",\"{totalUnitsSold}\"");

            // Ensures directory exists
            string directoryPath = Path.GetDirectoryName(reportPath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Writes the CSV content to the file
            File.WriteAllText(reportPath, csvContent.ToString());
        }



    }
}
