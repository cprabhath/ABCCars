using ABCCars.Utils;
using ABCCars.Validations;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ABCCars.AdminForms.AddNewItem
{
    public partial class CustomerEdit : Form
    {
        private readonly int _id;
        DBConnection dBConnection = new DBConnection();
        utils utils = new utils();
        public CustomerEdit(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void CustomerEdit_Load(object sender, EventArgs e)
        {
            List<CustomersList> customersLists = new List<CustomersList>();
            customersLists = dBConnection.GetCustomerById(_id);
            CustomersList customer = customersLists[0];

            if (customersLists != null && customersLists.Count > 0)
            {
                // Access the first item in the list

                txtFullName.Text = customer.Name;
                txtHomeAddress.Text = customer.Address;
                txtAddress.Text = customer.Email;
                txtMobileNumber.Text = customer.Phone;

                // Set the image
                if(customer.image != null)
                {
                    ProfilePicture.Image = Properties.Resources.Black_and_Red_Modern_Automotive_Car_Logo;
                }
            }
            else
            {
                MessageBox.Show("Sorry! We couldn't find the customer details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if(customer.Status == 0)
            {
                btnBlock.Text = "Block";
            }
            else
            {
                btnBlock.Text = "Unblock";
            }
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            if(btnBlock.Text == "Block")
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure want to block this customer", utils.InfoTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    if (dBConnection.BlockCustomer(_id))
                    {
                        MessageBox.Show("Customer blocked successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnBlock.Text = "Unblock";
                    }
                    else
                    {
                        MessageBox.Show("Sorry! We couldn't block the customer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure want to unblock this customer", utils.InfoTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    if (dBConnection.UnblockCustomer(_id))
                    {
                        MessageBox.Show("Customer unblocked successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnBlock.Text = "Block";
                    }
                    else
                    {
                        MessageBox.Show("Sorry! We couldn't unblock the customer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
        }
    }
}
