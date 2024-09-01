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
        public OrderManage()
        {
            InitializeComponent();
        }

        private void OrderManage_Load(object sender, EventArgs e)
        {
            
        }

        public void LoadOrders(string searchQuery = "")
        {
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
                OrdersCard orderCard = new OrdersCard();
                orderCard.Title = order.OrderID;
                orderCard.Description = order.PartID + " Vehicle parts, " + order.VehicleID + " Vehicles";
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
                    
                };
                orderCard.BuyButtonClick += (s, ev) =>
                {
                    

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
