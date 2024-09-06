using ABCCars.Utils;
using ABCCars.Validations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ABCCars.AdminForms.AddNewItem
{
    public partial class CarEdit : Form
    {
        private readonly string id;
        CarsModule Cars = new CarsModule();
        public CarEdit(string _id)
        {
            InitializeComponent();
            id = _id;
        }

        private void CarEdit_Load(object sender, EventArgs e)
        {
            // Create a list of car brands
            var carBrands = new List<string> { "Abarth", "AC", "Acura", "Aixam", "Alfa Romeo", "Ariel", "Arrinera", "Aston Martin", 
            "Audi", "Bentley", "BMW", "Bugatti", "Buick", "Cadillac", "Caterham", "Chevrolet", "Chrysler", "Citroën", 
            "Corvette", "Dacia", "Daf", "Daihatsu", "Dodge", "DR Motor", "Elfin", "Ferrari", "Fiat", "Ford", "Gaz", "Geely", 
            "Gillet", "Ginetta", "General Motors", "GMC", "Great Wall", "Gumpert", "Hennessey", "Holden", "Honda", "Hummer", 
            "Hyundai", "Infiniti", "Isuzu", "Jaguar", "Jeep", "Joss", "Kia", "Koenigsegg", "Lada", "Lamborghini", "Lancia", 
            "Land Rover", "Lexus", "Lincoln", "Lotus", "Luxgen", "Mahindra", "Maruti Suzuki", "Maserati", "Maybach", "Mazda", 
            "Mclaren", "Mercedes", "MG", "Mini", "Mitsubishi", "Morgan Motor", "Mustang", "Nissan", "Noble", "Opel", "Pagani", 
            "Panoz", "Perodua", "Peugeot", "Piaggio", "Pininfarina", "Porsche", "Proton", "Renault", "Reva", "Rimac", "Rolls Royce", 
            "Ruf", "Saab", "Scania", "Scion", "Seat", "Shelby", "Skoda", "Smart", "Spyker", "Ssangyong", "SSC", "Subaru", "Suzuki", 
            "Tata", "Tatra", "Tesla", "Toyota", "Tramontana", "Troller", "TVR", "UAZ", "Vandenbrink", "Vauxhall", "Vector Motors", 
            "Venturi", "Volkswagen", "Volvo", "Wiesmann", "Zagato", "Zaz", "Zil" };
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
            txtQuantitiy.Enabled = true;
            txtCreatedAt.Enabled = false;
            CarPicture.AllowDrop = true;

            if (id != null)
            {
                List<CarList> carLists = new List<CarList>();
                carLists = Cars.GetCarById(id);
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        // ======================== Save Car Details ========================
        private void btnSave_Click(object sender, EventArgs e)
        {
            var carID = txtCarID.Text;
            var name = cmbModelList.Text;
            var model = txtCarModel.Text;
            var description = txtDescription.Text;
            var condition = cmbCondition.Text;
            var price = txtPrice.Text;
            var qty = txtQuantitiy.Text;

            string imagePath = null;

            if (CarPicture.Image != null)
            {
                // Define the uploads folder path
                string uploadsFolder = Application.StartupPath + @"\uploads\cars";

                // Ensure the uploads folder exists
                if (!System.IO.Directory.Exists(uploadsFolder))
                {
                    System.IO.Directory.CreateDirectory(uploadsFolder);
                }

                // Generate a unique file name with an appropriate extension
                string extension = ".jpg";  // Default to .jpg or determine based on image format
                string fileName = Guid.NewGuid().ToString() + extension;  // Unique file name
                imagePath = System.IO.Path.Combine(uploadsFolder, fileName);

                // Save the image to the new path
                CarPicture.Image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);  // Save as JPEG
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to save the changes?", "Save Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                // Validate the input data
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

                // Update car details in the database
                var updated = Cars.UpdateCar(id, name, model, imagePath, description, condition, price, qty);

                if (!updated)
                {
                    MessageBox.Show("Failed to update the car", utils.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Car updated successfully", utils.SuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
    }
}
