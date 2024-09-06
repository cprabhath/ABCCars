using ABCCars.Utils;
using ABCCars.Validations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ABCCars.AdminForms.AddNewItem
{
    public partial class CarPartEdit : Form
    {
        private string id;
        CarPartsModule partsModule = new CarPartsModule();
        public CarPartEdit(string _id)
        {
            InitializeComponent();   
            id = _id;
        }

        private void CarPartEdit_Load(object sender, EventArgs e)
        {
            var carBrands = new List<string> { "Abarth", "AC", "Acura", "Aixam", "Alfa Romeo", "Ariel", "Arrinera", "Aston Martin", "Audi", "Bentley", "BMW", "Bugatti", "Buick", "Cadillac", "Caterham", "Chevrolet", "Chrysler", "Citroën", "Corvette", "Dacia", "Daf", "Daihatsu", "Dodge", "DR Motor", "Elfin", "Ferrari", "Fiat", "Ford", "Gaz", "Geely", "Gillet", "Ginetta", "General Motors", "GMC", "Great Wall", "Gumpert", "Hennessey", "Holden", "Honda", "Hummer", "Hyundai", "Infiniti", "Isuzu", "Jaguar", "Jeep", "Joss", "Kia", "Koenigsegg", "Lada", "Lamborghini", "Lancia", "Land Rover", "Lexus", "Lincoln", "Lotus", "Luxgen", "Mahindra", "Maruti Suzuki", "Maserati", "Maybach", "Mazda", "Mclaren", "Mercedes", "MG", "Mini", "Mitsubishi", "Morgan Motor", "Mustang", "Nissan", "Noble", "Opel", "Pagani", "Panoz", "Perodua", "Peugeot", "Piaggio", "Pininfarina", "Porsche", "Proton", "Renault", "Reva", "Rimac", "Rolls Royce", "Ruf", "Saab", "Scania", "Scion", "Seat", "Shelby", "Skoda", "Smart", "Spyker", "Ssangyong", "SSC", "Subaru", "Suzuki", "Tata", "Tatra", "Tesla", "Toyota", "Tramontana", "Troller", "TVR", "UAZ", "Vandenbrink", "Vauxhall", "Vector Motors", "Venturi", "Volkswagen", "Volvo", "Wiesmann", "Zagato", "Zaz", "Zil" };
            var condition = new List<string> { "New", "Used" };
            var partCategory = new List<string> { "Engine", "Transmission", "Suspension", "Brakes", "Exhaust", "Interior", "Exterior", "Wheels", "Tires", "Lighting", "Electrical", "Miscellaneous" };

            // Iterate over each car brand in the list
            foreach (var car in carBrands)
            {
                cmdCarName.Items.Add(car);
            }

            foreach (var con in condition)
            {
                cmbCondition.Items.Add(con);
            }

            foreach (var part in partCategory)
            {
                cmbModelList.Items.Add(part);
            }


            txtCarPartID.Enabled = false;
            txtCreatedAt.Enabled = false;
            CarPartPicture.AllowDrop = true;

            if (id != null)
            {
                List<CarPartsList> carPartsLists = new List<CarPartsList>();
                carPartsLists = partsModule.GetCarPartsById(id);

                CarPartsList carPart = carPartsLists[0];

                if (carPart != null)
                {
                    var parts = carPart.Name.Split(' ');

                    txtCarPartID.Text = carPart.id;
                    cmdCarName.SelectedItem = parts[0];
                    cmbModelList.SelectedItem = parts[1];
                    txtDescription.Text = carPart.Description;
                    cmbCondition.SelectedItem = carPart.Condition;
                    txtPrice.Text = carPart.Price;
                    txtQuantitiy.Text = carPart.qty;
                    txtCreatedAt.Text = carPart.CreatedAt;

                    if (carPart.Image != null)
                    {
                        CarPartPicture.Image = Image.FromFile(carPart.Image);
                    }
                    else
                    {
                        CarPartPicture.Image = Properties.Resources.bx_car;
                    }
                }
                else
                {
                    MessageBox.Show("Sorry! We couldn't find the car part details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            CarPartPicture.AllowDrop = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var carID = txtCarPartID.Text;
            var name = cmdCarName.Text + " " + cmbModelList.Text;
            var description = txtDescription.Text;
            var condition = cmbCondition.Text;
            var price = txtPrice.Text;
            var quantity = txtQuantitiy.Text;

            string imagePath = null;

            if (CarPartPicture.Image != null)
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
                CarPartPicture.Image.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);  // Save as JPEG
            }

            // ====================== Validate ========================
            var validate = new VehiclePartValidationValidator();
            var result = validate.Validate(new VehiclePartValidation(id, imagePath, name, description, condition, price, quantity));

            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    MessageBox.Show(failure.ErrorMessage, utils.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Ask for confirmation before saving the changes
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to save the changes?", "Save Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                var updated = partsModule.UpdateCarParts(id, name, imagePath, description, condition, price, quantity, carID);

                if (!updated)
                {
                    MessageBox.Show("Failed to update the car part", utils.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MessageBox.Show("Car part updated successfully", utils.SuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void CarPartPicture_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
            {
                var fileNames = data as string[];
                if (fileNames.Length > 0)
                {
                    CarPartPicture.ImageLocation = fileNames[0];
                    CarPartPicture.Name = fileNames[0];
                }
            }
        }

        private void CarPartPicture_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            cmdCarName.SelectedIndex = 0;
            txtPrice.Text = "";
            txtQuantitiy.Text = "";
            txtDescription.Text = "";
            cmbCondition.SelectedIndex = 0;
            cmbModelList.SelectedIndex = 0;
        }
    }
}
