using System.ComponentModel;
using System;
using System.Windows.Forms;

namespace ABCCars.AdminForms
{
    public partial class OrdersCard : UserControl
    {
        public OrdersCard()
        {
            InitializeComponent();
            btnView.Click += viewButton_Click;
            btnBuy.Click += buyButton_Click;
        }

        #region Properties

        private string _title;
        private string _description;
        private string _price;

        [Category("Custom Props")]
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                orderID.Text = value;
            }
        }

        [Category("Custom Props")]
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                orderDescription.Text = value;
            }
        }

        [Category("Custom Props")]
        public string Price
        {
            get { return _price; }
            set
            {
                _price = value;
                orderPrice.Text = value;
            }
        }
            
        [Category("Custom Props")]
        public string ViewButtonText
        {
            get { return btnView.Text; }
            set { btnView.Text = value; }
        }

        [Category("Custom Props")]
        public string BuyButtonText
        {
            get { return btnBuy.Text; }
            set { btnBuy.Text = value; }
        }

        #endregion

        #region Events
        public event EventHandler ViewButtonClick;
        public event EventHandler BuyButtonClick;

        private void viewButton_Click(object sender, EventArgs e)
        {
            if (this.ViewButtonClick != null)
                this.ViewButtonClick(this, e);
        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            if (this.BuyButtonClick != null)
                this.BuyButtonClick(this, e);
        }

        #endregion
    }
}
