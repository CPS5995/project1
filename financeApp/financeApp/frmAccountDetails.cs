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
            themeButtons();
        }

        public void loadAccountIntoForm(userAccount accountToLoad)
        {
            this.loadedAccount = accountToLoad;
            this.Text = "Details for Account: " + loadedAccount.name;

            populateProfilesListBox(loadedAccount.profiles);

            lblTotals.Text = "Total Profiles: " + loadedAccount.profiles.Count() +
                "\r\n\r\nTotal Cash Flows (income/expenses): " + loadedAccount.getAccountCashFlows().Count() + " (" + loadedAccount.getAllIncomeFlows().Count() + "/" + loadedAccount.getAllExpenseFlows().Count() + ")" +
                "\r\n\r\nTotal Income: " + loadedAccount.getAllIncomeFlows().Sum(x => x.amount).ToString("C") +
                "\r\n\r\nTotal Expenses: " + loadedAccount.getAllExpenseFlows().Sum(x => x.amount).ToString("C");

            tsslAccountStats.Text = "Total Profiles: " + loadedAccount.profiles.Count() + " | Total Cash Flows: " + loadedAccount.getAccountCashFlows().Count();

            txtAccountName.Text = loadedAccount.name;
        }

        public void themeButtons()
        {
            common.getMainForm().loadedTheme.themePositiveButton(this.btnSave);
        }

        private void populateProfilesListBox(List<fundingProfile> profilesToLoad)
        {
            lbProfiles.Items.Clear();
            foreach (fundingProfile profile in profilesToLoad.OrderBy(x => x.name))
            {
                lbProfiles.Items.Add(profile.name);
            }
        }

        private void updateAccount()
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
                common.getMainForm().refreshDataForAllMdiChildren();
            }
            else
            {
                using (frmMessageBox messageBox = new frmMessageBox())
                {
                    common.setFormFontSize(messageBox, common.getMainForm().loadedFontSize);
                    common.getMainForm().loadedTheme.themeForm(messageBox);
                    messageBox.show("The username you have chosen is ALREADY in use,\r\n" +
                                    "please choose a different username\r\n",
                                    "Invalid Username", MessageBoxButtons.OK);
                }
            }
        }

        private void addNewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmInputBox inputBox = new frmInputBox())
            {
                common.setFormFontSize(inputBox, common.getMainForm().loadedFontSize);
                common.getMainForm().loadedTheme.themeForm(inputBox);
                inputBox.Text = "Add Profile";
                inputBox.lblMessage.Text = "Enter new profile name:";

                inputBox.ShowDialog();

                if (!string.IsNullOrEmpty(inputBox.result))
                {
                    common.addProfileToAccount(common.getMainForm().loadedAccount, new fundingProfile(common.getNextProfileId(), inputBox.result));
                    common.getMainForm().refreshDataForAllMdiChildren();
                }

            }
        }

        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmMessageBox messageBox = new frmMessageBox())
            {
                common.setFormFontSize(messageBox, common.getMainForm().loadedFontSize);
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
                        common.setFormFontSize(loginForm, common.getMainForm().loadedFontSize);
                        common.getMainForm().loadedTheme.themeForm(loginForm);
                        loginForm.ShowDialog();
                    }

                }
            }

        }


        private void saveChangesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateAccount();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            updateAccount();
        }
    }
}
