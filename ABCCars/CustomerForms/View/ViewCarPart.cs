using ABCCars.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABCCars.CustomerForms.View
{
    public partial class ViewCarPart : Form
    {
        private readonly string id;
        CarPartsModule partsModule = new CarPartsModule();
        public ViewCarPart(string _id)
        {
            InitializeComponent();
            id = _id;
        }

        private void ViewCarPart_Load(object sender, EventArgs e)
        {
            if (id != null)
            {
                List<CarPartsList> carPartsLists = new List<CarPartsList>();
                carPartsLists = partsModule.GetCarPartsById(id);

                CarPartsList carPart = carPartsLists[0];

                if (carPart != null)
                {
                    var parts = carPart.Name.Split(' ');

                    txtCarID.Text = carPart.id;
                    CarPartName.Text = parts[0];
                    txtCarModel.Text = parts[1];
                    txtDescription.Text = carPart.Description;
                    cmbCondition.SelectedItem = carPart.Condition;
                    txtPrice.Text = carPart.Price;
                    txtQuantitiy.Text = carPart.qty;
                    txtCreatedAt.Text = carPart.CreatedAt;

                    if (carPart.Image != null)
                    {
                        CarPicture.Image = Image.FromFile(carPart.Image);
                    }
                    else
                    {
                        CarPicture.Image = Properties.Resources.bx_car;
                    }
                }
                else
                {
                    MessageBox.Show("Sorry! We couldn't find the car part details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}