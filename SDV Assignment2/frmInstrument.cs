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
    public partial class frmInstrument : Form
    {
        public frmInstrument()
        {
            InitializeComponent();
        }

        protected clsAllInstrument _Instrument;

        public delegate void LoadInstrumentFormDelegate(clsAllInstrument prInstrument);
        public static Dictionary<string, Delegate> _InstrumentsForm = new Dictionary<string, Delegate>
        {
            {"New", new LoadInstrumentFormDelegate(frmNewInstrument.Run)},
            {"Used", new LoadInstrumentFormDelegate(frmUsedInstrument.Run)}
        };
        public static void DispatchInstrumentForm(clsAllInstrument prInstrument, string prCategoryName)
        {
            prInstrument.CategoryName = prCategoryName;
            _InstrumentsForm[prInstrument.Type].DynamicInvoke(prInstrument);
        }

        protected virtual void UpdateForm()
        {
            txtName.Enabled = string.IsNullOrEmpty(_Instrument.InstrumentName);

            txtBrand.Text = _Instrument.Brand;
            txtDescription.Text = _Instrument.Description;
            txtModifyTime.Text = Convert.ToString(_Instrument.ModifyTime);
            txtName.Text = _Instrument.InstrumentName;
            nudPrice.Value = Convert.ToDecimal(_Instrument.InstrumentPrice);
            nudQuantity.Value = _Instrument.Quantity;
        }

        public void SetDetails(clsAllInstrument prInstrument)
        {
            _Instrument = prInstrument;
            UpdateForm();
            ShowDialog();
        }

        protected virtual void PushData()
        {
           
                _Instrument.Brand = txtBrand.Text;
                _Instrument.Description = txtDescription.Text;
                _Instrument.InstrumentName = txtName.Text;
                _Instrument.InstrumentPrice = Convert.ToDouble(nudPrice.Value);
                //_Instrument.ModifyTime = Convert.ToDateTime(05/05/2017);
                _Instrument.Quantity = Convert.ToInt16(nudQuantity.Value);
           
          
           
        }

        private  void btnCancel_Click(object sender, EventArgs e)
        {

            Close();
        }

        private async void btnOK_Click(object sender, EventArgs e)
        {
            PushData();
            if (txtName.Enabled & !string.IsNullOrWhiteSpace(txtName.Text))
                
                    if (await clsServiceClient.GetInstrumentName(_Instrument.InstrumentName,_Instrument.Type) == null)
                    {
                        MessageBox.Show(await clsServiceClient.InsertInstrumentAsync(_Instrument));
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Instrument already exists");
                    }

            else
            {
                MessageBox.Show(await clsServiceClient.UpdateInstrumentAsync(_Instrument));
                Close();
            }

        }
    }
}
