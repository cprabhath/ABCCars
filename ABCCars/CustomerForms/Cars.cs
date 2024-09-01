using ABCCars.CustomerForms.View;
using ABCCars.Utils;
using ABCCars.Validations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ABCCars.CustomerForms
{
    public partial class Cars : Form
    {
        utils utils = new utils();
        CarsModule carsModule = new CarsModule();
        public Cars()
        {
            InitializeComponent();
        }

        private void Cars_Load(object sender, EventArgs e)
        {
            LoadCars();
        }

        private void serachBox_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = serachBox.Text.Trim().ToLower();
            LoadCars(searchQuery); // Pass the selected sort option
        }

        private void LoadCars(string searchQuery = "")
        {
            // Clear existing controls in the FlowLayoutPanel
            flowLayoutPanel1.Controls.Clear();

            // get data from the database
            List<CarList> cars = new List<CarList>();
            cars.Add(new CarList
            {
                carID = "1",
                Name = "Nissan",
                Model = "E - Vehicle",
                Description = "Toyota E - E - Vehicle 2023",
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

            // Perform search filtering
            var filteredCars = cars
                .Where(c =>
                    c.Name.ToLower().Contains(searchQuery) ||
                    c.Model.ToLower().Contains(searchQuery) ||
                    c.Description.ToLower().Contains(searchQuery) ||
                    c.Condition.ToLower().Contains(searchQuery) ||
                    c.Price.ToLower().Contains(searchQuery))
                .ToList();

           
            // Iterate through the filtered cars and create cards
            foreach (var car in filteredCars)
            {
                CarCard carCard = new CarCard
                {
                    Title = car.Name + " " + car.Model,
                    CarImage = car.Image,
                    Description = car.Description,
                    Margin = new Padding(20, 10, 0, 15),
                    ViewButtonText = "View",
                    BuyButtonText = "Add to Cart"
                };

                carCard.ViewButtonClick += (s, e) =>
                {
                    
                };

                carCard.BuyButtonClick += (s, e) =>
                {
                   
                };

                // Add the card to the FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(carCard);
            }
        }
    }
}
