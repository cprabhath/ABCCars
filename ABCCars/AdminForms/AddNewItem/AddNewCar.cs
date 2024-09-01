using ABCCars.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ABCCars.AdminForms.AddNewItem
{
    public partial class AddNewCar : Form
    {
        CarsModule cars = new CarsModule();

        public AddNewCar()
        {
            InitializeComponent();
        }

        private void CarPicture_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
            {
                var fileNames = data as string[];
                if (fileNames.Length > 0)
                {
                    CarPicture.ImageLocation = fileNames[0];
                    CarPicture.Name = fileNames[0];
                }
            }   
        }

        private void CarPicture_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        // ================================= Save Car =================================
        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to save this car?", "Save Car", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                bool result = cars.AddCar(txtCarID.Text, cmbModelList.Text, txtQuantitiy.Text, txtCarModel.Text, CarPicture.Name, txtDescription.Text, cmbCondition.Text, txtPrice.Text);
                if (result)
                {
                    MessageBox.Show("Car added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Failed to add car", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        // =============================================================================

        private void AddNewCar_Load(object sender, EventArgs e)
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

            CarPicture.AllowDrop = true;

            // ====== auto generated ID =======
            var id = "";
           for (int i = 0; i < 1000; i++)
            {
                id = "CAR " + i.ToString().PadLeft(3, '0');
            }

           txtCarID.Text = id;
            // =================================
        }
    }
}
