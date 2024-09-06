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
            this.btnView.Location = new System.Drawing.Point(24, 296);
            this.btnView.Margin = new System.Windows.Forms.Padding(2);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(112, 44);
            this.btnView.TabIndex = 11;
            this.btnView.Text = "View Details";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // txtTitle
            // 
            this.txtTitle.AutoSize = true;
            this.txtTitle.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.Location = new System.Drawing.Point(29, 228);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(79, 24);
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
            this.btnAddtoCart.Location = new System.Drawing.Point(141, 296);
            this.btnAddtoCart.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddtoCart.Name = "btnAddtoCart";
            this.btnAddtoCart.Size = new System.Drawing.Size(112, 44);
            this.btnAddtoCart.TabIndex = 9;
            this.btnAddtoCart.Text = "Add to cart";
            this.btnAddtoCart.Click += new System.EventHandler(this.btnAddtoCart_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.AutoSize = false;
            this.txtDescription.BackColor = System.Drawing.Color.Transparent;
            this.txtDescription.Location = new System.Drawing.Point(29, 263);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(193, 17);
            this.txtDescription.TabIndex = 8;
            this.txtDescription.Text = "lorem ipsum";
            // 
            // image
            // 
            this.image.Image = global::ABCCars.Properties.Resources.driving;
            this.image.Location = new System.Drawing.Point(12, 11);
            this.image.Margin = new System.Windows.Forms.Padding(2);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(253, 204);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.image.TabIndex = 7;
            this.image.TabStop = false;
            // 
            // CarPartsCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.btnAddtoCart);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.image);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CarPartsCard";
            this.Size = new System.Drawing.Size(282, 358);
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
