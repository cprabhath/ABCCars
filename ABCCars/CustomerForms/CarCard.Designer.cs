namespace ABCCars.CustomerForms
{
    partial class CarCard
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtDescription = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnAddtoCart = new Guna.UI2.WinForms.Guna2Button();
            this.txtTitle = new System.Windows.Forms.Label();
            this.btnView = new Guna.UI2.WinForms.Guna2Button();
            this.image = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.AutoSize = false;
            this.txtDescription.BackColor = System.Drawing.Color.Transparent;
            this.txtDescription.Location = new System.Drawing.Point(13, 267);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(257, 77);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor in" +
    "cididunt ut labore et dolore magna aliqua. ";
            // 
            // btnAddtoCart
            // 
            this.btnAddtoCart.AutoRoundedCorners = true;
            this.btnAddtoCart.BorderRadius = 21;
            this.btnAddtoCart.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddtoCart.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddtoCart.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddtoCart.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddtoCart.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddtoCart.ForeColor = System.Drawing.Color.White;
            this.btnAddtoCart.Location = new System.Drawing.Point(146, 345);
            this.btnAddtoCart.Name = "btnAddtoCart";
            this.btnAddtoCart.Size = new System.Drawing.Size(112, 44);
            this.btnAddtoCart.TabIndex = 3;
            this.btnAddtoCart.Text = "Add to cart";
            // 
            // txtTitle
            // 
            this.txtTitle.AutoSize = true;
            this.txtTitle.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(82, 228);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(102, 30);
            this.txtTitle.TabIndex = 4;
            this.txtTitle.Text = "Audi A1";
            // 
            // btnView
            // 
            this.btnView.AutoRoundedCorners = true;
            this.btnView.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnView.BorderRadius = 21;
            this.btnView.BorderThickness = 2;
            this.btnView.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnView.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnView.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnView.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnView.FillColor = System.Drawing.Color.White;
            this.btnView.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.btnView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnView.Location = new System.Drawing.Point(28, 345);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(112, 44);
            this.btnView.TabIndex = 6;
            this.btnView.Text = "View Details";
            // 
            // image
            // 
            this.image.Image = global::ABCCars.Properties.Resources.driving;
            this.image.Location = new System.Drawing.Point(13, 9);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(253, 204);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image.TabIndex = 0;
            this.image.TabStop = false;
            // 
            // CarCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.btnAddtoCart);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.image);
            this.Font = new System.Drawing.Font("Roboto", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.Name = "CarCard";
            this.Size = new System.Drawing.Size(282, 405);
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox image;
        private Guna.UI2.WinForms.Guna2HtmlLabel txtDescription;
        private Guna.UI2.WinForms.Guna2Button btnAddtoCart;
        private System.Windows.Forms.Label txtTitle;
        private Guna.UI2.WinForms.Guna2Button btnView;
    }
}
