using ABCCars.AdminForms.AddNewItem;
using ABCCars.CustomerForms;
using ABCCars.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ABCCars.AdminForms
{
    public partial class CarPartsManage : Form
    {
        CarPartsModule carPartsModule = new CarPartsModule();
        public CarPartsManage()
        {
            InitializeComponent();
        }

        private void CarPartsManage_Load(object sender, System.EventArgs e)
        {
            LoadCarParts();
        }

        public void LoadCarParts(string searchQuery = "")
        {
            // get all car parts
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
                    Image = Properties.Resources.car__1_,
                    CreatedAt = "2024-10-10",
                    UpdatedAt = "2024-10-10"
                }
            );

            // Combine checks for no cars found or no search results
            if (carPartsLists == null || carPartsLists.Count == 0)
            {
                txtPartManage.Text = "No car part found";
                return;
            }

            // Perform search filtering
            var filteredCars = carPartsLists
                .Where(c =>
                    c.Name.ToLower().Contains(searchQuery) ||
                    c.Condition.ToLower().Contains(searchQuery))
                .ToList();

            // Display message if no cars match the search query
            if (filteredCars.Count == 0)
            {
                txtPartManage.Text = "No car parts found";
                return;
            }
            else
            {
                // Reset title if cars are found
                txtPartManage.Text = "Available Car Parts";
            }

            // Display car parts
            foreach (var carPart in carPartsLists)
            {
                CarPartCard carPartCard = new CarPartCard();
                carPartCard.Title = carPart.Name;
                carPartCard.CarImage = carPart.Image;
                carPartCard.Margin = new Padding(20, 0, 0, 15);
                carPartCard.ViewButtonText = "View";
                carPartCard.BuyButtonText = "Delete";
                carPartCard.ViewButtonClick += (s, ev) =>
                {
                    var viewCarPart = new CarPartEdit(carPart.id);
                    viewCarPart.ShowDialog();
                };
                carPartCard.BuyButtonClick += (s, ev) =>
                {
                    var confirm = MessageBox.Show("Are you sure you want to delete this car?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirm == DialogResult.Yes)
                    {
                        var result = carPartsModule.DeleteCarParts(carPart.id);
                        if (result)
                        {
                            MessageBox.Show("Car deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCarParts(); // Refresh the car list after deletion
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete car", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                };
                flowLayoutPanel1.Controls.Add(carPartCard);
            }
        }

        private void searchBox_TextChanged(object sender, System.EventArgs e)
        {
            string searchQuery = searchBox.Text.Trim().ToLower();
            LoadCarParts(searchQuery); // Pass the selected sort option
        }
    }
}
