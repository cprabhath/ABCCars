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
    public partial class CarParts : Form
    {
        utils utils = new utils();
        CarPartsModule carParts = new CarPartsModule();
        public CarParts()
        {
            InitializeComponent();
        }

        private void CarParts_Load(object sender, EventArgs e)
        {
            LoadCarsParts();
        }

        private void LoadCarsParts(string searchQuery = "")
        {
            // Clear existing controls in the FlowLayoutPanel
            flowLayoutPanel1.Controls.Clear();

            // Add data from the database
            List<CarPartsList> carPartsLists = new List<CarPartsList>();
            carPartsLists = carParts.GetAllCarParts();
            

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

                // Add the card to the FlowLayoutPanel
                carCard.ViewButtonClick += (s, e) =>
                {
                   
                };

                // Add the card to the FlowLayoutPanel
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
            LoadCarsParts(searchQuery); // Pass the selected sort option
        }
    }
}
