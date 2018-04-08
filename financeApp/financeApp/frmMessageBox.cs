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
    public partial class frmMessageBox : Form
    {
        public frmMessageBox()
        {
            InitializeComponent();
        }

        private DialogResult result;

        private void frmMessageBox_Load(object sender, EventArgs e)
        {
            common.getMainForm().loadedTheme.themeNegativeButton(this.btnNo);
            common.getMainForm().loadedTheme.themePositiveButton(this.btnYes);
            common.getMainForm().loadedTheme.themeNeutralButton(this.btnOk);
        }
       

        public DialogResult show(string text, string caption, MessageBoxButtons buttons)
        {
            this.Text = caption;
            lblMessage.Text = text;
            this.Width = Math.Max(this.Width,lblMessage.Width + 30);
            configureButtons(buttons);
            this.Height = Math.Max(this.Height,btnOk.Location.Y + btnOk.Height + 57);

            this.ShowDialog();
            return this.result;
        }

        private void configureButtons(MessageBoxButtons buttons)
        {
            btnNo.Visible = false;
            btnYes.Visible = false;
            btnOk.Visible = false;

            btnOk.Left = (this.Width / 2) - (btnOk.Width / 2);
            btnYes.Left = (this.Width / 2) - ((btnYes.Width)+20);
            btnNo.Left = (btnYes.Right) + (20);

            btnOk.Top = Math.Max(btnOk.Top,lblMessage.Height + lblMessage.Location.Y + 20);
            btnYes.Top = Math.Max(btnYes.Top, lblMessage.Height + lblMessage.Location.Y + 20);
            btnNo.Top = Math.Max(btnNo.Top, lblMessage.Height + lblMessage.Location.Y + 20);

            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    btnOk.Visible = true;
                    AcceptButton = btnOk;
                    CancelButton = btnOk;
                    break;
                case MessageBoxButtons.YesNo:
                    btnNo.Visible = true;
                    btnYes.Visible = true;
                    AcceptButton = btnYes;
                    CancelButton = btnNo;
                    break;
                default:
                    throw new ArgumentException();
            }
        }


        private void btnYes_Click(object sender, EventArgs e)
        {
            this.result = DialogResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.result = DialogResult.No;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.result = DialogResult.OK;
            this.Close();
        }
    }
}
