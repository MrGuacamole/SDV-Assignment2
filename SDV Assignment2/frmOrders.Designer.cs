namespace InstrumentShopWinForm
{
    partial class frmOrders
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnClose = new System.Windows.Forms.Button();
            this.lstOrders = new System.Windows.Forms.ListBox();
            this.lblOrders = new System.Windows.Forms.Label();
            this.lblOrderDetails = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblTypeHeading = new System.Windows.Forms.Label();
            this.lblBrandHeading = new System.Windows.Forms.Label();
            this.lblNameHeading = new System.Windows.Forms.Label();
            this.lblOrderPrice = new System.Windows.Forms.Label();
            this.lblOrderID = new System.Windows.Forms.Label();
            this.lblQuantityHeading = new System.Windows.Forms.Label();
            this.lblOrderPriceHeading = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblCustomerCity = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblOrderDateHeading = new System.Windows.Forms.Label();
            this.lblCustomerCityHeading = new System.Windows.Forms.Label();
            this.lblCustomerNameHeading = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(607, 274);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(111, 33);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lstOrders
            // 
            this.lstOrders.FormattingEnabled = true;
            this.lstOrders.ItemHeight = 16;
            this.lstOrders.Items.AddRange(new object[] {
            "1\t$2500",
            "2\t$1000",
            "3\t$1000"});
            this.lstOrders.Location = new System.Drawing.Point(12, 72);
            this.lstOrders.Name = "lstOrders";
            this.lstOrders.Size = new System.Drawing.Size(120, 148);
            this.lstOrders.TabIndex = 3;
            this.lstOrders.SelectedIndexChanged += new System.EventHandler(this.lstOrders_SelectedIndexChanged);
            // 
            // lblOrders
            // 
            this.lblOrders.AutoSize = true;
            this.lblOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrders.Location = new System.Drawing.Point(12, 18);
            this.lblOrders.Name = "lblOrders";
            this.lblOrders.Size = new System.Drawing.Size(72, 25);
            this.lblOrders.TabIndex = 4;
            this.lblOrders.Text = "Orders";
            // 
            // lblOrderDetails
            // 
            this.lblOrderDetails.AutoSize = true;
            this.lblOrderDetails.Location = new System.Drawing.Point(206, 52);
            this.lblOrderDetails.Name = "lblOrderDetails";
            this.lblOrderDetails.Size = new System.Drawing.Size(92, 17);
            this.lblOrderDetails.TabIndex = 5;
            this.lblOrderDetails.Text = "Order Details";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(15, 274);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(111, 33);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblTypeHeading
            // 
            this.lblTypeHeading.AutoSize = true;
            this.lblTypeHeading.Location = new System.Drawing.Point(14, 67);
            this.lblTypeHeading.Name = "lblTypeHeading";
            this.lblTypeHeading.Size = new System.Drawing.Size(40, 17);
            this.lblTypeHeading.TabIndex = 7;
            this.lblTypeHeading.Text = "Type";
            // 
            // lblBrandHeading
            // 
            this.lblBrandHeading.AutoSize = true;
            this.lblBrandHeading.Location = new System.Drawing.Point(14, 38);
            this.lblBrandHeading.Name = "lblBrandHeading";
            this.lblBrandHeading.Size = new System.Drawing.Size(46, 17);
            this.lblBrandHeading.TabIndex = 8;
            this.lblBrandHeading.Text = "Brand";
            // 
            // lblNameHeading
            // 
            this.lblNameHeading.AutoSize = true;
            this.lblNameHeading.Location = new System.Drawing.Point(14, 11);
            this.lblNameHeading.Name = "lblNameHeading";
            this.lblNameHeading.Size = new System.Drawing.Size(45, 17);
            this.lblNameHeading.TabIndex = 9;
            this.lblNameHeading.Text = "Name";
            // 
            // lblOrderPrice
            // 
            this.lblOrderPrice.AutoSize = true;
            this.lblOrderPrice.Location = new System.Drawing.Point(70, 52);
            this.lblOrderPrice.Name = "lblOrderPrice";
            this.lblOrderPrice.Size = new System.Drawing.Size(40, 17);
            this.lblOrderPrice.TabIndex = 10;
            this.lblOrderPrice.Text = "Price";
            // 
            // lblOrderID
            // 
            this.lblOrderID.AutoSize = true;
            this.lblOrderID.Location = new System.Drawing.Point(9, 52);
            this.lblOrderID.Name = "lblOrderID";
            this.lblOrderID.Size = new System.Drawing.Size(58, 17);
            this.lblOrderID.TabIndex = 11;
            this.lblOrderID.Text = "OrderID";
            // 
            // lblQuantityHeading
            // 
            this.lblQuantityHeading.AutoSize = true;
            this.lblQuantityHeading.Location = new System.Drawing.Point(14, 93);
            this.lblQuantityHeading.Name = "lblQuantityHeading";
            this.lblQuantityHeading.Size = new System.Drawing.Size(61, 17);
            this.lblQuantityHeading.TabIndex = 12;
            this.lblQuantityHeading.Text = "Quantity";
            // 
            // lblOrderPriceHeading
            // 
            this.lblOrderPriceHeading.AutoSize = true;
            this.lblOrderPriceHeading.Location = new System.Drawing.Point(14, 122);
            this.lblOrderPriceHeading.Name = "lblOrderPriceHeading";
            this.lblOrderPriceHeading.Size = new System.Drawing.Size(81, 17);
            this.lblOrderPriceHeading.TabIndex = 13;
            this.lblOrderPriceHeading.Text = "Order Price";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Location = new System.Drawing.Point(12, 234);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(128, 17);
            this.lblTotalPrice.TabIndex = 14;
            this.lblTotalPrice.Text = "Total Price : $4500";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblOrderDate);
            this.panel1.Controls.Add(this.lblCustomerCity);
            this.panel1.Controls.Add(this.lblCustomerName);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.lblBrand);
            this.panel1.Controls.Add(this.lblPrice);
            this.panel1.Controls.Add(this.lblType);
            this.panel1.Controls.Add(this.lblQuantity);
            this.panel1.Controls.Add(this.lblOrderDateHeading);
            this.panel1.Controls.Add(this.lblCustomerCityHeading);
            this.panel1.Controls.Add(this.lblCustomerNameHeading);
            this.panel1.Controls.Add(this.lblNameHeading);
            this.panel1.Controls.Add(this.lblBrandHeading);
            this.panel1.Controls.Add(this.lblOrderPriceHeading);
            this.panel1.Controls.Add(this.lblTypeHeading);
            this.panel1.Controls.Add(this.lblQuantityHeading);
            this.panel1.Location = new System.Drawing.Point(203, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(398, 235);
            this.panel1.TabIndex = 15;
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Location = new System.Drawing.Point(176, 149);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(80, 17);
            this.lblOrderDate.TabIndex = 24;
            this.lblOrderDate.Text = "14/05/2018";
            // 
            // lblCustomerCity
            // 
            this.lblCustomerCity.AutoSize = true;
            this.lblCustomerCity.Location = new System.Drawing.Point(176, 205);
            this.lblCustomerCity.Name = "lblCustomerCity";
            this.lblCustomerCity.Size = new System.Drawing.Size(52, 17);
            this.lblCustomerCity.TabIndex = 23;
            this.lblCustomerCity.Text = "Nelson";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(176, 177);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(105, 17);
            this.lblCustomerName.TabIndex = 22;
            this.lblCustomerName.Text = "Steve Peterson";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(176, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(85, 17);
            this.lblName.TabIndex = 19;
            this.lblName.Text = "Stratocaster";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(176, 39);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(53, 17);
            this.lblBrand.TabIndex = 18;
            this.lblBrand.Text = "Fender";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(176, 123);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(48, 17);
            this.lblPrice.TabIndex = 21;
            this.lblPrice.Text = "$2500";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(176, 68);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(35, 17);
            this.lblType.TabIndex = 17;
            this.lblType.Text = "New";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(176, 94);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(16, 17);
            this.lblQuantity.TabIndex = 20;
            this.lblQuantity.Text = "2";
            // 
            // lblOrderDateHeading
            // 
            this.lblOrderDateHeading.AutoSize = true;
            this.lblOrderDateHeading.Location = new System.Drawing.Point(14, 148);
            this.lblOrderDateHeading.Name = "lblOrderDateHeading";
            this.lblOrderDateHeading.Size = new System.Drawing.Size(79, 17);
            this.lblOrderDateHeading.TabIndex = 16;
            this.lblOrderDateHeading.Text = "Order Date";
            // 
            // lblCustomerCityHeading
            // 
            this.lblCustomerCityHeading.AutoSize = true;
            this.lblCustomerCityHeading.Location = new System.Drawing.Point(14, 204);
            this.lblCustomerCityHeading.Name = "lblCustomerCityHeading";
            this.lblCustomerCityHeading.Size = new System.Drawing.Size(95, 17);
            this.lblCustomerCityHeading.TabIndex = 15;
            this.lblCustomerCityHeading.Text = "Customer City";
            // 
            // lblCustomerNameHeading
            // 
            this.lblCustomerNameHeading.AutoSize = true;
            this.lblCustomerNameHeading.Location = new System.Drawing.Point(14, 176);
            this.lblCustomerNameHeading.Name = "lblCustomerNameHeading";
            this.lblCustomerNameHeading.Size = new System.Drawing.Size(109, 17);
            this.lblCustomerNameHeading.TabIndex = 14;
            this.lblCustomerNameHeading.Text = "Customer Name";
            // 
            // frmOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 329);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.lblOrderID);
            this.Controls.Add(this.lblOrderPrice);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblOrderDetails);
            this.Controls.Add(this.lblOrders);
            this.Controls.Add(this.lstOrders);
            this.Controls.Add(this.btnClose);
            this.Name = "frmOrders";
            this.Text = "Orders";
            this.Load += new System.EventHandler(this.frmOrders_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListBox lstOrders;
        private System.Windows.Forms.Label lblOrders;
        private System.Windows.Forms.Label lblOrderDetails;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblTypeHeading;
        private System.Windows.Forms.Label lblBrandHeading;
        private System.Windows.Forms.Label lblNameHeading;
        private System.Windows.Forms.Label lblOrderPrice;
        private System.Windows.Forms.Label lblOrderID;
        private System.Windows.Forms.Label lblQuantityHeading;
        private System.Windows.Forms.Label lblOrderPriceHeading;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblCustomerCity;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblOrderDateHeading;
        private System.Windows.Forms.Label lblCustomerCityHeading;
        private System.Windows.Forms.Label lblCustomerNameHeading;
    }
}