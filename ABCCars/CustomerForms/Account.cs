using ABCCars.Utils;
using ABCCars.Validations;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ABCCars.CustomerForms
{
    public partial class Account : Form
    {
        private string username;
        DBConnection db = new DBConnection();
        OrderModule orderModule = new OrderModule();
        public Account(string _username)
        {
            InitializeComponent();
            username = _username;
        }

        private void Account_Load(object sender, EventArgs e)
        {
            CustomersList customersList = new CustomersList();
            List<OrderList> Pending = new List<OrderList>();
            List<OrderList> Completed = new List<OrderList>();
            List<OrderList> Processing = new List<OrderList>();

            var customer = db.GetCustomerByEmail(username);
            if (customer != null)
            {
                customersList = customer;
                txtFullName.Text = customersList.Name;
                txtAddress.Text = customersList.Email;
                txtMobileNumber.Text = customersList.Phone;
                txtAddress.Text = customersList.Address;
            }

            Pending = orderModule.GetOrderByStatus("Pending");
            Completed = orderModule.GetOrderByStatus("Completed");
            Processing = orderModule.GetOrderByStatus("Processing");


            if(Pending.Count > 0)
            {
                txtPending.Text = Pending.Count.ToString();
            }

            if (Completed.Count > 0)
            {
                txtCompleted.Text = Completed.Count.ToString();
            }

            if (Processing.Count > 0)
            {
                txtProcessing.Text = Processing.Count.ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var fullName = txtFullName.Text;
            var email = txtAddress.Text;
            var mobile = txtMobileNumber.Text;
            var address = txtHomeAddress.Text;
            

            var success = db.UpdateCustomerByEmail(fullName, email, mobile, address);
            if (success)
            {
                MessageBox.Show("Customer details updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to update customer details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
