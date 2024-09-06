namespace ABCCars.AdminForms
{
    partial class OrdersCard
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
            this.titleLable = new System.Windows.Forms.Label();
            this.orderPrice = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.orderID = new System.Windows.Forms.Label();
            this.orderDescription = new System.Windows.Forms.Label();
            this.orderStatus = new System.Windows.Forms.Label();
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
            this.btnBuy.Location = new System.Drawing.Point(176, 172);
            this.btnBuy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(142, 36);
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
            this.btnView.Location = new System.Drawing.Point(34, 172);
            this.btnView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(137, 36);
            this.btnView.TabIndex = 10;
            this.btnView.Text = "View";
            // 
            // titleLable
            // 
            this.titleLable.AutoSize = true;
            this.titleLable.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLable.Location = new System.Drawing.Point(53, 26);
            this.titleLable.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.titleLable.Name = "titleLable";
            this.titleLable.Size = new System.Drawing.Size(74, 24);
            this.titleLable.TabIndex = 9;
            this.titleLable.Text = "ORDER";
            // 
            // orderPrice
            // 
            this.orderPrice.AutoSize = true;
            this.orderPrice.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderPrice.Location = new System.Drawing.Point(74, 133);
            this.orderPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.orderPrice.Name = "orderPrice";
            this.orderPrice.Size = new System.Drawing.Size(98, 24);
            this.orderPrice.TabIndex = 12;
            this.orderPrice.Text = "120,00.00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 133);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 24);
            this.label2.TabIndex = 13;
            this.label2.Text = "$";
            // 
            // orderID
            // 
            this.orderID.AutoSize = true;
            this.orderID.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderID.Location = new System.Drawing.Point(127, 26);
            this.orderID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.orderID.Name = "orderID";
            this.orderID.Size = new System.Drawing.Size(54, 24);
            this.orderID.TabIndex = 14;
            this.orderID.Text = "0001";
            // 
            // orderDescription
            // 
            this.orderDescription.AutoSize = true;
            this.orderDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderDescription.Location = new System.Drawing.Point(12, 62);
            this.orderDescription.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.orderDescription.Name = "orderDescription";
            this.orderDescription.Size = new System.Drawing.Size(51, 20);
            this.orderDescription.TabIndex = 15;
            this.orderDescription.Text = "label1";
            // 
            // orderStatus
            // 
            this.orderStatus.AutoSize = true;
            this.orderStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderStatus.Location = new System.Drawing.Point(12, 94);
            this.orderStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.orderStatus.Name = "orderStatus";
            this.orderStatus.Size = new System.Drawing.Size(51, 20);
            this.orderStatus.TabIndex = 16;
            this.orderStatus.Text = "label1";
            // 
            // OrdersCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.orderStatus);
            this.Controls.Add(this.orderDescription);
            this.Controls.Add(this.orderID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.orderPrice);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.titleLable);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "OrdersCard";
            this.Size = new System.Drawing.Size(359, 232);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnBuy;
        private Guna.UI2.WinForms.Guna2Button btnView;
        private System.Windows.Forms.Label titleLable;
        private System.Windows.Forms.Label orderPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label orderID;
        private System.Windows.Forms.Label orderDescription;
        private System.Windows.Forms.Label orderStatus;
    }
}
