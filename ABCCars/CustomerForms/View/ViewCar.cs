using ABCCars.Utils;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ABCCars.CustomerForms.View
{
    public partial class ViewCar : Form
    {
        public readonly string carID;
        CarsModule CarsModule = new CarsModule();
        public ViewCar(string car)
        {
            InitializeComponent();
            carID = car;
        }

        private void ViewCar_Load(object sender, System.EventArgs e)
        {
            if (carID != null)
            {
                List<CarList> carLists = new List<CarList>();
                carLists = CarsModule.GetCarById(carID);
                CarList car = carLists[0];

                if (carLists != null && carLists.Count > 0)
                {
                    txtCarID.Text = car.carID;
                    cmbModelList.SelectedItem = car.Name;
                    txtCarModel.Text = car.Model;
                    txtDescription.Text = car.Description;
                    cmbCondition.SelectedItem = car.Condition;
                    txtPrice.Text = car.Price;
                    txtQuantitiy.Text = car.qty;
                    txtCreatedAt.Text = car.CreatedAt;

                    if (car.Image != null)
                    {
                        CarPicture.Image = Image.FromFile(car.Image);
                    }
                    else
                    {
                        CarPicture.Image = Properties.Resources.bx_car;
                    }
                }
                else
                {
                    MessageBox.Show("Sorry! We couldn't find the car details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExit_Click(object sender, System.EventArgs e)
        {
            this.Hide();
        }
    }
}
