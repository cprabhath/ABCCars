using ABCCars.Validations;
using System;
using System.Windows.Forms;
using ABCCars.Utils;

namespace ABCCars.Auth
{
    public partial class ResetPassword : Form
    {
        // =========== import the DBConnection and utils classes ===============
        private readonly DBConnection db = new DBConnection();
        private readonly utils utils = new utils();
        private string tokenDB;
        // =====================================================================

        public ResetPassword()
        {
            InitializeComponent();
            txtToken.Visible = false;
            txtTokenHeader.Visible = false;
            txtTokenSub.Visible = false;
            btnVerifyToken.Visible = false;
            txtNewPasswordHeader.Visible = false;
            txtNewPasswordSub.Visible = false;
            txtNewPassword.Visible = false;
            txtConfirmPassword.Visible = false;
            btnPasswordUpdate.Visible = false;
            txtNewPasswordLable.Visible = false;
            txtConfirmPasswordLable.Visible = false;
        }

        // =========================== Back Button ===============================
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
        // =======================================================================

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtUsername.Text;

            // ====================== Validate the reset password fields ===========================
            var validation = new ResetPasswordValidationsValidator();
            var result = validation.Validate(new ResetPasswordValidations(email));
            var exists = db.GetAllEmails();

            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    MessageBox.Show(failure.ErrorMessage, utils.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clear();
                }
            }

            // ======================== Check if the email exists in the database ====================
            else if (!exists.Contains(email))
            {
                MessageBox.Show("Sorry! Email does not exist", utils.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                clear();
            }

            
            // ========================================================================================
            else
            {
                // ======================== Send the reset password token =============================
                MailSender mailSender = new MailSender();
                tokenDB = mailSender.SendMail(email);
                // ====================================================================================

                // =========================== Store the token in the database ========================
                if (tokenDB != "Error")
                {
                    // ======================== Show the token fields =====================================
                    txtResetPassword.Visible = false;
                    txtResetPasswordsub.Visible = false;
                    txtUsername.Visible = false;
                    btnLogin.Visible = false;

                    txtLable.Text = "Enter token that send your email";
                    btnVerifyToken.Visible = true;
                    txtTokenHeader.Visible = true;
                    txtTokenSub.Visible = true;
                    txtToken.Visible = true;
                    // =========================================================================================
                }
                return;
            }
        }
        // ======================== Verify Token Button ===============================
        private void btnVerifyToken_Click(object sender, EventArgs e)
        {
            // Check if the token match or not
            string userToken = txtToken.Text;

            if(userToken != tokenDB)
            {
                MessageBox.Show("Sorry! Incorrect token", utils.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                clear();
                return;
            }

            btnVerifyToken.Visible = false;
            txtTokenHeader.Visible = false;
            txtTokenSub.Visible = false;
            txtToken.Visible = false;
            txtLable.Visible = false;
            btnClear.Visible = false;

            txtNewPasswordHeader.Visible = true;
            txtNewPasswordSub.Visible = true;
            txtNewPassword.Visible = true;
            txtConfirmPassword.Visible = true;
            btnPasswordUpdate.Visible = true;
            txtNewPasswordLable.Visible = true;
            txtConfirmPasswordLable.Visible = true;
        }
        // ============================================================================

        // ======================== Clear Button ======================================
        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
        // ============================================================================

        private void clear()
        {
            txtUsername.Text = "";
        }

        private void btnPasswordUpdate_Click(object sender, EventArgs e)
        {
            var newPassword = txtNewPassword.Text;
            var confirmPassword = txtConfirmPassword.Text;

            var validation = new NewPasswordValidationsValidator();
            var result = validation.Validate(new NewPasswordValidations(newPassword, confirmPassword));

            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    MessageBox.Show(failure.ErrorMessage, utils.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNewPassword.Text = "";
                    txtConfirmPassword.Text = "";
                }
            }
            else
            {
                // TODO: add login to update password in the database
                MessageBox.Show("working");
            }

        }
    }
}