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
        }

        public void loadCashFlowIntoForm(cashFlow flowToLoad)
        {
            this.loadedFlow = flowToLoad;

            this.txtCashFlowName.Text = flowToLoad.name;
            this.txtCashFlowAmount.Text = flowToLoad.amount.ToString();
            this.txtCashFlowDate.Text = flowToLoad.flowDate.ToShortDateString();
            this.txtCashFlowDueDate.Text = flowToLoad.dueDate.ToShortDateString();
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
                if (Enum.GetName(typeof(reporting.reportType), flowType) == cashFlowTypeName)
                {
                    return flowType;
                }
            }

            throw new ArgumentException("No such CashFlowType Exists");
        }

    }
}
