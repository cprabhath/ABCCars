using ABCCars.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ABCCars.AdminForms.AddNewItem
{
    public partial class ViewOrders : Form
    {
        private readonly string orderID;
        OrderModule orderModule = new OrderModule();
        CarPartsModule CarPartsModule = new CarPartsModule();
        CarsModule carsModule = new CarsModule();
        private string partID;
        private string vehicleID;

        public ViewOrders(string _orderID)
        {
            InitializeComponent();
            orderID = _orderID;
        }

        private void ViewOrders_Load(object sender, EventArgs e)
        {
            var order = orderModule.GetOrderById(orderID);
            if (order != null)
            {
                List<CarList> cars = new List<CarList>();
                List<CarPartsList> carPartsLists = new List<CarPartsList>();

                foreach (var item in order)
                {
                    if (item.VehicleID != null)
                    {
                        cars = carsModule.GetCarById(item.VehicleID);
                        vehicleID = item.VehicleID;
                    }
                    if (item.PartID != null)
                    {
                        carPartsLists = CarPartsModule.GetCarPartsById(item.PartID);
                        partID = item.PartID;
                    }
                }

                flowLayoutPanel.Controls.Clear();

                // Add car cards to the FlowLayoutPanel
                foreach (var car in cars)
                {
                    CarCard carCard = new CarCard
                    {
                        Title = car.Name + " " + car.Model,
                        CarImage = Image.FromFile(car.Image),
                        Margin = new Padding(20, 10, 0, 15),
                        BuyButtonText = "",
                        ViewButtonText = ""
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
                        Margin = new Padding(20, 10, 0, 15),
                        BuyButtonText = "",
                        ViewButtonText = ""
                    };

                    flowLayoutPanel.Controls.Add(carCard);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
