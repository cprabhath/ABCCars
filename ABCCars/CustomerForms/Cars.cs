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
    public partial class Cars : Form
    {
        utils utils = new utils();
        CarsModule carsModule = new CarsModule();
        CartModule cartModule = new CartModule();
        public readonly int id;

        public Cars(List<int> _customerID)
        {
            InitializeComponent();
            id = _customerID[0];
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
            getCount();

            // get data from the database
            List<CarList> cars = new List<CarList>();
            cars = carsModule.GetCars();

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
                    CarImage = Image.FromFile(car.Image),
                    Description = car.Description,
                    Margin = new Padding(20, 10, 0, 15),
                    ViewButtonText = "View",
                    BuyButtonText = "Add to Cart"
                };

                carCard.ViewButtonClick += (s, e) =>
                {
                    var carView = new ViewCar(car.carID);
                    carView.ShowDialog();
                };

                carCard.BuyButtonClick += (s, e) =>
                {
                    var updateCart = cartModule.UpdateVehicleID(id, Convert.ToInt32(car.carID));
                    if (updateCart)
                    {
                        MessageBox.Show("Car added to cart successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getCount();
                    }
                    else
                    {
                        MessageBox.Show("Car already in cart", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var cart = new Cart(id);
            cart.ShowDialog();
        }
    }
}
