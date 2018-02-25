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

            tsslProfileDetailStatus.Text = "Showing: " + loadedAccount.profiles.Count() + " profiles | " +
                "Total Cash Flows: " + loadedAccount.getAccountCashFlows().Count();
        }


    }
}
