using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InstrumentShopWinForm
{
   
    public sealed partial class frmNewInstrument : frmInstrument
    {
        public static readonly frmNewInstrument Instance = new frmNewInstrument();
        public frmNewInstrument()
        {
            InitializeComponent();
        }

        public static void Run(clsAllInstrument prInstrument)
        {
            //Instance.Show();
            Instance.SetDetails(prInstrument);
        }

        protected override void UpdateForm()
        {
            base.UpdateForm();
            clsAllInstrument lcInstrument = (clsAllInstrument)_Instrument;
            txtWarrantyPeriod.Text = _Instrument.WarrantyPeriod;
            txtImportDate.Text = Convert.ToString(_Instrument.ImportDate);
        }

        protected override void PushData()
        {
            base.PushData();
            clsAllInstrument lcInstrument = (clsAllInstrument)_Instrument;
            _Instrument.WarrantyPeriod = txtWarrantyPeriod.Text;
            _Instrument.ImportDate = txtImportDate.Text;
        }

    }
}
