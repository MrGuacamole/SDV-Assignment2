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
    public sealed partial class frmMain : Form
    {


        private static readonly frmMain instance = new frmMain();

        public static frmMain Instance => instance;

        public frmMain()
        {
            InitializeComponent();
        }

      


        public async void UpdateDisplay()
        {
            try
            {
                lstCategories.DataSource = null;
                lstCategories.DataSource = await clsServiceClient.GetCategoryNamesAsync();
            }
            catch
            {

            }
            
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            frmOrders.Run();
        }

        private void lstCategories_DoubleClick(object sender, EventArgs e)
        {
            string lcKey;
            lcKey = Convert.ToString(lstCategories.SelectedItem);
            if (lcKey != null)
            {
                try
                {
                    frmCategory.Run(lstCategories.SelectedItem as string);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                UpdateDisplay();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
         
            UpdateDisplay();
            
        }
     
    }
}
