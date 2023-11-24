private void DisplayReportInDataGridView()
{
    try
    {
        DataTable inventoryData = ProjectUtility.GetInventoryData();

        // Calculate the summary data
        decimal totalSales = inventoryData.AsEnumerable().Sum(row => row.Field<decimal>("total"));
        int totalUnitsSold = inventoryData.AsEnumerable().Sum(row => row.Field<int>("qty"));

        // Add a blank row for visual separation
        DataRow blankRow = inventoryData.NewRow();
        inventoryData.Rows.Add(blankRow);

        // Add summary row
        DataRow summaryRow = inventoryData.NewRow();
        summaryRow["orderid"] = "Summary"; // Replace "orderid" with an appropriate column for the label if necessary
        summaryRow["total"] = totalSales;
        summaryRow["qty"] = totalUnitsSold;
        inventoryData.Rows.Add(summaryRow);

        // Assuming dataGridViewReport is your DataGridView control on the form
        dataGridViewReport.DataSource = inventoryData;
    }
    catch (Exception ex)
    {
        MessageBox.Show("Failed to display report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
