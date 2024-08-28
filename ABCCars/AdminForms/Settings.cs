using ABCCars.Validations;
using System;
using System.Windows.Forms;

namespace ABCCars.AdminForms
{
    public partial class Settings : Form
    {
        DBConnection db = new DBConnection();
        utils utils = new utils();

        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            CheckChangeUsername.Checked = false;
            CheckEmailChange.Checked = false;
            CheckPasswordChange.Checked = false;
            UpdateSaveButtonState();
        }

        private void UpdateSaveButtonState()
        {
            if (CheckChangeUsername.Checked || CheckPasswordChange.Checked || CheckEmailChange.Checked)
            {
                btnSave.Enabled = true; 
            }
            else
            {
                btnSave.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckPasswordChange.Checked)
            {
                var password = txtPassword.Text;
                var confirmPassword = txtConfirmPassword.Text;

                var validation = new NewPasswordValidationsValidator();
                var result = validation.Validate(new NewPasswordValidations(password, confirmPassword));

                if (!result.IsValid)
                {
                    foreach (var failure in result.Errors)
                    {
                        MessageBox.Show(failure.ErrorMessage ,utils.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Update the password
                if(db.ChangeAdminPassword("admin", password))
                {
                    MessageBox.Show("Password changed successfully", utils.SuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Unable to change the password at this moment", utils.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void CheckChangeUsername_CheckedChanged(object sender, EventArgs e)
        {
            if(CheckChangeUsername.Checked)
            {
                txtNewUsername.Enabled = true;
                txtOldUsername.Enabled = true;
                UpdateSaveButtonState();
            }
            else
            {
                txtNewUsername.Enabled = false;
                txtOldUsername.Enabled = false;
                UpdateSaveButtonState();
            }
        }

        private void CheckPasswordChange_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckPasswordChange.Checked)
            {
                txtPassword.Enabled = true;
                txtConfirmPassword.Enabled = true;
                UpdateSaveButtonState();
            }
            else
            {
                txtPassword.Enabled = false;
                txtConfirmPassword.Enabled = false;
                UpdateSaveButtonState();
            }
        }

        private void CheckEmailChange_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckEmailChange.Checked)
            {
                txtExistingEmail.Enabled = true;
                txtNewEmail.Enabled = true;
                UpdateSaveButtonState();
            }
            else
            {
                txtExistingEmail.Enabled = false;
                txtNewEmail.Enabled = false;
                UpdateSaveButtonState();
            }
        }
    }
}
