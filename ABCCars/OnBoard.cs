using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABCCars
{
    public partial class OnBoard : Form
    {
        // ================== Create an instance of the QueryExecutor class ==================
        private readonly QueryExecutor queryExecutor = new QueryExecutor();
        private bool isConnectionCheckInProgress = false;
        // ===================================================================================

        // ========================= Initialize the OnBoard form =============================
        public OnBoard()
        {
            InitializeComponent();
            CheckInternetAndDatabaseConnectionAsync();
        }
        // ===================================================================================

        // ========================= Check the internet and database connection ============================
        private async void CheckInternetAndDatabaseConnectionAsync()
        {
            // Check if the connection check is already in progress
            if (isConnectionCheckInProgress) return;
            isConnectionCheckInProgress = true;
            // =============== Progress bar to show the connection check progress ===============
            for (int i = 0; i <= 100; i += 20)
            {
                await Task.Delay(500);
                ProgressBar.Value = i;
            }
            // Check internet connection
            if (!IsInternetAvailable())
            {
                // =============== Show the error message if the internet connection fails ===============
                var result = MessageBox.Show(
                    "We encountered an issue with the internet connection. Please check your connection and try again.",
                    "Internet Connection Error",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error
                );
                // =============== Retry the connection check if the user clicks Retry ===============
                if (result == DialogResult.Retry)
                {
                    isConnectionCheckInProgress = false;
                    CheckInternetAndDatabaseConnectionAsync();
                }
                // =============== Exit the application if the user clicks Cancel ===============
                else
                {
                    Application.Exit();
                }
                return;
            }

            // ================================ Run Check Connection =============================
            bool isConnected = await Task.Run(() => queryExecutor.CheckConnection());
            if (!isConnected)
            {
                // =============== Show the error message if the connection fails ===============
                var result = MessageBox.Show(
                    "We encountered an issue connecting to the database. Please check your internet connection or contact support for further assistance.",
                    "Connection Error",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error
                );

                // =============== Retry the connection check if the user clicks Retry ===============
                if (result == DialogResult.Retry)
                {
                    isConnectionCheckInProgress = false;
                    CheckInternetAndDatabaseConnectionAsync();
                }
                // =============== Exit the application if the user clicks Cancel ===============
                else
                {
                    Application.Exit();
                }
            }
            // =============== Open the main form if the connection is successful ===============
            else
            {
                ProgressBar.Value = 100;
                OpenMainForm();
            }
        }
        // ===================================================================================

        // ========================= Check if the internet is available ============================
        private bool IsInternetAvailable()
        {
            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply reply = ping.Send("www.google.com");
                    return reply.Status == IPStatus.Success;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        // ===================================================================================

        // ========================= Open the main form ======================================
        private void OpenMainForm()
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
        // ===================================================================================

        private void OnBoard_Load(object sender, EventArgs e)
        {
            // Any additional initialization code
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            // Any additional click event code
        }
    }
}
