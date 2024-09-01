using ABCCars.Reports;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ABCCars.AdminForms
{
    public partial class ReportsManage : Form
    {
        ConnectionString connectionString = new ConnectionString();
        public ReportsManage()
        {
            InitializeComponent();
        }

        private void btnGenerateSales_Click(object sender, EventArgs e)
        {
            // load crystal report to report viewer
            SalesReport salesReport = new SalesReport();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString.connectionString;

            string sql = "SELECT * FROM SalesReport";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet dataSet = new DataSet();

            adapter.Fill(dataSet, "SalesReport");
            salesReport.SetDataSource(dataSet);

            crystalReportViewer.ReportSource = salesReport;
            crystalReportViewer.Refresh();
        }

        private void btnOrderGenerate_Click(object sender, EventArgs e)
        {
            // load crystal report to report viewer
            OrderReport ordring = new OrderReport();
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionString.connectionString;

            string sql = "SELECT * FROM OrderReport";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataSet dataSet = new DataSet();

            adapter.Fill(dataSet, "OrderReport");
            ordring.SetDataSource(dataSet);

            crystalReportViewer.ReportSource = ordring;
            crystalReportViewer.Refresh();
        }
    }
}
