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
            // Car part types
            var carParts = new List<string> { "Rim", "Tyre", "Engine", "Battery", "Brake", "Suspension", "Steering", "Transmission", "Exhaust", "Interior", "Exterior" };
            
            var condition = new List<string> { "New", "Used" };

            // Iterate over each car brand in the list
            foreach (var car in carParts)
            {
                // Add the car brand to the ComboBox (or any other list control)
                cmbModelList.Items.Add(car);
            }

            foreach (var con in condition)
            {
                cmbCondition.Items.Add(con);
            }


            txtPartID.Enabled = false;
            txtQuantitiy.Enabled = false;
            txtCreatedAt.Enabled = false;

            txtPartID.Text = id;

            if (id != null)
            {
                List<CarPartsList> carPartsLists = new List<CarPartsList>();
                carPartsLists.Add
                (
                new CarPartsList
                {
                    id = "1",
                    Name = "Rim",
                    Description = "Rim for Toyota",
                    Condition = "New",
                    Price = "$800",
                    Image = Properties.Resources.part__1_,
                    CreatedAt = "2024-10-10",
                    UpdatedAt = "2024-10-10"
                }
            );

                CarPartsList carPart = carPartsLists[0];

                if (carPart != null)
                {
                    cmbModelList.SelectedItem = carPart.Name;
                    CarPartName.Text = carPart.Name;
                    txtDescription.Text = carPart.Description;
                    cmbCondition.SelectedItem = carPart.Condition;
                    txtPrice.Text = carPart.Price;
                    txtQuantitiy.Text = carPart.qty;
                    txtCreatedAt.Text = carPart.UpdatedAt;

                    if (carPart.Image != null)
                    {
                        CarPartPicture.Image = carPart.Image;
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
            var CarPicture = new PictureBox();
            var id = txtPartID.Text;
            var name = CarPartName.Text;
            var description = txtDescription.Text;
            var condition = cmbCondition.Text;
            var price = txtPrice.Text;
            var quantity = txtQuantitiy.Text;

            

            // Ask for confirmation before saving the changes
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to save the changes?", "Save Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                if (id != null)
                {
                    bool success = partsModule.UpdateCarParts(id, name, description, condition, price, quantity, CarPartPicture.Name);
                    if (success)
                    {
                        MessageBox.Show("Car part details updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update car part details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
    }
}
