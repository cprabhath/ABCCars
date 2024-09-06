using ABCCars.Utils;
using Guna.Charts.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ABCCars.AdminForms
{
    public partial class Dashboard : Form
    {
        DBConnection db = new DBConnection();
        OrderModule order = new OrderModule();
        OrderManage orderManage = new OrderManage();

        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, System.EventArgs e)
        {


            // Get the total number of customers and orders
            List<OrderList> Pending = new List<OrderList>();
            List<CustomersList> customersLists = new List<CustomersList>();

            Pending = order.GetOrderByStatus("Pending");
            customersLists = db.customersLists();


            orderCount.Text = Pending.Count.ToString();
            cusCount.Text = customersLists.Count.ToString();
           

            // Convert the text to integer values
            int totalCustomers = Convert.ToInt32(cusCount.Text);
            int totalOrders = Convert.ToInt32(orderCount.Text);

            // Start the counter animations
            AnimateCounter(cusCount, totalCustomers, 5);
            AnimateCounter(orderCount, totalOrders, 5);

            barChart();
            doughnut();
            UpdateClock();
        }

        private void AnimateCounter(Label label, int finalCount, int interval = 50)
        {
            Timer counterTimer = new Timer();
            int currentCount = 0;

            // Setup the timer
            counterTimer.Interval = interval;
            counterTimer.Tick += (s, e) =>
            {
                if (currentCount < finalCount)
                {
                    currentCount++;
                    label.Text = currentCount.ToString(); 
                }
                else
                {
                    counterTimer.Stop(); 
                    counterTimer.Dispose(); 
                }
            };

            label.Text = "0";
            counterTimer.Start();
        }



        public void doughnut()
        {
            string[] orders = { "Orders", "Pending" };

            //Chart configuration
            chart2.XAxes.Display = false;
            chart2.YAxes.Display = false;

            //Create a new dataset 
            var dataset = new Guna.Charts.WinForms.GunaDoughnutDataset();
            var r = new Random();
            for (int i = 0; i < orders.Length; i++)
            {
                //random number
                int num = r.Next(10, 100);

                dataset.DataPoints.Add(orders[i], num);
            }

            //Add a new dataset to a chart.Datasets
            chart2.Datasets.Add(dataset);

            //An update was made to re-render the chart
            chart2.Update();
        }

        public void barChart()
        {
            string[] months = { "August", "September" };

            //Chart configuration 
            chart.YAxes.GridLines.Display = false;

            //Create a new dataset 
            var dataset = new Guna.Charts.WinForms.GunaLineDataset();
            dataset.PointRadius = 10;
            dataset.PointStyle = PointStyle.Circle;
            var r = new Random();
            for (int i = 0; i < months.Length; i++)
            {
                //random number
                int num = r.Next(10, 100);

                dataset.DataPoints.Add(months[i], num);
            }

            //Add a new dataset to a chart.Datasets
            chart.Datasets.Add(dataset);

            //An update was made to re-render the chart
            chart.Update();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateClock();
        }

        private void UpdateClock()
        {
            DateTime now = DateTime.Now;
            clock.Text = now.ToString("hh:mm:ss tt");
        }


    }
}
