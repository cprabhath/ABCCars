using Guna.Charts.WinForms;
using System;
using System.Windows.Forms;

namespace ABCCars.AdminForms
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, System.EventArgs e)
        { 
            // Convert the text to integer values
            int totalCustomers = int.Parse(cusCount.Text);
            int totalOrders = int.Parse(orderCount.Text);

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
            string[] months = { "January", "February", "March", "April" };

            //Chart configuration
            chart2.XAxes.Display = false;
            chart2.YAxes.Display = false;

            //Create a new dataset 
            var dataset = new Guna.Charts.WinForms.GunaDoughnutDataset();
            var r = new Random();
            for (int i = 0; i < months.Length; i++)
            {
                //random number
                int num = r.Next(10, 100);

                dataset.DataPoints.Add(months[i], num);
            }

            //Add a new dataset to a chart.Datasets
            chart2.Datasets.Add(dataset);

            //An update was made to re-render the chart
            chart2.Update();
        }

        public void barChart()
        {
            string[] months = { "January", "February", "March", "April", "May", "June", "July" };

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
