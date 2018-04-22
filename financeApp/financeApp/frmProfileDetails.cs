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
                common.getMainForm().loadedTheme.themeForm(inputBox);
                inputBox.Text = "Add Profile";
                inputBox.lblMessage.Text = "Enter new profile name:";

                inputBox.ShowDialog();

                if (inputBox.DialogResult == DialogResult.OK)
                {
                    if (!string.IsNullOrEmpty(inputBox.result) &&
                    !isNewProfileNameDuplicate(this.loadedAccount.profiles, inputBox.result))
                    {
                        common.addProfileToAccount(common.getMainForm().loadedAccount, new fundingProfile(common.getNextProfileId(), inputBox.result));
                        common.getMainForm().refreshDataForAllMdiChildren();
                    }
                    else
                    {
                        using (frmMessageBox messageBox = new frmMessageBox())
                        {
                            common.setFormFontSize(messageBox, common.getMainForm().loadedFontSize);
                            common.getMainForm().loadedTheme.themeForm(messageBox);
                            messageBox.show("You cannot have more than one profile with the same name",
                                "Duplicate Profile Name", MessageBoxButtons.OK);
                        }
                    }
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

        /// <summary>
        /// Gets the Cash Flow currently selected in the Cash Flow Listbox
        /// If none is selected, returns NULL
        /// </summary>
        /// <returns></returns>
        private cashFlow getSelectedCashFlow()
        {
            if (lbCashFlows.SelectedItem == null)
            {
                return null;
            }
            else
            {
                return getSelectedProfile().cashFlows.FirstOrDefault(x => x.name == lbCashFlows.SelectedItem.ToString());
            }

        }



        /// <summary>
        /// Checks if the new profile's name already exists in the given set
        /// </summary>
        /// <param name="profilesToCheck"></param>
        /// <param name="profileName"></param>
        /// <returns></returns>
        private bool isNewProfileNameDuplicate(List<fundingProfile> profilesToCheck, string profileName)
        {
            return profilesToCheck.Where(x => x.name.ToLower() == profileName.ToLower()).Count() > 0;
        }

        /// <summary>
        /// checks if the given profile's name exists in the given set, but excludes
        /// the profile currently being edited
        /// </summary>
        /// <param name="profilesToCheck"></param>
        /// <param name="profileName"></param>
        /// <returns></returns>
        private bool isRenameProfileNameDuplicate(List<fundingProfile> profilesToCheck, string profileName)
        {
            /* exclude the flow we're editing (if any) from the dupe check*/
            return profilesToCheck.Where(x => x.id != getSelectedProfile().id).Where(x => x.name.ToLower() == profileName.ToLower()).Count() > 0;
        }

        private void renameSelectedProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getSelectedProfile() == null)
            {
                using (frmMessageBox messageBox = new frmMessageBox())
                {
                    common.setFormFontSize(messageBox, common.getMainForm().loadedFontSize);
                    common.getMainForm().loadedTheme.themeForm(messageBox);
                    messageBox.show("No Profile Selected.", "No Profile Selected", MessageBoxButtons.OK);
                }
            }
            else
            {
                using (frmInputBox inputBox = new frmInputBox())
                {
                    common.setFormFontSize(inputBox, common.getMainForm().loadedFontSize);
                    common.getMainForm().loadedTheme.themeForm(inputBox);
                    inputBox.Text = "Rename Profile: [" + getSelectedProfile().name + "]";
                    inputBox.lblMessage.Text = "Enter new profile name:";
                    inputBox.txtInput.Text = getSelectedProfile().name;

                    inputBox.ShowDialog();

                    /* i.e. only process if the user said OK */
                    if (inputBox.DialogResult == DialogResult.OK)
                    {
                        if (!string.IsNullOrEmpty(inputBox.result) &&
                            !isRenameProfileNameDuplicate(this.loadedAccount.profiles, inputBox.result))
                        {
                            //rename profile
                            fundingProfile renamedProfile = new fundingProfile(getSelectedProfile().id, inputBox.result, getSelectedProfile().cashFlows);

                            common.updateProfileOnAccount(common.getMainForm().loadedAccount, getSelectedProfile(), renamedProfile);
                            common.getMainForm().refreshDataForAllMdiChildren();
                        }
                        else
                        {
                            using (frmMessageBox messageBox = new frmMessageBox())
                            {
                                common.setFormFontSize(messageBox, common.getMainForm().loadedFontSize);
                                common.getMainForm().loadedTheme.themeForm(messageBox);
                                messageBox.show("You cannot have more than one profile with the same name",
                                    "Duplicate Profile Name", MessageBoxButtons.OK);
                            }
                        }
                    }
                }
            }
        }


        private void deleteSelectedProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmMessageBox messageBox = new frmMessageBox())
            {
                common.setFormFontSize(messageBox, common.getMainForm().loadedFontSize);
                common.getMainForm().loadedTheme.themeForm(messageBox);

                if (getSelectedProfile() == null)
                {
                    messageBox.show("No Profile Selected.", "No Profile Selected", MessageBoxButtons.OK);
                }
                else
                {
                    if (messageBox.show("You are about to delete the profile: [" + getSelectedProfile().name + "]"
                                       + "\r\nThe Profile and ALL of its Cash Flows will be deleted!"
                                       + "\r\n\r\nAre you sure you want to delete this Profile?",
                                       "Delete Profile?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        common.deleteProfileFromAccount(loadedAccount, getSelectedProfile());
                        common.getMainForm().refreshDataForAllMdiChildren();
                    }
                }
            }

        }

        private void addNewCashFlowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getSelectedProfile() == null)
            {
                using (frmMessageBox messageBox = new frmMessageBox())
                {
                    common.setFormFontSize(messageBox, common.getMainForm().loadedFontSize);
                    common.getMainForm().loadedTheme.themeForm(messageBox);
                    messageBox.show("No Profile Selected.", "No Profile Selected", MessageBoxButtons.OK);
                }
            }
            else
            {
                using (frmCashFlowDetails cashFlowForm = new frmCashFlowDetails())
                {
                    common.setFormFontSize(cashFlowForm, common.getMainForm().loadedFontSize);
                    common.getMainForm().loadedTheme.themeForm(cashFlowForm);
                    cashFlowForm.Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    cashFlowForm.loadAccountIntoForm(this.loadedAccount);
                    cashFlowForm.loadProfileIntoForm(getSelectedProfile());

                    cashFlowForm.ShowDialog();
                    common.getMainForm().refreshDataForAllMdiChildren();
                }
            }
        }

        private void deleteSelectedCashFlowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmMessageBox messageBox = new frmMessageBox())
            {
                common.setFormFontSize(messageBox, common.getMainForm().loadedFontSize);
                common.getMainForm().loadedTheme.themeForm(messageBox);

                if (getSelectedProfile() == null || getSelectedCashFlow() == null)
                {
                    messageBox.show("No Cash Flow Selected.", "No Cash Flow Selected", MessageBoxButtons.OK);
                }
                else
                {
                    if (messageBox.show("You are about to delete the Cash Flow: [" + getSelectedCashFlow().name + "]"
                                       + "\r\nfrom the profile: [" + getSelectedProfile().name + "]"
                                       + "\r\n\r\nThe deleted Flow will be LOST, and cannot be recovered!"
                                       + "\r\n\r\nAre you sure you want to delete this Flow?",
                                       "Delete Cash Flow?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        common.deleteCashFlowFromProfile(getSelectedProfile(), getSelectedCashFlow());
                        common.getMainForm().refreshDataForAllMdiChildren();
                    }
                }
            }
        }

        private void viewEditSelectedCashFlowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getSelectedProfile() == null || getSelectedCashFlow() == null)
            {
                using (frmMessageBox messageBox = new frmMessageBox())
                {
                    common.setFormFontSize(messageBox, common.getMainForm().loadedFontSize);
                    common.getMainForm().loadedTheme.themeForm(messageBox);
                    messageBox.show("No Cash Flow Selected.", "No Cash Flow Selected", MessageBoxButtons.OK);
                }
            }
            else
            {
                using (frmCashFlowDetails cashFlowForm = new frmCashFlowDetails())
                {
                    common.setFormFontSize(cashFlowForm, common.getMainForm().loadedFontSize);
                    common.getMainForm().loadedTheme.themeForm(cashFlowForm);
                    cashFlowForm.Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    cashFlowForm.loadAccountIntoForm(this.loadedAccount);
                    cashFlowForm.loadProfileIntoForm(getSelectedProfile());
                    cashFlowForm.loadCashFlowIntoForm(getSelectedCashFlow());

                    cashFlowForm.ShowDialog();
                    common.getMainForm().refreshDataForAllMdiChildren();
                }
            }
        }

        private void importCashFlowsFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (getSelectedProfile() == null)
            {
                using (frmMessageBox messageBox = new frmMessageBox())
                {
                    common.setFormFontSize(messageBox, common.getMainForm().loadedFontSize);
                    common.getMainForm().loadedTheme.themeForm(messageBox);
                    messageBox.show("No Profile Selected.", "No Profile Selected", MessageBoxButtons.OK);
                }
            }
            else
            {
                string importFile = getFileToImport();

                if (!string.IsNullOrEmpty(importFile))
                {
                    try
                    {
                        importCashFlowsIntoProfile(parseCsvIntoDataTable(importFile), getSelectedProfile());
                        using (frmMessageBox messageBox = new frmMessageBox())
                        {
                            common.setFormFontSize(messageBox, common.getMainForm().loadedFontSize);
                            common.getMainForm().loadedTheme.themeForm(messageBox);
                            messageBox.show(parseCsvIntoDataTable(importFile).Rows.Count + " Cash Flows Imported.",
                                "Import Successful", MessageBoxButtons.OK);
                        }
                    }
                    catch (Exception ex)
                    {
                        using (frmMessageBox messageBox = new frmMessageBox())
                        {
                            common.setFormFontSize(messageBox, common.getMainForm().loadedFontSize);
                            common.getMainForm().loadedTheme.themeForm(messageBox);
                            messageBox.show("Cash Flow Import Failed\r\n" +
                                "Please Make sure the file is in the proper format.",
                                "Import Failed", MessageBoxButtons.OK);
                        }
                    }
                    common.getMainForm().refreshDataForAllMdiChildren();
                }
            }
        }

        /// <summary>
        /// displays the system "file selection dialog",
        /// and returns the path to the selected file
        /// </summary>
        /// <returns></returns>
        private string getFileToImport()
        {
            using (OpenFileDialog fileSelector = new OpenFileDialog())
            {
                fileSelector.Multiselect = false;
                fileSelector.Filter = "CSV Files (.csv)|*.csv";
                fileSelector.Title = "Select File to Import.";

                fileSelector.ShowDialog();
                return fileSelector.FileName;
            }
        }

        /// <summary>
        /// parses a CSV file (with headers) into a DataTable, and returns it
        /// </summary>
        /// <param name="csvFilePath"></param>
        /// <returns></returns>
        private DataTable parseCsvIntoDataTable(string csvFilePath)
        {
            using (Microsoft.VisualBasic.FileIO.TextFieldParser parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(csvFilePath))
            {
                parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;

                using (DataTable fileData = new DataTable())
                {
                    while (!parser.EndOfData)
                    {
                        if (parser.LineNumber == 1)
                        {
                            foreach (string field in parser.ReadFields())
                            {
                                fileData.Columns.Add(field);
                            }
                        }
                        else
                        {
                            fileData.Rows.Add(parser.ReadFields());
                        }
                    }
                    return fileData;
                }
            }
        }

        private bool importCashFlowsIntoProfile(DataTable csvData, fundingProfile profileToRecieveFlows)
        {
            List<cashFlow> csvFlows = new List<cashFlow>();

            foreach (DataRow row in csvData.Rows)
            {
                csvFlows.Add(new cashFlow(common.getNextCashFlowId(),
                    row["flow_name"].ToString(),
                    float.Parse(row["amount"].ToString()),
                    DateTime.Parse(row["due_date"].ToString()),
                    DateTime.Parse(row["transaction_date"].ToString()),
                    common.getCashFlowTypeByName(row["flow_type"].ToString())));
            }

            //Database stuff
            database.sqlStatement insertSql = new database.sqlStatement();
            insertSql.connectionString = database.getConnectString();

            insertSql.query = "INSERT INTO bmw_cash_flow " +
                              "(profile_id,flow_name,flow_type,amount,transaction_date,due_date) " +
                              "VALUES "; //+
                                         //"(@id,@profile_id,@flow_name,@flow_type,@amount,@transaction_date,@due_date) ";

            List<string> values = new List<string>();
            foreach (cashFlow flow in csvFlows)
            {

                values.Add("(@profile_id" + csvFlows.IndexOf(flow) + "," +
                    "@flow_name" + csvFlows.IndexOf(flow) + "," +
                    "@flow_type" + csvFlows.IndexOf(flow) + "," +
                    "@amount" + csvFlows.IndexOf(flow) + "," +
                    "@transaction_date" + csvFlows.IndexOf(flow) + "," +
                    "@due_date" + csvFlows.IndexOf(flow) + ") ");

                //insertSql.queryParameters.Add("@id" + csvFlows.IndexOf(flow), flow.id);
                insertSql.queryParameters.Add("@profile_id" + csvFlows.IndexOf(flow), profileToRecieveFlows.id);
                insertSql.queryParameters.Add("@flow_name" + csvFlows.IndexOf(flow), flow.name);
                insertSql.queryParameters.Add("@flow_type" + csvFlows.IndexOf(flow), flow.flowType);
                insertSql.queryParameters.Add("@amount" + csvFlows.IndexOf(flow), flow.amount);
                insertSql.queryParameters.Add("@transaction_date" + csvFlows.IndexOf(flow), flow.flowDate);
                insertSql.queryParameters.Add("@due_date" + csvFlows.IndexOf(flow), flow.dueDate);

            }

            insertSql.query += string.Join(",", values);

            database.executeNonQueryOnDatabase(insertSql);

            profileToRecieveFlows.cashFlows.AddRange(csvFlows);

            return true;
        }


    }
}
