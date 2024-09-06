using ABCCars.CustomerForms;
using ABCCars.Utils;
using ABCCars.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABCCars.AdminForms.AddNewItem
{
    public partial class AddNewParts : Form
    {

        CarPartsModule partsModule = new CarPartsModule();

        public AddNewParts()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var partID = txtCarPartID.Text; 
            var name = cmdCarName.Text + " " + cmbModelList.Text;
            var description = txtDescription.Text;
            var condition = cmbCondition.Text;
            var price = txtPrice.Text;
            var qty = txtQuantitiy.Text;
            var model = cmbModelList.Text;

            // ======================  Image processing ========================
            var image = CarPartPicture.Image;
            string imagePath = "";

            if (image != null)
            {
                // ===================== Define the uploads folder path =====================
                string uploadsFolder = Application.StartupPath + @"\uploads\carsparts";

                // ================ Check if the folder exists, if not, create it ==============
                if (!System.IO.Directory.Exists(uploadsFolder))
                {
                    System.IO.Directory.CreateDirectory(uploadsFolder);
                }

                //=============== Generate a unique file name =========================
                string fileName = System.IO.Path.GetFileName(CarPartPicture.Name);
                imagePath = System.IO.Path.Combine(uploadsFolder, fileName);

                CarPartPicture.Image.Save(imagePath);
            }

            // ====================== Validate ========================
            var validate = new VehiclePartValidationValidator();
            var result = validate.Validate(new VehiclePartValidation(partID, imagePath, name ,description, condition, price, qty));

            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    MessageBox.Show(failure.ErrorMessage, utils.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // ====================== Add Car ========================
            var added = partsModule.CreateCarParts(name, imagePath, description, condition, price, qty, partID);

            if (!added)
            {
                MessageBox.Show("Failed to add the car part", utils.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Car part added successfully", utils.SuccessTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            genID();
            cmdCarName.SelectedIndex = 0;
            txtPrice.Text = "";
            txtQuantitiy.Text = "";
            txtDescription.Text = "";
            cmbCondition.SelectedIndex = 0;
            cmbModelList.SelectedIndex = 0;
        }

        private void genID()
        {
            string lastCarID = partsModule.GetLastPartID();

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

            string newCarID = "PART " + newIDNumber.ToString().PadLeft(3, '0');

            txtCarPartID.Text = newCarID;
        }

        private void AddNewParts_Load(object sender, EventArgs e)
        {
            genID();
            CarPartPicture.AllowDrop = true;
            txtQuantitiy.Enabled = true;

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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
