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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(common.getMainForm().rememberMeToken) && getAccountId(common.getMainForm().rememberMeToken) != null)
            {
                common.getMainForm().loadedAccount = common.getAccountFromDatabase((int)getAccountId(common.getMainForm().rememberMeToken));
                this.Close();
            }

            common.getMainForm().loadedTheme.themePositiveButton(this.btnLogin);
            this.Text = "Welcome!";
            this.AcceptButton = btnLogin;
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            /* If we close the login form without logging in,
             * close the main form as well, and close the application*/
            if (common.getMainForm().loadedAccount == null)
            {
                common.getMainForm().Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (isValidLogin(txtUsername.Text, txtPassword.Text))
            {
                common.getMainForm().loadedAccount = common.getAccountFromDatabase(getAccountId(txtUsername.Text, txtPassword.Text));

                if (chkRememberMe.Checked)
                {
                    common.getMainForm().rememberMeToken = common.getRememberMeToken(common.getMainForm().loadedAccount.id);
                }
                else
                {
                    common.getMainForm().rememberMeToken = null;
                }

                this.Close();
            }
            else
            {
                using (frmMessageBox messageBox = new frmMessageBox())
                {
                    common.setFormFontSize(messageBox, common.getMainForm().loadedFontSize);
                    common.getMainForm().loadedTheme.themeForm(messageBox);
                    messageBox.show("Invalid Username or Password!", "Login Failed", MessageBoxButtons.OK);
                }
                txtPassword.Clear();
            }


        }

        private void llblCreateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (frmAccountCreation accountCreationForm = new frmAccountCreation())
            {
                common.setFormFontSize(accountCreationForm, common.getMainForm().loadedFontSize);
                common.getMainForm().loadedTheme.themeForm(accountCreationForm);
                accountCreationForm.ShowDialog();
            }
        }

        /// <summary>
        /// Runs the passed user/pass combo against the database
        /// returns a boolean if it exists
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool isValidLogin(string username, string password)
        {
            database.sqlStatement sql = new database.sqlStatement();
            sql.connectionString = database.getConnectString();

            sql.query = "SELECT DISTINCT COUNT(ua.id) " +
                        "FROM bmw_user_account ua " +
                        "WHERE ua.username = @username " +
                        "AND ua.password = @password";

            sql.queryParameters.Add("@username", username);
            sql.queryParameters.Add("@password", password);

            if (int.Parse(database.executeScalarOnDatabase(sql).ToString()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int getAccountId(string username, string password)
        {
            database.sqlStatement sql = new database.sqlStatement();
            sql.connectionString = database.getConnectString();

            sql.query = "SELECT DISTINCT ua.id " +
                        "FROM bmw_user_account ua " +
                        "WHERE ua.username = @username " +
                        "AND ua.password = @password";

            sql.queryParameters.Add("@username", username);
            sql.queryParameters.Add("@password", password);


            return int.Parse(database.executeScalarOnDatabase(sql).ToString());
        }

        private int? getAccountId(string rememberMeToken)
        {
            database.sqlStatement sql = new database.sqlStatement();
            sql.connectionString = database.getConnectString();

            sql.query = "SELECT DISTINCT ua.id " +
                        "FROM bmw_user_account ua " +
                        "WHERE SHA1(CONCAT(ua.id, ua.username)) = @token"; 

            sql.queryParameters.Add("@token", rememberMeToken);

            if (database.executeScalarOnDatabase(sql) == null)
            {
                return null;
            } else
            {
                return int.Parse(database.executeScalarOnDatabase(sql).ToString());
            }
        }

        /// <summary>
        /// Intercepts the pressing of the [esc] key, and closes the form
        /// This allows us to close the dialog by pressincg [esc]
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }

            return base.ProcessDialogKey(keyData);
        }

    }
}
