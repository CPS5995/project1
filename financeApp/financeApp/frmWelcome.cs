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
    public partial class frmWelcome : Form
    {
        public frmWelcome()
        {
            InitializeComponent();
        }

        private void frmWelcome_Load(object sender, EventArgs e)
        {
            this.Text = "Welcome to '" + common.APPLICATION_NAME + "'";
            this.AcceptButton = btnClose;
            this.CancelButton = btnClose;


            lblHeader.Text = "Welcome to '" + common.APPLICATION_NAME + "'";
            themeSideBar();
        }

        /// <summary>
        /// applies additional form specific theming not covered by the generic themer
        /// </summary>
        public void themeSideBar()
        {
            pnlLeft.BackColor = common.getMainForm().loadedTheme.accentColor;
            
            foreach (Label label in common.getChildControls(pnlLeft).Where(x => x.GetType().Name == "Label" || x.GetType().Name == "LinkLabel"))
            {
                label.BackColor = common.getMainForm().loadedTheme.accentColor;
            }
        }

        /// <summary>
        /// Overrides the processing of keys for the form.
        /// Allows us to close the form on [esc] or [enter]
        /// 
        /// Needed, as pressing [enter] with a link label selected would open that link
        /// instead of pressing the close button. We ALWAYS want [esc] and [enter] to 
        /// close the welcome form.
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }

            if (Form.ModifierKeys == Keys.None && keyData == Keys.Enter)
            {
                this.Close();
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llblAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            common.getMainForm().showAboutDialog();
        }

        private void llblViewAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            common.getMainForm().showManageAccountForm();
        }

        private void llblViewProfiles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            common.getMainForm().showManageProfilesForm();
        }

        private void llblRunReports_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            common.getMainForm().showReportingForm();
        }
    }
}
