using ABCCars.AdminForms.AddNewItem;
using ABCCars.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABCCars.AdminForms
{
    public partial class OrderManage : Form
    {
        OrderModule orderModule = new OrderModule();
        CarsModule carsModule = new CarsModule();
        CarPartsModule partsModule = new CarPartsModule();
        DBConnection connection = new DBConnection();

        public OrderManage()
        {
            InitializeComponent();
        }

        private void OrderManage_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        public void LoadOrders(string searchQuery = "")
        {
            flowLayoutPanel1.Controls.Clear();
            List<OrderList> orderManages = new List<OrderList>();
            orderManages = orderModule.GetAllOrders();

            // Combine checks for no order found or no search results
            if (orderManages == null || orderManages.Count == 0)
            {
                txtOrders.Text = "No orders found";
                return;
            }

            // Perform search filtering
            var filteredOrders = orderManages
                .Where(c =>
                    c.OrderID.ToLower().Contains(searchQuery) ||
                    c.Status.ToLower().Contains(searchQuery))
                .ToList();

            // Display message if no order match the search query
            if (filteredOrders.Count == 0)
            {
                txtOrders.Text = "No orders found";
                return;
            }

            foreach (var order in orderManages)
            {
                var carName = carsModule.GetCarById(order.VehicleID);
                var CarPart = partsModule.GetCarPartsById(order.PartID);

                OrdersCard orderCard = new OrdersCard();
                orderCard.Title = order.OrderID;
                orderCard.Description = carName[0].Name + " Vehicles, and " + CarPart[0].Name + " Parts";
                orderCard.OrderStatus = order.Status;
                orderCard.Price = order.Total;
                orderCard.Margin = new Padding(20, 0, 0, 15);
                orderCard.ViewButtonText = "View";
                if (order.Status == "Pending")
                {
                    orderCard.BuyButtonText = "Approve";
                }
                else
                {
                    orderCard.BuyButtonText = "Rejected";
                }
                orderCard.ViewButtonClick += (s, ev) =>
                {
                    var viewOrder = new ViewOrders(order.OrderID);
                    viewOrder.ShowDialog();
                };
                orderCard.BuyButtonClick += (s, ev) =>
                {
                    var acccept = MessageBox.Show("Are you sure you want to approve this order?", "Approve Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (acccept == DialogResult.Yes)
                    {
                        var result = orderModule.UpdateOrder(order.OrderID, "Approved");
                        var Email = connection.GetCustomerById(Convert.ToInt32(order.CustomerID));
                        if (result && Email != null)
                        {
                            OrderApproveMail orderApprove = new OrderApproveMail();
                            orderApprove.SendOrderApproveMail(Email[0].Email);
                            LoadOrders(searchQuery);
                        }
                        else
                        {
                            MessageBox.Show("Order approval failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                };
                flowLayoutPanel1.Controls.Add(orderCard);
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            var searchQuery = searchBox.Text.Trim().ToLower();
            LoadOrders(searchQuery);
        }
    }
}
