using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ABCCars.AdminForms
{
    public partial class CarCard : UserControl
    {
        public CarCard()
        {
            InitializeComponent();
            btnView.Click += viewButton_Click;
            btnBuy.Click += buyButton_Click;
        }

        #region Properties

        private string _title;
        private Image _image;

        [Category("Custom Props")]
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                carLable.Text = value;
            }
        }

        [Category("Custom Props")]
        public Image CarImage
        {
            get { return _image; }
            set
            {
                _image = value;
                carPicture.Image = value; 
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
