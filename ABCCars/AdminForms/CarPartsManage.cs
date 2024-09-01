using ABCCars.Utils;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ABCCars.AdminForms
{
    public partial class CarPartsManage : Form
    {
        public CarPartsManage()
        {
            InitializeComponent();
        }

        private void CarPartsManage_Load(object sender, System.EventArgs e)
        {
            List<CarPartsList> carPartsLists = new List<CarPartsList>
            {
                new CarPartsList
                {
                    Name = "Rim",
                    Description = "Rim for Toyota",
                    Condition = "New",
                    Price = "$350",
                    Image = Properties.Resources.part__1_
                },
                new CarPartsList
                {
                    Name = "Spack Plug",
                    Description = "Spack Plug for Honda Civic",
                    Condition = "New",
                    Price = "$60",
                    Image = Properties.Resources.part__2_
                },
                new CarPartsList
                {
                    Name = "Alternator",
                    Description = "Brand new Alternator Assembly",
                    Condition = "New",
                    Price = "$300",
                    Image = Properties.Resources.part__3_
                },
                new CarPartsList
                {
                    Name = "Head Light",
                    Description = "Head Light for Toyota CHR",
                    Condition = "New",
                    Price = "$750",
                    Image = Properties.Resources.part__4_
                }
            };

            foreach (var carPart in carPartsLists)
            {
                CarPartCard carPartCard = new CarPartCard();
                carPartCard.Title = carPart.Name;
                carPartCard.CarImage = carPart.Image;
                carPartCard.Margin = new Padding(20, 0, 0, 15);
                carPartCard.ViewButtonText = "View";
                carPartCard.BuyButtonText = "Edit";
                carPartCard.ViewButtonClick += (s, ev) =>
                {
                    MessageBox.Show($"View button clicked for {carPart.Name}");
                };
                carPartCard.BuyButtonClick += (s, ev) =>
                {
                    MessageBox.Show($"Edit button clicked for {carPart.Name}");
                };
                flowLayoutPanel1.Controls.Add(carPartCard);
            }
        }
    }
}
