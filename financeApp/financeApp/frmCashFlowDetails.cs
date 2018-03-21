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
    public partial class frmCashFlowDetails : Form
    {
        public frmCashFlowDetails()
        {
            InitializeComponent();
        }

        private userAccount loadedAccount;
        private fundingProfile loadedProfile;
        private cashFlow loadedFlow;

        private void frmCashFlowDetails_Load(object sender, EventArgs e)
        {
            tsslFlowStatus.Text = "";
            loadFlowTypeComboBox();
            if (!(loadedFlow == null))
            {
                this.cbCashFlowType.Text = loadedFlow.flowType.ToString();
            }

        }


        public void loadAccountIntoForm(userAccount accountToLoad)
        {
            this.loadedAccount = accountToLoad;
            this.Text = "Cash Flows for Account: " + loadedAccount.name;
        }

        public void loadProfileIntoForm(fundingProfile profileToLoad)
        {
            this.loadedProfile = profileToLoad;
            tsslFlowStatus.Text = "Loaded Profile: " + loadedProfile.name;
        }

        public void loadCashFlowIntoForm(cashFlow flowToLoad)
        {
            this.loadedFlow = flowToLoad;

            this.txtCashFlowName.Text = flowToLoad.name;
            this.txtCashFlowAmount.Text = flowToLoad.amount.ToString();
            this.txtCashFlowDate.Text = flowToLoad.flowDate.ToShortDateString();
            if (flowToLoad.dueDate != null)
            {
                this.txtCashFlowDueDate.Text = ((DateTime)flowToLoad.dueDate).ToShortDateString();
            }
            else
            {
                this.txtCashFlowDueDate.Text = "";
            }
            this.cbCashFlowType.Text = flowToLoad.flowType.ToString();
        }

        /// <summary>
        ///  populates the Flow Type combo box with the values from the cashFlowType enum
        /// </summary>
        private void loadFlowTypeComboBox()
        {
            cbCashFlowType.Items.Clear();
            foreach (string flowType in Enum.GetNames(typeof(cashFlowType)))
            {
                cbCashFlowType.Items.Add(flowType.ToString());
            }
        }

        /// <summary>
        /// Takes the STRING name of a cashFlowType, and returns the appropriate cashFlowType ENUM
        /// Throws an exception if no ENUM exists for the given string
        /// </summary>
        /// <param name="cashFlowTypeName"></param>
        /// <returns></returns>
        private cashFlowType getCashFlowTypeByName(string cashFlowTypeName)
        {

            foreach (cashFlowType flowType in Enum.GetValues(typeof(cashFlowType)))
            {
                if (Enum.GetName(typeof(cashFlowType), flowType) == cashFlowTypeName)
                {
                    return flowType;
                }
            }

            throw new ArgumentException("No such CashFlowType Exists");
        }

        private void deleteFlowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loadedFlow == null)
            {
                MessageBox.Show("This Cash Flow has not yet been saved (and cannot be deleted).");
            }
            else
            {
                if (MessageBox.Show("You are about to delete the Cash Flow: [" + loadedFlow.name + "]"
                                   + "\r\nfrom the profile: [" + loadedProfile.name + "]"
                                   + "\r\n\r\nThe deleted Flow will be LOST, and cannot be recovered!"
                                   + "\r\n\r\nAre you sure you want to delete this Flow?",
                                   "Delete Cash Flow?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    common.deleteCashFlowFromProfile(loadedProfile, loadedFlow);
                    loadAccountIntoForm(common.getMainForm().loadedAccount);

                    //close the form after deleting the flow
                    MessageBox.Show("Cash Flow Deleted.");
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Pulls the values from the form's textboxes, 
        /// and creates an appropriate Cash Flow Object
        /// </summary>
        /// <returns></returns>
        private cashFlow getCashFlowFromForm()
        {
            int id;
            // if we don't have a loaded flow, get the next flow ID
            if (loadedFlow == null)
            {
                id = common.getNextCashFlowId();
            }
            else
            {
                id = loadedFlow.id;
            }

            return new cashFlow(id, txtCashFlowName.Text, double.Parse(txtCashFlowAmount.Text),
                DateTime.Parse(txtCashFlowDueDate.Text), DateTime.Parse(txtCashFlowDate.Text),
               getCashFlowTypeByName(cbCashFlowType.SelectedItem.ToString()));
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveCashFlow();
        }

        /// <summary>
        /// runs the procedure for saving a cash flow
        /// returns a boolean to indicate if the flow was saved successfully or not.
        /// </summary>
        /// <returns></returns>
        private bool saveCashFlow()
        {
            if (isFormCashFlowValid())
            {
                cashFlow flowToSave = getCashFlowFromForm();

                if (loadedFlow == null)
                {
                    common.addCashFlowToProfile(loadedProfile, flowToSave);
                    loadCashFlowIntoForm(flowToSave);
                }
                else
                {
                    common.updateCashFlowOnAccount(loadedProfile, loadedFlow, flowToSave);
                    loadCashFlowIntoForm(flowToSave);
                }
                return true;
            }
            else
            {
                MessageBox.Show("Unable to save current flow!\r\n" +
                                "Please make sure all fields are properly filled out.",
                                "Error Saving Cash Flow", MessageBoxButtons.OK);
                return false;
            }

        }

        /// <summary>
        /// Validates the data on the form before saving/updating the cash flow.
        /// Returns a bool indicating if the data is valid.
        /// </summary>
        /// <returns></returns>
        private bool isFormCashFlowValid()
        {
            if (common.isDate(txtCashFlowDate.Text) &&
                common.isDate(txtCashFlowDueDate.Text) &&
                common.isNumeric(txtCashFlowAmount.Text) &&
                cbCashFlowType.SelectedItem != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void saveAndCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveCashFlow())
            {
                this.Close();
            }
        }
    }
}
