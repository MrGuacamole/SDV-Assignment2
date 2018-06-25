using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InstrumentShopWinForm
{
    public partial class InputBox : Form
    {
        private string answer;

        public InputBox(string question)
        {
            InitializeComponent();
            lblQuestion.Text = question;
            lblError.Text = "";
            txtAnswer.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtAnswer.Text == "New" || txtAnswer.Text == "Used") 
            {
                answer = txtAnswer.Text;
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblError.Text = "Please enter the appropriate characters into the text box.";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public string getAnswer()
        {
            return answer;
        }
    }
}