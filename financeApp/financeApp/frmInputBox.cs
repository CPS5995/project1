using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace financeApp
{
    /// <summary>
    /// Class to be used as an Input Dialog box akin to the VB.NET class
    /// Display using ShowDialog and access the "result" value
    /// </summary>
    public partial class frmInputBox : Form
    {
        public frmInputBox()
        {
            InitializeComponent();
        }

        public string result;

        private void frmInputBox_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnOk;
            this.CancelButton = btnCancel;

            this.txtInput.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.result = txtInput.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {
            btnOk.Enabled = !string.IsNullOrEmpty(txtInput.Text);
        }
    }
}
