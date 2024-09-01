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
        public OrderManage()
        {
            InitializeComponent();
        }

        private void OrderManage_Load(object sender, EventArgs e)
        {
            List<OrderList> orderManages = new List<OrderList>
            {
                new OrderList
                {
                    OrderID = "1",
                    PartID = "1",
                    VehicleID = "1",
                    Total = "100",
                    Status = "Pending",
                    CreatedAt = "2021-01-01",
                    UpdatedAt = "2021-01-01"
                },
                new OrderList
                {
                    OrderID = "2",
                    PartID = "2",
                    VehicleID = "2",
                    Total = "200",
                    Status = "Approved",
                    CreatedAt = "2021-01-01",
                    UpdatedAt = "2021-01-01"
                },
                new OrderList
                {
                    OrderID = "3",
                    PartID = "3",
                    VehicleID = "3",
                    Total = "300",
                    Status = "Processing",
                    CreatedAt = "2021-01-01",
                    UpdatedAt = "2021-01-01"
                }
            };

            foreach (var order in orderManages)
            {
                OrdersCard orderCard = new OrdersCard();
                orderCard.Title = order.OrderID;
                orderCard.Description = order.PartID;
                orderCard.Price = order.Total;
                orderCard.Margin = new Padding(20, 0, 0, 15);
                orderCard.ViewButtonText = "View";
                orderCard.BuyButtonText = "Approve";
                orderCard.ViewButtonClick += (s, ev) =>
                {
                    MessageBox.Show($"View button clicked for {order.OrderID}");
                };
                orderCard.BuyButtonClick += (s, ev) =>
                {
                    MessageBox.Show($"Edit button clicked for {order.OrderID}");
                };
                flowLayoutPanel1.Controls.Add(orderCard);
            }
        }
    }
}
