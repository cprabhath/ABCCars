using ABCCars.AdminForms.AddNewItem;
using ABCCars.Validations;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ABCCars.AdminForms
{
    public partial class CustomerManage : Form
    {
        DBConnection dbConnection = new DBConnection();
        utils utils = new utils();
        public CustomerManage()
        {
            InitializeComponent();
        }

        private void CustomerManage_Load(object sender, System.EventArgs e)
        {
            sortBox.Items.Add("All");
            sortBox.Items.Add("Blocked");
            sortBox.SelectedIndex = 0;
            LoadCustomerCards();
        }

        private void LoadCustomerCards(string searchQuery = "", string customerStatus = "all")
        {
            // Clear existing controls in the FlowLayoutPanel
            flowLayoutPanel1.Controls.Clear();

            // Fetch the updated customer list from the database
            var customers = dbConnection.customersLists();

            // Filter customers based on the search query and status
            var filteredCustomers = customers.Where(c =>
                (customerStatus == "all" ||
         (customerStatus == "blocked" && c.Status == 0)) &&
                (c.Name.ToLower().Contains(searchQuery) ||
                 c.Email.ToLower().Contains(searchQuery) ||
                 c.Phone.ToLower().Contains(searchQuery)))
                .ToList();

            // If no customers are found, display a message
            if (filteredCustomers.Count == 0)
            {
                txtCustomer.Text = customerStatus == "blocked" ? "No blocked customers found"
                                                               : "No customers found";
                txtCustomer.Font = new Font("Roboto", 15, FontStyle.Bold);
                txtCustomer.ForeColor = Color.Red;
                return;
            }
            else
            {
                txtCustomer.Text = customerStatus == "blocked" ? "Blocked Customers"
                                                                   : "All Customers";
                txtCustomer.Font = new Font("Roboto", 15, FontStyle.Bold);
                txtCustomer.ForeColor = Color.Black;
            }

            // Iterate through the filtered customers and create cards
            foreach (var customer in filteredCustomers)
            {
                CarCard customerCard = new CarCard();
                customerCard.Title = customer.Name;
                customerCard.CarImage = customer.image;
                customerCard.Margin = new Padding(20, 0, 0, 15);
                customerCard.ViewButtonText = "View";
                customerCard.BuyButtonText = "Delete";

                customerCard.ViewButtonClick += (s, ev) =>
                {
                    CustomerEdit customerEdit = new CustomerEdit(customer.Id);
                    customerEdit.ShowDialog();
                };

                customerCard.BuyButtonClick += (s, ev) =>
                {
                    var result = MessageBox.Show($"Are you sure you want to delete {customer.Name}?", "Delete Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        if (dbConnection.DeleteCustomer(customer.Id))
                        {
                            MessageBox.Show("Customer deleted successfully", utils.SuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCustomerCards(searchQuery, customerStatus); // Refresh the list after deletion
                        }
                        else
                        {
                            MessageBox.Show("Customer deletion failed", utils.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                };

                flowLayoutPanel1.Controls.Add(customerCard);
            }
        }


        private void SearchBox_TextChanged(object sender, System.EventArgs e)
        {
            string searchQuery = SearchBox.Text.Trim().ToLower();
            string selectedSort = sortBox.SelectedItem.ToString().ToLower();
            LoadCustomerCards(searchQuery, selectedSort); // Pass the selected sort option
        }

        private void sortBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string searchQuery = SearchBox.Text.Trim().ToLower();
            string selectedSort = sortBox.SelectedItem.ToString().ToLower();
            LoadCustomerCards(searchQuery, selectedSort); // Pass the selected sort option
        }
    }
}
