using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ABCCars.CustomerForms
{
    public partial class CarPartsCard : UserControl
    {
        public CarPartsCard()
        {
            InitializeComponent();
            btnView.Click += viewButton_Click;
            btnAddtoCart.Click += buyButton_Click;
        }

        #region Properties
        private string _title;
        private string _description;
        private Image _image;
        private string _button;

        [Category("Custom Props")]
        public string Button
        {
            get { return _button; }
            set { _button = value; btnAddtoCart.Text = value; }
        }


        [Category("Custom Props")]
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                txtTitle.Text = value;
            }
        }

        [Category("Custom Props")]
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                txtDescription.Text = value;
            }
        }

        [Category("Custom Props")]
        public Image Image
        {
            get { return _image; }
            set
            {
                _image = value;
                image.Image = value;
            }
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