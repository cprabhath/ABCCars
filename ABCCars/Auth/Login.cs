using ABCCars.Auth;
using ABCCars.Validations;
using System;
using System.Windows.Forms;

// This is used for validate the login fields and check if the user is an admin or a customer
namespace ABCCars
{
    public partial class Login : Form
    {
        // =========== import the DBConnection and utils classes ===============
        private readonly DBConnection db = new DBConnection();
        private readonly utils utils = new utils();
        // =====================================================================

        // ========================== Constructor ==============================
        public Login()
        {
            InitializeComponent();
            showPassword.Checked = true;   
        }
        // =====================================================================

        // ==================== Show/Hide Password =============================
        private void showPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = showPassword.Checked ? '*' : '\0';
        }
        // =====================================================================

        // ======================== Clear Fields ===============================
        private void Clear()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
        }
        // =====================================================================

        // ======================== Login Button ===============================
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // ====================== Validate the login fields ===========================
            var validation = new LoginValidationValidator();
            var result = validation.Validate(new LoginValidation(username, password));

            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    MessageBox.Show(failure.ErrorMessage, utils.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            // =============================================================================

            // ====================== Check if the user is an admin ========================
            if (db.AdminLogin(username, password))
            {
                this.Hide();
                AdminLayout admin = new AdminLayout();
                admin.Show();
            }
            // =============================================================================

            // ====================== Check if the user is a customer ======================
            else if (db.UserLogin(username, password))
            {
                this.Hide();
                AdminLayout customerDashboard = new AdminLayout();
                customerDashboard.Show();
            }
            // =============================================================================

            // ====================== Show error message if login fails ====================
            else
            {
                MessageBox.Show(utils.InvalidLoginMessage, utils.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // =============================================================================

            // ====================== Clear the fields after login =========================
            Clear();
            // =============================================================================
        }

        // ======================== Clear Button ===============================
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        // =====================================================================

        // ======================== Reset Password ==============================
        private void ResetPassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            ResetPassword resetPassword = new ResetPassword();
            resetPassword.Show();
        }
        // =====================================================================

        // ======================== Create Account ==============================
        private void CreateAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.Show();
        }
        // =====================================================================
    }
}
