using ABCCars.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ABCCars.CustomerForms
{
    public partial class ClientLayout : Form
    {
        Color activeColor = Color.FromArgb(146, 183, 255);
        DBConnection db = new DBConnection();
        public List<CustomersList> customersLists = new List<CustomersList>();
        public ClientLayout(string _username)
        {
            InitializeComponent();
            txtUsername.Text = _username;

            customersLists = db.GetCustomerByEmail(_username);
        }

        private void btnCarManage_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnCarManage.FillColor = activeColor;
            List<int> customerID = customersLists.Select(c => c.Id).ToList();

            Panel panel = this.Load_Panel as Panel;
            if (panel != null)
            {
                Cars dashboard = new Cars(customerID);
                dashboard.TopLevel = false;
                dashboard.FormBorderStyle = FormBorderStyle.None;
                dashboard.Dock = DockStyle.Fill;
                panel.Controls.Clear();
                panel.Controls.Add(dashboard);
                dashboard.Show();
            }
        }

        private void btnCarPartManage_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnCarPartManage.FillColor = activeColor;
            List<int> customerID = customersLists.Select(c => c.Id).ToList();

            Panel panel = this.Load_Panel as Panel;
            if (panel != null)
            {
                CarParts carParts = new CarParts(customerID);
                carParts.TopLevel = false;
                carParts.FormBorderStyle = FormBorderStyle.None;
                carParts.Dock = DockStyle.Fill;
                panel.Controls.Clear();
                panel.Controls.Add(carParts);
                carParts.Show();
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnProfile.FillColor = activeColor;

            Panel panel = this.Load_Panel as Panel;
            if (panel != null)
            {
                Account account = new Account(txtUsername.Text);
                account.TopLevel = false;
                account.FormBorderStyle = FormBorderStyle.None;
                account.Dock = DockStyle.Fill;
                panel.Controls.Clear();
                panel.Controls.Add(account);
                account.Show();
            }
        }

        private void ResetButtonColors()
        {
            Color defaultColor = Color.FromArgb(94, 148, 255);

            btnCarManage.FillColor = defaultColor;
            btnCarPartManage.FillColor = defaultColor;
            btnProfile.FillColor = defaultColor;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to log out?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.Show();
            }
        }

        private void ClientLayout_Load(object sender, EventArgs e)
        {
            
            ResetButtonColors();
            btnCarManage.FillColor = activeColor;
            List<int> customerID = customersLists.Select(c => c.Id).ToList();

            CartModule cartModule = new CartModule();
            cartModule.CreateCart(customerID[0]);

            Panel panel = this.Load_Panel as Panel;
            if (panel != null)
            {
                Cars dashboard = new Cars(customerID);
                dashboard.TopLevel = false;
                dashboard.FormBorderStyle = FormBorderStyle.None;
                dashboard.Dock = DockStyle.Fill;
                panel.Controls.Clear();
                panel.Controls.Add(dashboard);
                dashboard.Show();
            }
        }
    }
}
