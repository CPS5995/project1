﻿using System;
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

            foreach(fundingProfile profile in loadedAccount.profiles)
            {
                lbProfiles.Items.Add(profile.name);
            }

            tsslAccountStats.Text = "Total Profiles: " + loadedAccount.profiles.Count() + " | Total Cash Flows: " + loadedAccount.getAccountCashFlows().Count();

            txtAccountName.Text = loadedAccount.name;
        }




    }
}