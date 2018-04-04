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
            common.getMainForm().loadedTheme.themePositiveButton(this.btnSubmit);
            this.Text = "New Account Creation";
            this.AcceptButton = btnSubmit;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            using (frmMessageBox messageBox = new frmMessageBox())
            {
                common.setFormFontSize(messageBox, common.getMainForm().loadedFontSize);
                common.getMainForm().loadedTheme.themeForm(messageBox);

                if (common.validateNewPassword(txtPassword.Text, txtConfirmPassword.Text))
                {
                    if (common.validateNewUsername(txtUsername.Text))
                    {
                        common.createNewAccount(
                            new userAccount(common.getNextAccountId(), txtUsername.Text, null),
                            txtPassword.Text);

                        messageBox.show("Your account has been created!", "Account Created", MessageBoxButtons.OK);
                        this.Close();
                    }
                    else
                    {
                        messageBox.show("The username you have chosen is ALREADY in use,\r\nplease choose a different username\r\n",
                            "Invalid Username", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    messageBox.show("Please make sure the password you entered matches the \"confirmed\" password\r\n" +
                        "and that your password is at least EIGHT characters long.", "Invalid Password", MessageBoxButtons.OK);
                }
            }
        }
        
    }
}
