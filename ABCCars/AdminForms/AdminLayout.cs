using ABCCars.AdminForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ABCCars
{
    public partial class AdminLayout : Form
    {
        public AdminLayout()
        {
            InitializeComponent();
        }

        Color activeColor = Color.FromArgb(146, 183, 255);

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnDashboard.FillColor = activeColor;

            Panel panel = this.Load_Panel as Panel;
            if (panel != null)
            {
                Dashboard dashboard = new Dashboard();
                dashboard.TopLevel = false; 
                dashboard.FormBorderStyle = FormBorderStyle.None; 
                dashboard.Dock = DockStyle.Fill; 
                panel.Controls.Clear(); 
                panel.Controls.Add(dashboard); 
                dashboard.Show(); 
            }
        }
   
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure want to Logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.Show();
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnDashboard.FillColor = activeColor;

            Panel panel = this.Load_Panel as Panel;
            if (panel != null)
            {
                Dashboard dashboard = new Dashboard();
                dashboard.TopLevel = false;
                dashboard.FormBorderStyle = FormBorderStyle.None;
                dashboard.Dock = DockStyle.Fill;
                panel.Controls.Clear();
                panel.Controls.Add(dashboard);
                dashboard.Show();
            }
        }

        private void btnCarManage_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnCarManage.FillColor = activeColor;

            Panel panel = this.Load_Panel as Panel;
            if (panel != null)
            {
                CarManage carManage = new CarManage();
                carManage.TopLevel = false; 
                carManage.FormBorderStyle = FormBorderStyle.None; 
                carManage.Dock = DockStyle.Fill; 
                panel.Controls.Clear(); 
                panel.Controls.Add(carManage); 
                carManage.Show(); 
            }
        }

        private void btnCarPartManage_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnCarPartManage.FillColor = activeColor;

            Panel panel = this.Load_Panel as Panel;
            if (panel != null)
            {
                CarPartsManage partsManage = new CarPartsManage();
                partsManage.TopLevel = false;
                partsManage.FormBorderStyle = FormBorderStyle.None;
                partsManage.Dock = DockStyle.Fill;
                panel.Controls.Clear();
                panel.Controls.Add(partsManage);
                partsManage.Show();
            }
        }

        private void btnOrderManage_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnOrderManage.FillColor = activeColor;

            Panel panel = this.Load_Panel as Panel;
            if (panel != null)
            {
                OrderManage orderManage = new OrderManage();
                orderManage.TopLevel = false;
                orderManage.FormBorderStyle = FormBorderStyle.None;
                orderManage.Dock = DockStyle.Fill;
                panel.Controls.Clear();
                panel.Controls.Add(orderManage);
                orderManage.Show();
            }
        }

        private void btnCustomerManage_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnCustomerManage.FillColor = activeColor;

            Panel panel = this.Load_Panel as Panel;
            if (panel != null)
            {
                CustomerManage customerManage = new CustomerManage();
                customerManage.TopLevel = false;
                customerManage.FormBorderStyle = FormBorderStyle.None;
                customerManage.Dock = DockStyle.Fill;
                panel.Controls.Clear();
                panel.Controls.Add(customerManage);
                customerManage.Show();
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnSettings.FillColor = activeColor;

            Panel panel = this.Load_Panel as Panel;
            if (panel != null)
            {
                Settings settings = new Settings();
                settings.TopLevel = false;
                settings.FormBorderStyle = FormBorderStyle.None;
                settings.Dock = DockStyle.Fill;
                panel.Controls.Clear();
                panel.Controls.Add(settings);
                settings.Show();
            }
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnReports.FillColor = activeColor;

            Panel panel = this.Load_Panel as Panel;
            if (panel != null)
            {
                ReportsManage reports = new ReportsManage();
                reports.TopLevel = false;
                reports.FormBorderStyle = FormBorderStyle.None;
                reports.Dock = DockStyle.Fill;
                panel.Controls.Clear();
                panel.Controls.Add(reports);
                reports.Show();
            }
        }

        private void ResetButtonColors()
        {
            Color defaultColor = Color.FromArgb(94, 148, 255);

            btnDashboard.FillColor = defaultColor;
            btnCarManage.FillColor = defaultColor;
            btnCarPartManage.FillColor = defaultColor;
            btnOrderManage.FillColor = defaultColor;
            btnCustomerManage.FillColor = defaultColor;
            btnSettings.FillColor = defaultColor;
            btnReports.FillColor = defaultColor;
        }
    }
}
