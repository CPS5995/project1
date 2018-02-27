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
    public partial class frmProfileDetails : Form
    {
        public frmProfileDetails()
        {
            InitializeComponent();
        }

        private userAccount loadedAccount;

        private void frmProfileDetails_Load(object sender, EventArgs e)
        {

        }


        public void loadAccountIntoForm(userAccount accountToLoad)
        {
            this.loadedAccount = accountToLoad;
            this.Text = "Profiles for Account: " + loadedAccount.name;

            populateFundingProfileListBox(loadedAccount.profiles);
            lbCashFlows.Items.Clear();

            tsslProfileDetailStatus.Text = "Showing: " + loadedAccount.profiles.Count() + " profiles | " +
                "Total Cash Flows: " + loadedAccount.getAccountCashFlows().Count();
        }

        /// <summary>
        /// Populates the form's "Funding Profiles" list box with the passed profile names
        /// </summary>
        /// <param name="profilesToLoad"></param>
        private void populateFundingProfileListBox(List<fundingProfile> profilesToLoad)
        {
            lbProfiles.Items.Clear();
            foreach (fundingProfile profile in profilesToLoad.OrderBy(x => x.name))
            {
                lbProfiles.Items.Add(profile.name.ToString());
            }
        }


        /// <summary>
        /// Populates the form's "Cash Flow List Box" with the passed flows
        /// </summary>
        /// <param name="cashFlowsToLoad"></param>
        private void populateCashFlowListBox(List<cashFlow> cashFlowsToLoad)
        {
            lbCashFlows.Items.Clear();
            foreach (cashFlow flow in cashFlowsToLoad.OrderBy(x => x.name))
            {
                lbCashFlows.Items.Add(flow.name.ToString());
            }
        }



        private void lbProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(getSelectedProfile() == null))
            {
                populateCashFlowListBox(getSelectedProfile().cashFlows);
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
                    common.addProfileToAccount(common.getMainForm().loadedAccount, new fundingProfile(inputBox.result));
                    loadAccountIntoForm(common.getMainForm().loadedAccount);
                }

            }
        }

        /// <summary>
        /// Returns the Funding Profile currently selected in the listbox
        /// Returns NULL if none is selected
        /// </summary>
        /// <returns></returns>
        private fundingProfile getSelectedProfile()
        {
            if (lbProfiles.SelectedItem == null)
            {
                return null;
            }
            else
            {
                return loadedAccount.profiles.FirstOrDefault(x => x.name == lbProfiles.SelectedItem.ToString());
            }

        }


        private void renameSelectedProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getSelectedProfile() == null)
            {
                MessageBox.Show("No Profile Selected.");
            }
            else
            {
                using (frmInputBox inputBox = new frmInputBox())
                {
                    inputBox.Text = "Rename Profile: [" + getSelectedProfile().name + "]";
                    inputBox.lblMessage.Text = "Enter new profile name:";

                    inputBox.ShowDialog();

                    if (!string.IsNullOrEmpty(inputBox.result))
                    {
                        //rename profile
                        //common.updateProfileOnAccount(common.getMainForm().loadedAccount, new fundingProfile(inputBox.result));
                        loadAccountIntoForm(common.getMainForm().loadedAccount);
                    }

                }
            }
        }


        private void deleteSelectedProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getSelectedProfile() == null)
            {
                MessageBox.Show("No Profile Selected.");
            }
            else
            {
                if (MessageBox.Show("You are about to delete the profile: [" + getSelectedProfile().name + "]"
                                   + "The Profile and ALL of its Cash Flows will be deleted!"
                                   + "Are you sure you want to delete this Profile?",
                                   "Delete Profile?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    common.deleteProfileFromAccount(loadedAccount, getSelectedProfile());
                    loadAccountIntoForm(common.getMainForm().loadedAccount);
                }
            }

        }
    }
}
