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
    public partial class frmAccountCreation : Form
    {
        public frmAccountCreation()
        {
            InitializeComponent();
        }

        private void frmAccountCreation_Load(object sender, EventArgs e)
        {
            this.Text = "New Account Creation";
            this.AcceptButton = btnSubmit;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            if (validateNewPassword(txtPassword.Text, txtConfirmPassword.Text))
            {
                if (validateNewUsername(txtUsername.Text))
                {
                    common.createNewAccount(
                        new userAccount(common.getNextAccountId(), txtUsername.Text, null),
                        txtPassword.Text);

                    MessageBox.Show("Your account has been created!", "Account Created", MessageBoxButtons.OK);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("The username you have chosen is ALREADY in use, please choose a different username\r\n",
                        "Invalid Username", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Please make sure the password you entered matches the \"confirmed\" password " +
                    "and that your password is at least EIGHT characters long.", "Invalid Password", MessageBoxButtons.OK);
            }

        }


        /// <summary>
        /// Checks if the password entered into the form is valid.
        /// A password is valid if it matches the "confirm password",
        /// and is at least eight characters in length
        /// </summary>
        /// <returns></returns>
        private bool validateNewPassword(string password, string confirmPassword)
        {
            if (password != confirmPassword || password.Length < 8)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Validates the username to create.
        /// A username is valid if it is unique, in the sense that
        /// it does NOT already exist in the database.
        /// </summary>
        /// <param name="newUsername"></param>
        /// <returns></returns>
        private bool validateNewUsername(string newUsername)
        {
            database.sqlStatement sql = new database.sqlStatement();
            sql.connectionString = database.getConnectString();

            sql.query = "SELECT DISTINCT COUNT(ua.id) " +
                        "FROM bmw_user_account ua " +
                        "WHERE ua.username = @username ";

            sql.queryParameters.Add("@username", newUsername);

            if (int.Parse(database.executeScalarOnDatabase(sql).ToString()) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
