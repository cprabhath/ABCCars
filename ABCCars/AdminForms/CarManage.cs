using ABCCars.AdminForms.AddNewItem;
using ABCCars.Utils;
using ABCCars.Validations;
using System.Collections.Generic;
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
            cars.Add(new CarList
            {
                carID = "1",
                Name = "Nissan",
                Model = "BlueBird",
                Description = "Toyota E - Vehicle 2023",
                Condition = "New",
                Price = "$80000",
                Image = Properties.Resources.car__1_,
                CreatedAt = "2024-10-10",
                UpdatedAt = "2024-10-10"
            });

            cars.Add(new CarList
            {
                carID = "2",
                Name = "Toyota",
                Model = "Prius",
                Description = "Toyota Prius 2021",
                Condition = "New",
                Price = "$78000",
                Image = Properties.Resources.car__2_,
                CreatedAt = "2021-10-10",
                UpdatedAt = "2021-10-10"
            });

            cars.Add(new CarList
            {
                carID = "3",
                Name = "Suzuki",
                Model = "Swift",
                Description = "Toyota Swift 2021",
                Condition = "New",
                Price = "$24000",
                Image = Properties.Resources.car__3_,
                CreatedAt = "2021-10-10",
                UpdatedAt = "2021-10-10"
            });

            cars.Add(new CarList
            {
                carID = "4",
                Name = "Honda",
                Model = "Civic",
                Description = "Honda Civic 2021",
                Condition = "New",
                Price = "$44000",
                Image = Properties.Resources.car__4_,
                CreatedAt = "2021-10-10",
                UpdatedAt = "2021-10-10"
            });

            cars.Add(new CarList
            {
                carID = "5",
                Name = "Toyoto",
                Model = "CHR",
                Description = "Honda CHR 2021",
                Condition = "New",
                Price = "$54000",
                Image = Properties.Resources.car__8_,
                CreatedAt = "2021-10-10",
                UpdatedAt = "2021-10-10"
            });


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
                    CarImage = car.Image,
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
                            LoadCars(); // Refresh the car list after deletion
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
