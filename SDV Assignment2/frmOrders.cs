using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstrumentShopWinForm
{
    public partial class frmOrders : Form
    {
        public frmOrders()
        {
            InitializeComponent();
        }

        private clsOrders _Orders;

        public async void UpdateDisplay()
        {
            try
            {
                lstOrders.DataSource = null;
                lstOrders.DataSource = await clsServiceClient.GetOrdersAsync();
                //lstOrders.DataSource = prOrder.InstrumentList;
            }
            catch
            {

            }

        }

        public static void Run()
        {
            frmOrders lcOrdersForm;
            lcOrdersForm = new frmOrders();
            lcOrdersForm.Show();
            lcOrdersForm.Activate();
        }

        private async void refreshFormFromDBAsync(int prOrderID)
        {
            //SetDetails(await clsServiceClient.GetOrderDetailsAsync(prOrderID), await clsServiceClient.GetTotalOrderPriceAsync());
            SetDetails(await clsServiceClient.GetOrderDetailsAsync(prOrderID), await clsServiceClient.GetTotalOrderPriceAsync());

        }

        private void frmOrders_Load(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lstOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int lcOrder = Convert.ToInt16(lstOrders.Text);
                refreshFormFromDBAsync(lcOrder);
            }
            catch
            {

            }
            //SetDetails(new clsOrders());
        }

        private void SetDetails(clsOrders prOrders, double prTotalOrderPrice)
        {
            _Orders = prOrders;
            lblName.Text = prOrders.InstrumentName;
            lblBrand.Text = prOrders.Brand;
            lblType.Text = prOrders.Type;
            lblQuantity.Text = Convert.ToString(prOrders.Quantity);
            lblPrice.Text = Convert.ToString(prOrders.OrderPrice);
            lblOrderDate.Text = prOrders.OrderDate;
            lblCustomerName.Text = prOrders.CustomerName;
            lblCustomerCity.Text = prOrders.CustomerCity;
            lblTotalPrice.Text = "Total Price $: " + Convert.ToString(prTotalOrderPrice);
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstOrders.SelectedIndex > -1)
            {
                DialogResult result = MessageBox.Show("Are you sure?", "Deleting order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show(await clsServiceClient.DeleteOrderAsync(_Orders));
                    UpdateDisplay();                    
                }

            }
            else
            {
                MessageBox.Show("Unable to Delete, No Order Selected");
            }

        }
    }
}
