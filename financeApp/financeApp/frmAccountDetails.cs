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
                common.getMainForm().loadedTheme.themeForm(inputBox);
                inputBox.Text = "Add Profile";
                inputBox.lblMessage.Text = "Enter new profile name:";

                inputBox.ShowDialog();

                if (!string.IsNullOrEmpty(inputBox.result))
                {
                    /* TODO: SQL/database stuff */
                    common.addProfileToAccount(common.getMainForm().loadedAccount, new fundingProfile(common.getNextProfileId(), inputBox.result));
                    loadAccountIntoForm(common.getMainForm().loadedAccount);
                }

            }
        }

        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmMessageBox messageBox = new frmMessageBox())
            {
                common.getMainForm().loadedTheme.themeForm(messageBox);

                if (messageBox.show("You are about to DELETE the account [" + loadedAccount.name + "]!\r\n" +
                    "The account and ALL information associated with it will be LOST, and CANNOT be recovered!\r\n\r\n" +
                    "Upon deletion of the account, you will be LOGGED OUT of the application!\r\n\r\n" +
                    "Are you sure you want to DELETE this account?",
                    "Delete Account: [" + loadedAccount.name + "]",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    common.deleteAccount(common.getMainForm().loadedAccount);
                    common.getMainForm().logOut();

                    messageBox.show("Account Deleted Successfully!", "Account Deleted", MessageBoxButtons.OK);

                    using (frmLogin loginForm = new frmLogin())
                    {
                        common.getMainForm().loadedTheme.themeForm(loginForm);
                        loginForm.ShowDialog();
                    }

                }
            }

        }

        private void saveChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string newUsername = txtAccountName.Text;

            if (loadedAccount.name == newUsername)
            {
                /* if the "New" name is the same as the old name, don't do anything */
                return;
            }
            
            if (common.validateNewUsername(newUsername))
            {
                userAccount updatedAccount = new userAccount(loadedAccount.id, newUsername, common.getMainForm().loadedAccount.profiles);
                
                common.updateAccount(common.getMainForm().loadedAccount, updatedAccount);
                common.getMainForm().loadedAccount = updatedAccount;
                loadAccountIntoForm(common.getMainForm().loadedAccount);
            }
            else
            {
                using (frmMessageBox messageBox = new frmMessageBox())
                {
                    common.getMainForm().loadedTheme.themeForm(messageBox);
                    messageBox.show("The username you have chosen is ALREADY in use,\r\n" +
                                    "please choose a different username\r\n",
                                    "Invalid Username", MessageBoxButtons.OK);
                }
            }

        }
    }
}
