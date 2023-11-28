using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SpecialProjectInventory
{
    public partial class ReportModule : Form
    {
        public ReportModule()
        {
            InitializeComponent();
        }

        private void ReportModule_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadCriteria();

        }

        private void LoadCriteria()
        {
            CmbCriteria.Items.Add("Perishable");
            CmbCriteria.Items.Add("Non-Perishable");
            CmbCriteria.Items.Add("Stock Below Threshold");
            CmbCriteria.Items.Add("Total Revenue");
        }


        private void LoadCategories()
        {
            string connectionString = SpecialProjectInventory.DatabaseConfig.ConnectionString;
            string query = "SELECT DISTINCT pcategory FROM tbProduct";

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CmbCategory.Items.Add(reader["pcategory"].ToString());
                        }
                    }
                }
            }
        }

        private void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            DateTime startDate = DtReportStart.Value.Date;
            DateTime endDate = DtReportEnd.Value.Date.AddDays(1).AddTicks(-1); 
            string selectedCategory = CmbCategory.SelectedItem?.ToString(); 
            string selectedCriteria = CmbCriteria.SelectedItem?.ToString();
            GenerateReport(startDate, endDate, selectedCategory, selectedCriteria);

        }

        private void GenerateReport(DateTime startDate, DateTime endDate, string category, string criteria)
        {
            DataTable reportData = new DataTable();
            string query = BuildReportQuery(startDate, endDate, category, criteria);

            using (var connection = new SqlConnection(SpecialProjectInventory.DatabaseConfig.ConnectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    // Adding parameters to prevent SQL Injection.
                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endDate", endDate);

                    // If category is not null, add it to the command parameters.
                    if (category != null)
                    {
                        command.Parameters.AddWithValue("@category", category);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(reportData);
                }
            }
           
            DgvReport.DataSource = reportData;

            // SaveReport(reportData);
        }

        /*private string BuildReportQuery(DateTime startDate, DateTime endDate, string category, string criteria)
        {
            string baseQuery;

            switch (criteria)
            {
                case "Perishable":
                case "Non-Perishable":
                case "Stock Below Threshold":
                    baseQuery = "SELECT * FROM tbProduct WHERE (expiredatee BETWEEN @startDate AND @endDate)";
                    if (!string.IsNullOrEmpty(category))
                    {
                        baseQuery += " AND pcategory = @category";
                    }
                    if (criteria == "Perishable") baseQuery += " AND isPerishable = 1";
                    if (criteria == "Non-Perishable") baseQuery += " AND isPerishable = 0";
                    if (criteria == "Stock Below Threshold") baseQuery += " AND pqty <= lowstockthreshold";
                    break;
                case "Total Revenue":
                    // This query targets the sales table to calculate total revenue
                    baseQuery = "SELECT SUM(totalAmount) AS TotalRevenue FROM tbSales WHERE (saleDate BETWEEN @startDate AND @endDate)";
                    break;
                default:
                    baseQuery = "";
                    break;
            }

            return baseQuery;
        }*/

        private string BuildReportQuery(DateTime startDate, DateTime endDate, string category, string criteria)
        {
            string baseQuery;

            switch (criteria)
            {
                case "Perishable":
                case "Non-Perishable":
                case "Stock Below Threshold":
                    baseQuery = "SELECT * FROM tbProduct WHERE (expiredatee BETWEEN @startDate AND @endDate)";
                    if (!string.IsNullOrEmpty(category))
                    {
                        baseQuery += " AND pcategory = @category";
                    }
                    if (criteria == "Perishable") baseQuery += " AND isPerishable = 1";
                    if (criteria == "Non-Perishable") baseQuery += " AND isPerishable = 0";
                    if (criteria == "Stock Below Threshold") baseQuery += " AND pqty <= lowstockthreshold";
                    break;
                case "Total Revenue":
                    // Query targets the sales table to calculate total revenue
                    baseQuery = "SELECT SUM(totalAmount) AS TotalRevenue FROM tbSales WHERE (saleDate BETWEEN @startDate AND @endDate)";
                    // Assumes no category filter for Total Revenue since tbSales might not have category info
                    break;
                default:
                    baseQuery = "";
                    break;
            }

            return baseQuery;
        }



        private void PicBoxCloseReport_Click(object sender, EventArgs e)
        {
            Close();
        }


    }

}
