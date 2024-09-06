using ABCCars.AdminForms.AddNewItem;
using ABCCars.Utils;
using ABCCars.Validations;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ABCCars.AdminForms
{
    public partial class CarManage: Form
    {
        CarsModule Cars = new CarsModule();
        utils utils = new utils();

        public CarManage()
        {
            InitializeComponent();

        }

        private void CarManage_Load(object sender, System.EventArgs e)
        {
            LoadCars();
        }

        private void LoadCars(string searchQuery = "")
        {
            // Clear existing controls in the FlowLayoutPanel
            flowLayoutPanel1.Controls.Clear();

            // add dummy data
            List<CarList> cars = new List<CarList>();
            cars = Cars.GetCars();


            // Combine checks for no cars found or no search results
            if (cars == null || cars.Count == 0)
            {
                txtCarsTitle.Text = "No cars found";
                return;
            }

            // Perform search filtering
            var filteredCars = cars
                .Where(c =>
                    c.Name.ToLower().Contains(searchQuery) ||
                    c.Model.ToLower().Contains(searchQuery) ||
                    c.Description.ToLower().Contains(searchQuery) ||
                    c.Condition.ToLower().Contains(searchQuery) ||
                    c.Price.ToLower().Contains(searchQuery))
                .ToList();

            // Display message if no cars match the search query
            if (filteredCars.Count == 0)
            {
                txtCarsTitle.Text = "No cars found";
                return;
            }
            else
            {
                // Reset title if cars are found
                txtCarsTitle.Text = "Available Cars";
            }

            // Iterate through the filtered cars and create cards
            foreach (var car in filteredCars)
            {
                CarCard carCard = new CarCard
                {
                    Title = car.Name + " " + car.Model,
                    CarImage = Image.FromFile(car.Image),
                    Margin = new Padding(20, 0, 0, 15),
                    ViewButtonText = "View",
                    BuyButtonText = "Delete"
                };

                carCard.ViewButtonClick += (s, e) =>
                {
                    var carDetails = new CarEdit(car.carID);
                    carDetails.ShowDialog();
                };

                carCard.BuyButtonClick += (s, e) =>
                {
                    var confirm = MessageBox.Show("Are you sure you want to delete this car?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirm == DialogResult.Yes)
                    {
                        var result = Cars.DeleteCar(car.carID);
                        if (result)
                        {
                            MessageBox.Show("Car deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadCars(); 
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete car", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                };

                // Add the card to the FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(carCard);
            }
        }

        private void SearchBox_TextChanged(object sender, System.EventArgs e)
        {
            string searchQuery = SearchBox.Text.Trim().ToLower();
            LoadCars(searchQuery); // Pass the selected sort option
        }

        private void btnCarAdd_Click(object sender, System.EventArgs e)
        {
            AddNewCar addNewCar = new AddNewCar();
            addNewCar.ShowDialog();
        }
    }
}
