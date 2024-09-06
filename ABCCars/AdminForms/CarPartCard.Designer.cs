namespace ABCCars.AdminForms
{
    partial class CarPartCard
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
            this.btnBuy = new Guna.UI2.WinForms.Guna2Button();
            this.btnView = new Guna.UI2.WinForms.Guna2Button();
            this.carLable = new System.Windows.Forms.Label();
            this.carPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.carPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuy
            // 
            this.btnBuy.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBuy.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBuy.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBuy.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBuy.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuy.ForeColor = System.Drawing.Color.White;
            this.btnBuy.Location = new System.Drawing.Point(150, 203);
            this.btnBuy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(88, 36);
            this.btnBuy.TabIndex = 11;
            this.btnBuy.Text = "Buy";
            // 
            // btnView
            // 
            this.btnView.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnView.BorderThickness = 2;
            this.btnView.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnView.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnView.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnView.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnView.FillColor = System.Drawing.Color.White;
            this.btnView.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold);
            this.btnView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.btnView.Location = new System.Drawing.Point(67, 203);
            this.btnView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(78, 36);
            this.btnView.TabIndex = 10;
            this.btnView.Text = "View";
            // 
            // carLable
            // 
            this.carLable.AutoSize = true;
            this.carLable.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.carLable.Location = new System.Drawing.Point(38, 158);
            this.carLable.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.carLable.Name = "carLable";
            this.carLable.Size = new System.Drawing.Size(111, 24);
            this.carLable.TabIndex = 9;
            this.carLable.Text = "Suzuki Alto";
            // 
            // carPicture
            // 
            this.carPicture.Image = global::ABCCars.Properties.Resources.Black_and_Red_Modern_Automotive_Car_Logo;
            this.carPicture.Location = new System.Drawing.Point(13, 14);
            this.carPicture.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.carPicture.Name = "carPicture";
            this.carPicture.Size = new System.Drawing.Size(261, 134);
            this.carPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.carPicture.TabIndex = 8;
            this.carPicture.TabStop = false;
            // 
            // CarPartCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.carLable);
            this.Controls.Add(this.carPicture);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CarPartCard";
            this.Size = new System.Drawing.Size(294, 252);
            ((System.ComponentModel.ISupportInitialize)(this.carPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnBuy;
        private Guna.UI2.WinForms.Guna2Button btnView;
        private System.Windows.Forms.Label carLable;
        private System.Windows.Forms.PictureBox carPicture;
    }
}
