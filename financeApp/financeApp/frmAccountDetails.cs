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
    public partial class frmAccountDetails : Form
    {
        public frmAccountDetails()
        {
            InitializeComponent();
        }

        private userAccount loadedAccount;

        private void frmAccountDetails_Load(object sender, EventArgs e)
        {

        }

        public void loadAccountIntoForm(userAccount accountToLoad)
        {
            this.loadedAccount = accountToLoad;
            this.Text = "Details for Account: " + loadedAccount.name;

            populateProfilesListBox(loadedAccount.profiles);


            tsslAccountStats.Text = "Total Profiles: " + loadedAccount.profiles.Count() + " | Total Cash Flows: " + loadedAccount.getAccountCashFlows().Count();

            txtAccountName.Text = loadedAccount.name;
        }

        private void populateProfilesListBox(List<fundingProfile> profilesToLoad)
        {
            lbProfiles.Items.Clear();
            foreach (fundingProfile profile in profilesToLoad.OrderBy(x => x.name))
            {
                lbProfiles.Items.Add(profile.name);
            }
        }


        private void addNewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmInputBox inputBox = new frmInputBox())
            {
                inputBox.Text = "Add Profile";
                inputBox.lblMessage.Text = "Enter new profile name:";

                inputBox.ShowDialog();

                if (!string.IsNullOrEmpty(inputBox.result))
                {
                    /* TODO: SQL/database stuff */
                    common.addProfileToAccount(common.getMainForm().loadedAccount, new fundingProfile(common.getNextProfileId(),inputBox.result));
                    loadAccountIntoForm(common.getMainForm().loadedAccount);
                }

            }
        }
    }
}
