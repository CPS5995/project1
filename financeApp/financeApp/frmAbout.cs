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
    public partial class frmAbout : Form
    {
        const string PROJECT_URL = "https://github.com/CPS5995/project1";

        public frmAbout()
        {
            InitializeComponent();
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            this.Text = "About '" + common.APPLICATION_NAME + "'";
            lblApplicationName.Text = common.APPLICATION_NAME;
            lblVersion.Text = "Version: " + getApplicationVersion();

            centerAlignLabels();
        }

        private void centerAlignLabels()
        {
            foreach (Label label in common.getChildControls(this).Where(x => x.GetType().Name == "Label" || x.GetType().Name == "LinkLabel"))
            {
                label.Left = (this.Width / 2) - (label.Width / 2);
            }
        }


        private string getApplicationVersion()
        {
            return System.Diagnostics.FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location).FileVersion;
        }

        private void llblContribute_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(PROJECT_URL);
        }
    }
}
