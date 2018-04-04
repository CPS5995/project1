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
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
        }

        public userAccount loadedAccount;
        public theme loadedTheme;
        public float loadedFontSize;

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.loadedTheme = new theme("default", "#23272E", "#282C34", "#FFFFFF",
                "#6494ED", "#FFFFFF", "#6494ED", "#73C990", "#FF6347", "#6494ED");

            this.loadedFontSize = common.DEFAULT_FONT_SIZE;
            normalToolStripMenuItem.Checked = true;

            this.loadedTheme.themeForm(this);
            this.Text = common.APPLICATION_NAME;
            this.WindowState = FormWindowState.Maximized;
            tmrTimer.Start();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            using (frmLogin loginForm = new frmLogin())
            {
                common.setFormFontSize(loginForm, this.loadedFontSize);
                this.loadedTheme.themeForm(loginForm);
                loginForm.ShowDialog();
            }
        }

        private void runReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReporting reportForm = new frmReporting();
            common.setFormFontSize(reportForm, this.loadedFontSize);
            this.loadedTheme.themeForm(reportForm);
            reportForm.MdiParent = this;
            reportForm.loadAccountIntoForm(loadedAccount);
            reportForm.Show();
        }

        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            tsslClock.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
        }

        private void accountDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* When the user clicks the button spawn the form if the users doesn't already have one
             * If they do, just focus the existing form. */
            if (this.MdiChildren.Where(x => x.Name == "frmAccountDetails").Count() > 0)
            {
                this.MdiChildren.First(x => x.Name == "frmAccountDetails").Focus();
            }
            else
            {
                frmAccountDetails accountViewForm = new frmAccountDetails();
                common.setFormFontSize(accountViewForm, this.loadedFontSize);
                this.loadedTheme.themeForm(accountViewForm);
                accountViewForm.Name = "frmAccountDetails";
                accountViewForm.MdiParent = this;
                accountViewForm.loadAccountIntoForm(loadedAccount);
                accountViewForm.Show();
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmMessageBox messageBox = new frmMessageBox())
            {
                common.setFormFontSize(messageBox, this.loadedFontSize);
                this.loadedTheme.themeForm(messageBox);
                if (messageBox.show("Are you sure you want to close the application?\r\nAny unsaved work will be lost.", "Close Application?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void manageProfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* As with the Account form, the profle view form is an single instance form
             * if the user already has an existing instance of the form, just focus that one */
            if (this.MdiChildren.Where(x => x.Name == "frmProfileDetails").Count() > 0)
            {
                this.MdiChildren.First(x => x.Name == "frmProfileDetails").Focus();
            }
            else
            {
                frmProfileDetails profileViewForm = new frmProfileDetails();
                common.setFormFontSize(profileViewForm, this.loadedFontSize);
                this.loadedTheme.themeForm(profileViewForm);
                profileViewForm.Name = "frmProfileDetails";
                profileViewForm.MdiParent = this;
                profileViewForm.loadAccountIntoForm(loadedAccount);
                profileViewForm.Show();
            }
        }


        /// <summary>
        /// Logs the currently loaded Account OUT,
        /// and reverts the App to a pre-login state
        /// </summary>
        public void logOut()
        {
            common.closeAllMdiChildForms(this);
            this.loadedAccount = null;
        }

        private void resizeAllMdiChildren(float fontSize)
        {

            foreach(Form mdiChild in this.MdiChildren)
            {
                common.setFormFontSize(mdiChild, fontSize);
            }
             
        }


        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmMessageBox messageBox = new frmMessageBox())
            {
                common.setFormFontSize(messageBox, this.loadedFontSize);
                this.loadedTheme.themeForm(messageBox);
                if (messageBox.show("You will be logged out of the Application?\r\nAny unsaved work will be lost."
                + "\r\n\r\n Are you sure you want to log out?",
                "Log Out?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    logOut();
                    using (frmLogin loginForm = new frmLogin())
                    {
                        common.setFormFontSize(loginForm, this.loadedFontSize);
                        this.loadedTheme.themeForm(loginForm);
                        loginForm.ShowDialog();
                    }

                }
            }
        }

        private void windowsToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            loadedTheme.themeMenuStrip(this.msMainMenu);
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            normalToolStripMenuItem.Checked = true;
            largeToolStripMenuItem.Checked = false;
            hugeToolStripMenuItem.Checked = false;

            this.loadedFontSize = common.DEFAULT_FONT_SIZE;
            resizeAllMdiChildren(this.loadedFontSize);
        }

        private void largeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            normalToolStripMenuItem.Checked = false;
            largeToolStripMenuItem.Checked = true;
            hugeToolStripMenuItem.Checked = false;

            this.loadedFontSize = 9.31f;
            resizeAllMdiChildren(this.loadedFontSize);
        }

        private void hugeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            normalToolStripMenuItem.Checked = false;
            largeToolStripMenuItem.Checked = false;
            hugeToolStripMenuItem.Checked = true;

            this.loadedFontSize = 10f;
            resizeAllMdiChildren(this.loadedFontSize);
        }
    }
}
