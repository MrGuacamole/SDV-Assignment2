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
    public partial class frmCategory : Form
    {
        public frmCategory()
        {
            InitializeComponent();
        }

        private static Dictionary<string, frmCategory> _CategoryFormList = new Dictionary<string, frmCategory>();
        private clsCategory _Category;

        public static void Run(string prCategoryName)
        {
            frmCategory lcCategoryForm;
            if (string.IsNullOrEmpty(prCategoryName) ||
            !_CategoryFormList.TryGetValue(prCategoryName, out lcCategoryForm))
            {
                lcCategoryForm = new frmCategory();
                if (string.IsNullOrEmpty(prCategoryName))
                {
                    lcCategoryForm.SetDetails(new clsCategory());
                    //lcCategoryForm.UpdateDisplay(prCategoryName);
                }
                else
                {
                    _CategoryFormList.Add(prCategoryName, lcCategoryForm);
                    lcCategoryForm.refreshFormFromDBAsync(prCategoryName);
                    lcCategoryForm.Text = prCategoryName;
                    lcCategoryForm.Show();

                    // lcCategoryForm.UpdateDisplay(prCategoryName);
                }
            }
            else
            {
                lcCategoryForm.Show();
                lcCategoryForm.Activate();
            }
        }

        private async void UpdateDisplay(clsCategory prCategory)
        {
            lstInstruments.DataSource = null;
            if (prCategory.InstrumentList != null)
                lstInstruments.DataSource = prCategory.InstrumentList;
        }

        private async void refreshFormFromDBAsync(string prCategoryName)
        {
            SetDetails(await clsServiceClient.GetCategoryInstrumentsAsync(prCategoryName));
        }

        private void SetDetails(clsCategory prCategoryName)
        {
            _Category = prCategoryName;
            
            UpdateDisplay(_Category);
            lblCategory.Text = _Category.Name;
            lblDescription.Text = _Category.Description;

            //txtName.Enabled = string.IsNullOrEmpty(_Category.Name); ;
            //updateForm();
            Show();
        }

        

        private void pushData()
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
    
            Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            string lcReply;
            InputBox inputBox = new InputBox("Enter New for New Instrument, Used for Used Instrument");
            if (inputBox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lcReply = (inputBox.getAnswer());

                if (!string.IsNullOrEmpty(lcReply)) // not cancelled?
                {
                    clsAllInstrument lcInstrument = clsAllInstrument.CheckType(lcReply);
                    if (lcInstrument != null) // valid instrument created?
                    {

                        //lcInstrument.ArtistName = _Artist.Name;
                        frmInstrument.DispatchInstrumentForm(lcInstrument, _Category.Name);

                        refreshFormFromDBAsync(_Category.Name);
                        frmMain.Instance.UpdateDisplay();
                    }
                }
            }
        }
        





                //char lcReply;
                //InputBox inputBox = new InputBox("Enter New for New Instrument, Used for Used Instrument");
                ////inputBox.ShowDialog();
                ////if (inputBox.getAction() == true)
                //if (inputBox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                //{
                //    lcReply = Convert.ToChar(inputBox.getAnswer());
                //    //_WorksList.AddWork(lcReply);
                //}

                //else
                //{
                //    inputBox.Close();
                //}
                //frmMain.Instance.UpdateDisplay();

            



        private void lstInstruments_DoubleClick(object sender, EventArgs e)
        {
            frmInstrument.DispatchInstrumentForm(lstInstruments.SelectedItem as clsAllInstrument, _Category.Name);
            refreshFormFromDBAsync(_Category.Name);
        }

        private async void btnDelete_ClickAsync(object sender, EventArgs e)
        {
            if (lstInstruments.SelectedIndex > -1)
            {
                DialogResult result = MessageBox.Show("Are you sure?", "Deleting instrument", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show(await clsServiceClient.DeleteInstrumentAsync(lstInstruments.SelectedItem as clsAllInstrument));
                    refreshFormFromDBAsync(_Category.Name);
                    frmMain.Instance.UpdateDisplay();
                }

            }
            else
            {
                MessageBox.Show("Unable to Delete, No Work Selected");
            }

            frmMain.Instance.UpdateDisplay();
        }
    }
}

