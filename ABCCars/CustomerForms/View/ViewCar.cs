using System.Windows.Forms;

namespace ABCCars.CustomerForms.View
{
    public partial class ViewCar : Form
    {
        public readonly string carID;
        public ViewCar()
        {
            InitializeComponent();
        }

        private void ViewCar_Load(object sender, System.EventArgs e)
        {
            txtCarID.Text = "CAR009";
            cmbModelList.SelectedItem = "Toyota";
            txtCarModel.Text = "Corolla";
            txtPrice.Text = "$10000";
            cmbCondition.SelectedItem = "New";
            txtDescription.Text = "This is a brand new Toyota Corolla 2019 model. It has a 1.8L engine and a 6-speed automatic transmission. The car is in perfect condition and has a clean title.";
            txtQuantitiy.Text = "1";
            txtCreatedAt.Text = "2024-08-01";
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this.Hide();
        }
    }
}
