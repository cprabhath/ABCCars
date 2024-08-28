using ABCCars.Utils;
using ABCCars.Validations;
using System;
using System.Windows.Forms;
using static ABCCars.Validations.CustomerRegistrationValidations;

namespace ABCCars.Auth
{
    public partial class Register : Form
    {
        private string otp = "";
        private int emailVerified = 0;
        private string email = "";
        DBConnection dBConnection = new DBConnection();

        public Register()
        {
            InitializeComponent();
            btnVerify.Visible = false;
            txtOTP.Visible = false;
            txtVerfiyHeading.Visible = false;
            txtVerifySub.Visible = false;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var fullName = txtFullName.Text;
            email = txtEmailAddress.Text;
            var mobile = txtMobileNumber.Text;
            var address = txtAddress.Text;
            var password = txtPassword.Text;
            var confirmPassword = txtConfirmPassword.Text;

            var validation = new CustomerRegistrationValidator();
            var result = validation.Validate(new CustomerRegistrationValidations(fullName, email, mobile, address, password, confirmPassword));

            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    MessageBox.Show(failure.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            CustomerRegister(fullName, email, mobile, address, password, emailVerified);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            txtFullName.Text = "";
            txtEmailAddress.Text = "";
            txtMobileNumber.Text = "";
            txtAddress.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void CustomerRegister(string fullName, string email, string mobile, string address, string password, int emailVerified)
        {
            try
            {
                txtFullName.Visible = false;
                txtEmailAddress.Visible = false;
                txtMobileNumber.Visible = false;
                txtAddress.Visible = false;
                txtPassword.Visible = false;
                txtConfirmPassword.Visible = false;
                txtRegisterHeader.Visible = false;
                txtRegisterSub.Visible = false;
                lbFullName.Visible = false;
                lbEmail.Visible = false;
                lbMobileNumber.Visible = false;
                lbPassword.Visible = false;
                lbConfirmPassword.Visible = false;
                lbAddress.Visible = false;
                btnClear.Visible = false;
                btnRegister.Visible = false;

                btnVerify.Visible = true;
                txtOTP.Visible = true;
                txtVerfiyHeading.Visible = true;
                txtVerifySub.Visible = true;


                if(!dBConnection.RegisterCustomer(fullName, address, mobile, email, password, emailVerified))
                {
                    MessageBox.Show("Registration Failed", utils.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                MailSender mailSender = new MailSender();
                otp = mailSender.SendMail(txtEmailAddress.Text);
                MessageBox.Show("Registration Successful", utils.SuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message, utils.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (txtOTP.Text != otp)
            {
                MessageBox.Show("Invalid OTP", utils.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            emailVerified = 1;

            if (emailVerified == 1)
            {
                if (!EmailVerification(email))
                {
                    MessageBox.Show("Email Verification Failed", utils.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOTP.Text = "";
                    return;
                }

                MessageBox.Show("Email Verified. Please Login to continue ", utils.SuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private bool EmailVerification(string email)
        {
            return dBConnection.UpdateEmailVerification(email);
        }
    }
}
