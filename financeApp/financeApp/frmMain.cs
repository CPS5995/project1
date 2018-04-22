using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace financeApp
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
        }

        /* user settings */
        public userAccount loadedAccount;
        public theme loadedTheme;
        public float loadedFontSize;
        public string rememberMeToken;
        private List<theme> themes = new List<theme>();

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
            loadThemes();
            createThemesToolStripMenu();

            /* if we can't read the settings file, use the defaults*/
            if (!readUserSettingsFromFile())
            {
                this.loadedTheme = themes[0];
                this.loadedFontSize = common.DEFAULT_FONT_SIZE;
                normalToolStripMenuItem.Checked = true;
                rememberMeToken = null;
            }

            foreach (ToolStripMenuItem menuItem in themeToolStripMenuItem.DropDownItems)
            {
                if (menuItem.ToString() == loadedTheme.name)
                {
                    menuItem.Checked = true;
                }
            }

            if (!string.IsNullOrEmpty(this.rememberMeToken))
            {
                rememberMeToolStripMenuItem.Checked = true;
            }

            if (this.loadedFontSize == common.DEFAULT_FONT_SIZE)
            {
                normalToolStripMenuItem.Checked = true;
            }
            else if (this.loadedFontSize == common.LARGE_FONT_SIZE)
            {
                largeToolStripMenuItem.Checked = true;
            }
            else if (this.loadedFontSize == common.HUGE_FONT_SIZE)
            {
                hugeToolStripMenuItem.Checked = true;
            }



            this.loadedTheme.themeForm(this);
            this.Text = common.APPLICATION_NAME;
            this.WindowState = FormWindowState.Maximized;
            tmrTimer.Start();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            /*
            using (frmLogin loginForm = new frmLogin())
            {
                common.setFormFontSize(loginForm, this.loadedFontSize);
                this.loadedTheme.themeForm(loginForm);
                loginForm.ShowDialog();
            }
            */
            showLoginDialog();

            if (!string.IsNullOrEmpty(this.rememberMeToken))
            {
                rememberMeToolStripMenuItem.Checked = true;
            }

            showWelcomeForm();
        }

        private void runReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showReportingForm();
        }

        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            tsslClock.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
        }

        private void accountDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showManageAccountForm();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void manageProfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showManageProfilesForm();
        }


        /// <summary>
        /// Logs the currently loaded Account OUT,
        /// and reverts the App to a pre-login state
        /// </summary>
        public void logOut()
        {
            common.closeAllMdiChildForms(this);
            this.loadedAccount = null;
            this.rememberMeToken = null;
            rememberMeToolStripMenuItem.Checked = false;
        }

        /// <summary>
        /// Loops through all existing MDI Children, and
        /// sets their size and font size
        /// </summary>
        /// <param name="fontSize"></param>
        private void resizeAllMdiChildren(float fontSize)
        {
            foreach (Form mdiChild in this.MdiChildren)
            {
                common.setFormFontSize(mdiChild, fontSize);
            }
        }

        /// <summary>
        /// Closes the current active MDI child window.
        /// If no child windows exist, closes the main window.
        /// </summary>
        private void closeActiveWindow()
        {
            if (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void themeAllForms(theme themeToApply)
        {
            themeToApply.themeForm(this);

            foreach (Form mdiChild in this.MdiChildren)
            {
                themeToApply.themeForm(mdiChild);

                if (mdiChild.Name == "frmAccountDetails")
                {
                    ((frmAccountDetails)mdiChild).themeButtons();
                }

                if (mdiChild.Name == "frmWelcome")
                {
                    ((frmWelcome)mdiChild).themeSideBar();
                }
            }
        }

        /// <summary>
        /// Loads all the potential "themes" into memory
        /// Currently hard coded, but could be read in from a file
        /// </summary>
        private void loadThemes()
        {
            this.themes.Add(new theme("Atomic Black", "#23272E", "#282C34", "#FFFFFF", "#6494ED", "#FFFFFF", "#6494ED", "#73C990", "#FF6347", "#6494ED"));
            this.themes.Add(new theme("Cotton Candy", "#FFD3E8", "#FFE8F3", "#8E1F55", "#6494ED", "#8E1F55", "#6494ED", "#BDE8A2", "#F4CAE0", "#AFE9FF"));
            this.themes.Add(new theme("Muted", "#1C313A", "#455A64", "#F8F9F9", "#709EC9", "#F8F9F8F9", "#6494ED", "#4ECDC4", "#FF7070", "#709EC9"));
            this.themes.Add(new theme("Lite", "#AFC2CB", "#E1F5FE", "#000000", "#709EC9", "#000000", "#6494ED", "#4ECDC4", "#FF7070", "#709EC9"));
            this.themes.Add(new theme("Lenna", "#995461", "#A75E69", "#E1C3B8", "#71315A", "#E1C3B8", "#6494ED", "#71315A", "#BD5660", "#D09882"));
        }

        /// <summary>
        /// Dynamically creates the Theme Selection Menu in the
        /// top level ToolStrip, and adds event handlers to the items
        /// </summary>
        private void createThemesToolStripMenu()
        {
            foreach (theme theme in this.themes.OrderBy(x => x.name))
            {
                themeToolStripMenuItem.DropDownItems.Add(theme.name);
            }

            foreach (ToolStripMenuItem menuItem in themeToolStripMenuItem.DropDownItems)
            {
                menuItem.Click += new EventHandler(themeMenuItemClicked);
                menuItem.CheckOnClick = true;
            }

        }

        /// <summary>
        /// Handles when an item in the themes menu is clicked.
        /// Functions like a radio button (only one can be checked),
        /// then applies the selected theme to the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void themeMenuItemClicked(object sender, EventArgs e)
        {
            ToolStripMenuItem selectedItem = ((ToolStripMenuItem)sender);

            foreach (ToolStripMenuItem menuItem in themeToolStripMenuItem.DropDownItems)
            {
                if (menuItem.ToString() != selectedItem.ToString())
                {
                    menuItem.Checked = false;
                }
                selectedItem.Checked = true;
                this.loadedTheme = this.themes.First(x => x.name == selectedItem.Text);
                themeAllForms(this.loadedTheme);
            }
        }

        /// <summary>
        /// writes the loaded application user settings to
        /// a settings file in the current directory
        /// </summary>
        private void writeUserSettingsToFile()
        {
            string settingsFilePath = @"settings.xml";
            XmlWriterSettings xmlSettings = new XmlWriterSettings();

            xmlSettings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create(settingsFilePath, xmlSettings))
            {
                writer.WriteStartDocument();
                writer.WriteComment("This is the settings file used by the " + common.APPLICATION_NAME + " application.");
                writer.WriteStartElement("settings");
                writer.WriteComment("Interface Font Size");
                writer.WriteElementString("fontSize", this.loadedFontSize.ToString());
                writer.WriteComment("Application Theme");
                writer.WriteElementString("theme", this.loadedTheme.name);
                writer.WriteComment("Remember Me Token");
                writer.WriteElementString("rememberMe", this.rememberMeToken);
                writer.WriteEndElement();
                writer.WriteEndDocument();

                /*System.IO.File.SetAttributes(settingsFilePath, 
                    System.IO.File.GetAttributes(settingsFilePath) | System.IO.FileAttributes.Hidden);*/
            }
        }

        /// <summary>
        /// attempts to read the user settings from a file, and returns a boolean
        /// indicating if the settings were successfully read
        /// </summary>
        /// <returns></returns>
        private bool readUserSettingsFromFile()
        {
            float[] validFontSizes = { common.DEFAULT_FONT_SIZE, common.LARGE_FONT_SIZE, common.HUGE_FONT_SIZE };

            try
            {
                XmlDocument settingsFile = new XmlDocument();
                XmlNode currentNode;

                settingsFile.Load(System.IO.Directory.GetCurrentDirectory() + "\\settings.xml");

                currentNode = settingsFile.SelectSingleNode("/settings/fontSize");
                if (!common.isNumeric(currentNode.InnerText) ||
                    !validFontSizes.Contains(float.Parse(currentNode.InnerText)))
                {
                    this.loadedFontSize = common.DEFAULT_FONT_SIZE;
                }
                else
                {
                    this.loadedFontSize = float.Parse(currentNode.InnerText);
                }

                currentNode = settingsFile.SelectSingleNode("/settings/rememberMe");
                this.rememberMeToken = currentNode.InnerText;

                currentNode = settingsFile.SelectSingleNode("/settings/theme");
                if (this.themes.FirstOrDefault(x => x.name == currentNode.InnerText) != null)
                {
                    this.loadedTheme = this.themes.First(x => x.name == currentNode.InnerText);
                }
                else
                {
                    this.loadedTheme = themes[0];
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void refreshDataForAllMdiChildren()
        {
            foreach (Form mdiChild in this.MdiChildren)
            {
                if (mdiChild.Name == "frmAccountDetails")
                {
                    ((frmAccountDetails)mdiChild).loadAccountIntoForm(this.loadedAccount);
                }

                if (mdiChild.Name == "frmProfileDetails")
                {
                    ((frmProfileDetails)mdiChild).loadAccountIntoForm(this.loadedAccount);
                }

                if (mdiChild.Name == "frmReporting")
                {
                    ((frmReporting)mdiChild).loadAccountIntoForm(this.loadedAccount);
                }
            }
        }

        /// <summary>
        /// spawns a new "About" form, and shows it as a dialog
        /// </summary>
        public void showAboutDialog()
        {
            using (frmAbout aboutForm = new frmAbout())
            {
                common.setFormFontSize(aboutForm, this.loadedFontSize);
                this.loadedTheme.themeForm(aboutForm);
                aboutForm.Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);

                aboutForm.ShowDialog();
            }
        }

        /// <summary>
        /// Spawns a welcome form, and adds it to the Main form's MDI children
        /// If the child already exists, focus it instead
        /// </summary>
        public void showWelcomeForm()
        {
            if (this.MdiChildren.Where(x => x.Name == "frmWelcome").Count() > 0)
            {
                this.MdiChildren.First(x => x.Name == "frmWelcome").Focus();
            }
            else
            {
                frmWelcome welcomeForm = new frmWelcome();
                common.setFormFontSize(welcomeForm, this.loadedFontSize);
                this.loadedTheme.themeForm(welcomeForm);
                welcomeForm.Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
                welcomeForm.Name = "frmWelcome";
                welcomeForm.MdiParent = this;
                welcomeForm.Show();
            }
        }

        /// <summary>
        /// When the user clicks the button spawn the form if the users doesn't already have one
        /// If they do, just focus the existing form.
        /// </summary>
        public void showManageAccountForm()
        {
            if (this.MdiChildren.Where(x => x.Name == "frmAccountDetails").Count() > 0)
            {
                this.MdiChildren.First(x => x.Name == "frmAccountDetails").Focus();
            }
            else
            {
                frmAccountDetails accountViewForm = new frmAccountDetails();
                common.setFormFontSize(accountViewForm, this.loadedFontSize);
                this.loadedTheme.themeForm(accountViewForm);
                accountViewForm.Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
                accountViewForm.Name = "frmAccountDetails";
                accountViewForm.MdiParent = this;
                accountViewForm.loadAccountIntoForm(loadedAccount);
                accountViewForm.Show();
            }
        }

        /// <summary>
        /// As with the Account form, the profle view form is an single instance form
        /// if the user already has an existing instance of the form, just focus that one
        /// </summary>
        public void showManageProfilesForm()
        {
            if (this.MdiChildren.Where(x => x.Name == "frmProfileDetails").Count() > 0)
            {
                this.MdiChildren.First(x => x.Name == "frmProfileDetails").Focus();
            }
            else
            {
                frmProfileDetails profileViewForm = new frmProfileDetails();
                common.setFormFontSize(profileViewForm, this.loadedFontSize);
                this.loadedTheme.themeForm(profileViewForm);
                profileViewForm.Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
                profileViewForm.Name = "frmProfileDetails";
                profileViewForm.MdiParent = this;
                profileViewForm.loadAccountIntoForm(loadedAccount);
                profileViewForm.Show();
            }
        }

        /// <summary>
        /// spawns an instace of the reporting form if none exists
        /// if one DOES exists, focuses the existing form
        /// </summary>
        public void showReportingForm()
        {
            if (this.MdiChildren.Where(x => x.Name == "frmReporting").Count() > 0)
            {
                this.MdiChildren.First(x => x.Name == "frmReporting").Focus();
            }
            else
            {
                frmReporting reportForm = new frmReporting();
                common.setFormFontSize(reportForm, this.loadedFontSize);
                this.loadedTheme.themeForm(reportForm);
                reportForm.Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
                reportForm.Name = "frmReporting";
                reportForm.MdiParent = this;
                reportForm.loadAccountIntoForm(loadedAccount);
                reportForm.Show();
            }
        }

        /// <summary>
        /// Spawns and shows the Log In dialog.
        /// THIS DOES NOT LOG THE USER OUT, it only shows the dialog.
        /// </summary>
        public void showLoginDialog()
        {
            using (frmLogin loginForm = new frmLogin())
            {
                common.setFormFontSize(loginForm, this.loadedFontSize);
                this.loadedTheme.themeForm(loginForm);
                loginForm.Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
                loginForm.ShowDialog();
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmMessageBox messageBox = new frmMessageBox())
            {
                common.setFormFontSize(messageBox, this.loadedFontSize);
                this.loadedTheme.themeForm(messageBox);
                if (messageBox.show("You will be logged out of the Application?\r\nAny unsaved work will be lost."
                + "\r\n\r\n Are you sure you want to log out?",
                "Log Out?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    logOut();
                    showLoginDialog();

                }
            }
        }

        private void windowsToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            loadedTheme.themeMenuStrip(this.msMainMenu);
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            normalToolStripMenuItem.Checked = true;
            largeToolStripMenuItem.Checked = false;
            hugeToolStripMenuItem.Checked = false;

            this.loadedFontSize = common.DEFAULT_FONT_SIZE;
            resizeAllMdiChildren(this.loadedFontSize);
        }

        private void largeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            normalToolStripMenuItem.Checked = false;
            largeToolStripMenuItem.Checked = true;
            hugeToolStripMenuItem.Checked = false;

            this.loadedFontSize = common.LARGE_FONT_SIZE;
            resizeAllMdiChildren(this.loadedFontSize);
        }

        private void hugeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            normalToolStripMenuItem.Checked = false;
            largeToolStripMenuItem.Checked = false;
            hugeToolStripMenuItem.Checked = true;

            this.loadedFontSize = common.HUGE_FONT_SIZE;
            resizeAllMdiChildren(this.loadedFontSize);
        }

        private void closeActiveWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeActiveWindow();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (loadedAccount != null)
            {
                using (frmMessageBox messageBox = new frmMessageBox())
                {
                    common.setFormFontSize(messageBox, this.loadedFontSize);
                    this.loadedTheme.themeForm(messageBox);
                    if (messageBox.show("Are you sure you want to close the application?\r\nAny unsaved work will be lost.", "Close Application?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        e.Cancel = false;

                        if (!rememberMeToolStripMenuItem.Checked)
                        {
                            this.rememberMeToken = null;
                        }
                        else
                        {
                            this.rememberMeToken = common.getRememberMeToken(this.loadedAccount.id);
                        }

                        writeUserSettingsToFile();
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void rememberMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rememberMeToolStripMenuItem.Checked = !rememberMeToolStripMenuItem.Checked;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showAboutDialog();
        }

        private void showStartPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showWelcomeForm();
        }
    }
}
