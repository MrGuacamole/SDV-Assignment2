using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InstrumentShopWinForm
{
    public sealed partial class frmUsedInstrument : frmInstrument
    {
        public static readonly frmUsedInstrument Instance = new frmUsedInstrument();
        public frmUsedInstrument()
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
            cbCondition.Text = _Instrument.Condition;
            txtReturnDate.Text = Convert.ToString(_Instrument.DateOfReturn);
        }

        protected override void PushData()
        {
            base.PushData();
            clsAllInstrument lcInstrument = (clsAllInstrument)_Instrument;
            _Instrument.Condition = cbCondition.Text;
            _Instrument.DateOfReturn = txtReturnDate.Text;
        }
    }
}
