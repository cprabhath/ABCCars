using ABCCars.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ABCCars.AdminForms.AddNewItem
{
    public partial class CarEdit : Form
    {
        private readonly string id;
        Cars Cars = new Cars();
        public CarEdit(string _id)
        {
            InitializeComponent();
            id = _id;
        }

        private void CarEdit_Load(object sender, EventArgs e)
        {
            // Create a list of car brands
            var carBrands = new List<string> { "Abarth", "AC", "Acura", "Aixam", "Alfa Romeo", "Ariel", "Arrinera", "Aston Martin", "Audi", "Bentley", "BMW", "Bugatti", "Buick", "Cadillac", "Caterham", "Chevrolet", "Chrysler", "Citroën", "Corvette", "Dacia", "Daf", "Daihatsu", "Dodge", "DR Motor", "Elfin", "Ferrari", "Fiat", "Ford", "Gaz", "Geely", "Gillet", "Ginetta", "General Motors", "GMC", "Great Wall", "Gumpert", "Hennessey", "Holden", "Honda", "Hummer", "Hyundai", "Infiniti", "Isuzu", "Jaguar", "Jeep", "Joss", "Kia", "Koenigsegg", "Lada", "Lamborghini", "Lancia", "Land Rover", "Lexus", "Lincoln", "Lotus", "Luxgen", "Mahindra", "Maruti Suzuki", "Maserati", "Maybach", "Mazda", "Mclaren", "Mercedes", "MG", "Mini", "Mitsubishi", "Morgan Motor", "Mustang", "Nissan", "Noble", "Opel", "Pagani", "Panoz", "Perodua", "Peugeot", "Piaggio", "Pininfarina", "Porsche", "Proton", "Renault", "Reva", "Rimac", "Rolls Royce", "Ruf", "Saab", "Scania", "Scion", "Seat", "Shelby", "Skoda", "Smart", "Spyker", "Ssangyong", "SSC", "Subaru", "Suzuki", "Tata", "Tatra", "Tesla", "Toyota", "Tramontana", "Troller", "TVR", "UAZ", "Vandenbrink", "Vauxhall", "Vector Motors", "Venturi", "Volkswagen", "Volvo", "Wiesmann", "Zagato", "Zaz", "Zil" };
            var condition = new List<string> { "New", "Used" };

            // Iterate over each car brand in the list
            foreach (var car in carBrands)
            {
                // Add the car brand to the ComboBox (or any other list control)
                cmbModelList.Items.Add(car);
            }

            foreach (var con in condition)
            {
                cmbCondition.Items.Add(con);
            }


            txtCarID.Enabled = false;
            txtQuantitiy.Enabled = false;
            txtCreatedAt.Enabled = false;

            txtCarID.Text = id;

            if (id != null)
            {
                List<CarList> carLists = new List<CarList>();
                carLists = Cars.GetCarById(id);
                CarList car = carLists[0];

                if (carLists != null && carLists.Count > 0)
                {
                    cmbModelList.SelectedItem = car.Name;
                    txtCarModel.Text = car.Model;
                    txtDescription.Text = car.Description;
                    cmbCondition.SelectedItem = car.Condition;
                    txtPrice.Text = car.Price;
                    txtQuantitiy.Text = car.qty;
                    txtCreatedAt.Text = car.UpdatedAt;

                    if (car.Image != null)
                    {
                        CarPicture.Image = car.Image;
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to save the changes?", "Save Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (id != null)
                {
                    bool result = Cars.UpdateCar(id, cmbModelList.Text, txtCarModel.Text, CarPicture.Name, txtDescription.Text, cmbCondition.Text, txtPrice.Text, txtQuantitiy.Text);
                    if (result)
                    {
                        MessageBox.Show("Car details updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update car details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
