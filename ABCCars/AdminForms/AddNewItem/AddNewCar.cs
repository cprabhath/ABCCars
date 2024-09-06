using ABCCars.Utils;
using ABCCars.Validations;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ABCCars.AdminForms.AddNewItem
{
    public partial class AddNewCar : Form
    {
        CarsModule cars = new CarsModule();
        utils utils = new utils();

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
            var carID = txtCarID.Text;
            var name = cmbModelList.Text;
            var model = txtCarModel.Text;
            var description = txtDescription.Text;
            var condition = cmbCondition.Text;
            var price = txtPrice.Text;
            var qty = txtQuantitiy.Text;

            // ======================  Image processing ========================
            var image = CarPicture.Image;
            string imagePath = "";

            if (image != null)
            {
                // ===================== Define the uploads folder path =====================
                string uploadsFolder = Application.StartupPath + @"\uploads\cars";

                // ================ Check if the folder exists, if not, create it ==============
                if (!System.IO.Directory.Exists(uploadsFolder))
                {
                    System.IO.Directory.CreateDirectory(uploadsFolder);
                }

                //=============== Generate a unique file name =========================
                string fileName = System.IO.Path.GetFileName(CarPicture.Name);
                imagePath = System.IO.Path.Combine(uploadsFolder, fileName);

                CarPicture.Image.Save(imagePath);
            }

            var validate = new VehicleValidationValidator();
            var result = validate.Validate(new VehicleValidation(carID, name, model, description, condition, price, imagePath, qty));

            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    MessageBox.Show(failure.ErrorMessage, utils.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            var added = cars.AddCar(carID, name, model, qty, imagePath, description, condition, price);

            if (!added)
            {
                MessageBox.Show("Failed to add the car", utils.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Car added successfully", utils.SuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clear();
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
            txtCreatedAt.Enabled = false;
            txtQuantitiy.Enabled = true;

            CarPicture.AllowDrop = true;

            genID();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void genID()
        {
            string lastCarID = cars.GetLastID();

            int newIDNumber = 0;

            if (!string.IsNullOrEmpty(lastCarID) && lastCarID.Length > 4)
            {
                string numericPart = lastCarID.Substring(4);
                newIDNumber = int.Parse(numericPart) + 1;
            }
            else
            {
                newIDNumber = 1;
            }

            string newCarID = "CAR " + newIDNumber.ToString().PadLeft(3, '0');

            txtCarID.Text = newCarID;
        }

        private void Clear()
        {
            genID();
            cmbModelList.Text = "";
            txtQuantitiy.Text = "";
            txtCarModel.Text = "";
            CarPicture.Image = null;
            CarPicture.Name = "";
            txtDescription.Text = "";
            cmbCondition.Text = "";
            txtPrice.Text = "";
            txtCreatedAt.Text = "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
