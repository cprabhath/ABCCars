using ABCCars.Utils;
using ABCCars.Validations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ABCCars.CustomerForms
{
    public partial class CarParts : Form
    {
        utils utils = new utils();
        public CarParts()
        {
            InitializeComponent();
        }

        private void CarParts_Load(object sender, EventArgs e)
        {
            LoadCars();
        }

        private void LoadCars(string searchQuery = "")
        {
            // Clear existing controls in the FlowLayoutPanel
            flowLayoutPanel1.Controls.Clear();

            // add dummy data
            List<CarPartsList> carPartsLists = new List<CarPartsList>
                {
                new CarPartsList
                {
                    Name = "Rim",
                    Description = "Rim for Toyota",
                    Condition = "New",
                    Price = "$350",
                    Image = Properties.Resources.part__1_
                },
                new CarPartsList
                {
                    Name = "Spack Plug",
                    Description = "Spack Plug for Honda Civic",
                    Condition = "New",
                    Price = "$60",
                    Image = Properties.Resources.part__2_
                },
                new CarPartsList
                {
                    Name = "Alternator",
                    Description = "Brand new Alternator Assembly",
                    Condition = "New",
                    Price = "$300",
                    Image = Properties.Resources.part__3_
                },
                new CarPartsList
                {
                    Name = "Head Light",
                    Description = "Head Light for Toyota CHR",
                    Condition = "New",
                    Price = "$750",
                    Image = Properties.Resources.part__4_
                }
            };

            // Perform search filtering
            var filtersParts = carPartsLists
                .Where(c =>
                    c.Name.ToLower().Contains(searchQuery) ||
                    c.Condition.ToLower().Contains(searchQuery) ||
                    c.Price.ToLower().Contains(searchQuery))
                .ToList();


            // Iterate through the filtered cars and create cards
            foreach (var car in filtersParts)
            {
                CarCard carCard = new CarCard
                {
                    Title = car.Name + " " + car.Condition,
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

        private void serachBox_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = serachBox.Text.Trim().ToLower();
            LoadCars(searchQuery); // Pass the selected sort option
        }
    }
}
