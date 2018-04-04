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
            common.getMainForm().loadedTheme.themeNegativeButton(this.btnCancel);
            common.getMainForm().loadedTheme.themePositiveButton(this.btnOk);

            configureLayout();

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


        /// <summary>
        /// dynamically sets the location of the buttons on the form
        /// so they're always in the middle of the form, beneath the "message"
        /// regardless of how the form is sized
        /// </summary>
        private void configureLayout()
        {
            lblMessage.Left = (this.Width / 2) - (lblMessage.Width);
            btnOk.Left = (this.Width / 2) - ((btnOk.Width) + 20);
            btnCancel.Left = (btnOk.Right) + (20);

            txtInput.Left = 45;
            txtInput.Width = this.Width - 90;

            btnOk.Top = Math.Max(btnOk.Top, lblMessage.Height + lblMessage.Location.Y + 20);
            btnCancel.Top = Math.Max(btnCancel.Top, lblMessage.Height + lblMessage.Location.Y + 20);
        }
    }
}
