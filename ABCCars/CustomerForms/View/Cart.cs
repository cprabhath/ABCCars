using ABCCars.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ABCCars.CustomerForms.View
{
    public partial class Cart : Form
    {
        private readonly int id;
        private string partID;
        private string vehicleID;
        CarsModule carsModule = new CarsModule();
        CarPartsModule partsModule = new CarPartsModule();
        CartModule cartModule = new CartModule();
        OrderModule orderModule = new OrderModule();

        public Cart(int _id)
        {
            InitializeComponent();
            id = _id;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Cart_Load(object sender, EventArgs e)
        {
            var result = cartModule.GetAllByCustomerID(id);
            if (result != null)
            {
                List<CarList> carLists = new List<CarList>();
                List<CarPartsList> carPartsLists = new List<CarPartsList>();

                foreach (var item in result)
                {
                    if (item.vehicleID != null)
                    {
                        carLists = carsModule.GetCarById(item.vehicleID);
                        vehicleID = item.vehicleID;
                    }
                    if (item.partID != null)
                    {
                        carPartsLists = partsModule.GetCarPartsById(item.partID);
                        partID = item.partID;
                    }
                }

                flowLayoutPanel.Controls.Clear();

                // Add car cards to the FlowLayoutPanel
                foreach (var car in carLists)
                {
                    CarCard carCard = new CarCard
                    {
                        Title = car.Name + " " + car.Model,
                        CarImage = Image.FromFile(car.Image),
                        Description = car.Description,
                        Margin = new Padding(20, 10, 0, 15),
                    };

                    flowLayoutPanel.Controls.Add(carCard);
                }

                // Add car parts cards to the FlowLayoutPanel
                foreach (var part in carPartsLists)
                {
                    CarCard carCard = new CarCard
                    {
                        Title = part.Name + " " + part.Condition,
                        CarImage = Image.FromFile(part.Image),
                        Description = part.Description,
                        Margin = new Padding(20, 10, 0, 15),
                    };

                    flowLayoutPanel.Controls.Add(carCard);
                }
            }
        }


        private void btnCompleteOrder_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to complete this order?", "Confirm Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                var result = cartModule.GetAllByCustomerID(id);

                if (result != null)
                {
                    var newOrderID = autoGen();

                    var carPrice = 0;
                    var partPrice = 0;

                    var getCarPrice = carsModule.GetCarById(result[0].vehicleID);
                    var getPartPrice = partsModule.GetCarPartsById(result[0].partID);

                    foreach (var car in getCarPrice)
                    {
                        carPrice = Convert.ToInt32(car.Price);
                    }

                    foreach (var part in getPartPrice)
                    {
                        partPrice = Convert.ToInt32(part.Price);
                    }

                    var totalPrice = carPrice + partPrice;

                    var makeOrder = orderModule.CreateOrder(newOrderID, id.ToString(), partID, vehicleID, totalPrice.ToString(), "Pending");

                    if (makeOrder)
                    {
                        MessageBox.Show("Order placed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cartModule.DeleteByCustomerID(id);
                        Cart_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Order failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            
        }
        private string autoGen()
        {
            int newIDNumber = 0;
            newIDNumber++;
            string newOrderID = "ORDER " + newIDNumber.ToString().PadLeft(3, '0');
            return newOrderID;
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}