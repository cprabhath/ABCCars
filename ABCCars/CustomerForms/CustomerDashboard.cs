using System.Windows.Forms;

namespace ABCCars
{
    public partial class CustomerDashboard : Form
    {
        public CustomerDashboard()
        {
            InitializeComponent();
        }

        private void Logout_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
