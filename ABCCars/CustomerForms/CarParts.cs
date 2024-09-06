using ABCCars.CustomerForms.View;
using ABCCars.Utils;
using ABCCars.Validations;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ABCCars.CustomerForms
{
    public partial class CarParts : Form
    {
        utils utils = new utils();
        CarPartsModule carParts = new CarPartsModule();
        CartModule cartModule = new CartModule();
        public readonly int id;
        public CarParts(List<int> _customerID)
        {
            InitializeComponent();
            id = _customerID[0];
        }

        private void CarParts_Load(object sender, EventArgs e)
        {
            LoadCarsParts();
        }

        private void LoadCarsParts(string searchQuery = "")
        {

            // Clear existing controls in the FlowLayoutPanel
            flowLayoutPanel1.Controls.Clear();
            getCount();

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
                    CarImage = Image.FromFile(car.Image),
                    Description = car.Description,
                    Margin = new Padding(20, 10, 0, 15),
                    ViewButtonText = "View",
                    BuyButtonText = "Add to Cart"
                };

                // Add the card to the FlowLayoutPanel
                carCard.ViewButtonClick += (s, e) =>
                {
                    var viewCar = new ViewCarPart(car.id);
                    viewCar.ShowDialog();
                };

                // Add the card to the FlowLayoutPanel
                carCard.BuyButtonClick += (s, e) =>
                {
                    var result = cartModule.UpdatePartID(id, Convert.ToInt32(car.id));
                    if (!result)
                    {
                        MessageBox.Show("Car Part added to cart successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getCount();
                    }
                    else
                    {
                        MessageBox.Show("Car Part already in cart", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                // Add the card to the FlowLayoutPanel
                flowLayoutPanel1.Controls.Add(carCard);
            }
        }

        private void getCount()
        {
            var count = cartModule.GetCartCount(id);
            txtCount.Text = count.ToString();

        }

        private void serachBox_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = serachBox.Text.Trim().ToLower();
            LoadCarsParts(searchQuery); // Pass the selected sort option
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var cart = new Cart(id);
            cart.ShowDialog();
        }
    }
}
