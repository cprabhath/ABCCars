namespace ABCCars.CustomerForms
{
    partial class CarPartsCard
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
            this.btnView = new Guna.UI2.WinForms.Guna2Button();
            this.txtTitle = new System.Windows.Forms.Label();
            this.btnAddtoCart = new Guna.UI2.WinForms.Guna2Button();
            this.txtDescription = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.image = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
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
            this.btnView.Location = new System.Drawing.Point(31, 349);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(112, 44);
            this.btnView.TabIndex = 11;
            this.btnView.Text = "View Details";
            // 
            // txtTitle
            // 
            this.txtTitle.AutoSize = true;
            this.txtTitle.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(85, 232);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(102, 30);
            this.txtTitle.TabIndex = 10;
            this.txtTitle.Text = "Audi A1";
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
            this.btnAddtoCart.Location = new System.Drawing.Point(149, 349);
            this.btnAddtoCart.Name = "btnAddtoCart";
            this.btnAddtoCart.Size = new System.Drawing.Size(112, 44);
            this.btnAddtoCart.TabIndex = 9;
            this.btnAddtoCart.Text = "Add to cart";
            // 
            // txtDescription
            // 
            this.txtDescription.AutoSize = false;
            this.txtDescription.BackColor = System.Drawing.Color.Transparent;
            this.txtDescription.Location = new System.Drawing.Point(16, 271);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(257, 77);
            this.txtDescription.TabIndex = 8;
            this.txtDescription.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor in" +
    "cididunt ut labore et dolore magna aliqua. ";
            // 
            // image
            // 
            this.image.Image = global::ABCCars.Properties.Resources.driving;
            this.image.Location = new System.Drawing.Point(16, 13);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(253, 204);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image.TabIndex = 7;
            this.image.TabStop = false;
            // 
            // CarPartsCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.btnAddtoCart);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.image);
            this.Name = "CarPartsCard";
            this.Size = new System.Drawing.Size(282, 405);
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnView;
        private System.Windows.Forms.Label txtTitle;
        private Guna.UI2.WinForms.Guna2Button btnAddtoCart;
        private Guna.UI2.WinForms.Guna2HtmlLabel txtDescription;
        private System.Windows.Forms.PictureBox image;
    }
}
