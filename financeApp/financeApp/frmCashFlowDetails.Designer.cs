﻿namespace financeApp
{
    partial class frmCashFlowDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.msCashFlowDetails = new System.Windows.Forms.MenuStrip();
            this.cashFlowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAndCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearFieldsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteFlowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ssCashFlowStatus = new System.Windows.Forms.StatusStrip();
            this.tsslFlowStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtCashFlowName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCashFlowAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbCashFlowType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCashFlowDate = new System.Windows.Forms.TextBox();
            this.txtCashFlowDueDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.msCashFlowDetails.SuspendLayout();
            this.ssCashFlowStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // msCashFlowDetails
            // 
            this.msCashFlowDetails.AllowMerge = false;
            this.msCashFlowDetails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cashFlowToolStripMenuItem});
            this.msCashFlowDetails.Location = new System.Drawing.Point(0, 0);
            this.msCashFlowDetails.Name = "msCashFlowDetails";
            this.msCashFlowDetails.Size = new System.Drawing.Size(482, 24);
            this.msCashFlowDetails.TabIndex = 0;
            this.msCashFlowDetails.Text = "menuStrip1";
            // 
            // cashFlowToolStripMenuItem
            // 
            this.cashFlowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAndCloseToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.clearFieldsToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteFlowToolStripMenuItem});
            this.cashFlowToolStripMenuItem.Name = "cashFlowToolStripMenuItem";
            this.cashFlowToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.cashFlowToolStripMenuItem.Text = "Cash Flow";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAndCloseToolStripMenuItem
            // 
            this.saveAndCloseToolStripMenuItem.Name = "saveAndCloseToolStripMenuItem";
            this.saveAndCloseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAndCloseToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.saveAndCloseToolStripMenuItem.Text = "Save and Close";
            this.saveAndCloseToolStripMenuItem.Click += new System.EventHandler(this.saveAndCloseToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // clearFieldsToolStripMenuItem
            // 
            this.clearFieldsToolStripMenuItem.Name = "clearFieldsToolStripMenuItem";
            this.clearFieldsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.clearFieldsToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.clearFieldsToolStripMenuItem.Text = "Clear Fields";
            this.clearFieldsToolStripMenuItem.Click += new System.EventHandler(this.clearFieldsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(222, 6);
            // 
            // deleteFlowToolStripMenuItem
            // 
            this.deleteFlowToolStripMenuItem.Name = "deleteFlowToolStripMenuItem";
            this.deleteFlowToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.deleteFlowToolStripMenuItem.Text = "Delete Flow";
            this.deleteFlowToolStripMenuItem.Click += new System.EventHandler(this.deleteFlowToolStripMenuItem_Click);
            // 
            // ssCashFlowStatus
            // 
            this.ssCashFlowStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslFlowStatus});
            this.ssCashFlowStatus.Location = new System.Drawing.Point(0, 313);
            this.ssCashFlowStatus.Name = "ssCashFlowStatus";
            this.ssCashFlowStatus.Size = new System.Drawing.Size(482, 22);
            this.ssCashFlowStatus.SizingGrip = false;
            this.ssCashFlowStatus.TabIndex = 2;
            this.ssCashFlowStatus.Text = "statusStrip1";
            // 
            // tsslFlowStatus
            // 
            this.tsslFlowStatus.Name = "tsslFlowStatus";
            this.tsslFlowStatus.Size = new System.Drawing.Size(436, 17);
            this.tsslFlowStatus.Spring = true;
            this.tsslFlowStatus.Text = "[status]";
            this.tsslFlowStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCashFlowName
            // 
            this.txtCashFlowName.Location = new System.Drawing.Point(110, 49);
            this.txtCashFlowName.Name = "txtCashFlowName";
            this.txtCashFlowName.Size = new System.Drawing.Size(149, 20);
            this.txtCashFlowName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Flow Name:";
            // 
            // txtCashFlowAmount
            // 
            this.txtCashFlowAmount.Location = new System.Drawing.Point(110, 75);
            this.txtCashFlowAmount.Name = "txtCashFlowAmount";
            this.txtCashFlowAmount.Size = new System.Drawing.Size(149, 20);
            this.txtCashFlowAmount.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Amount:";
            // 
            // cbCashFlowType
            // 
            this.cbCashFlowType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCashFlowType.FormattingEnabled = true;
            this.cbCashFlowType.Location = new System.Drawing.Point(110, 102);
            this.cbCashFlowType.Name = "cbCashFlowType";
            this.cbCashFlowType.Size = new System.Drawing.Size(149, 21);
            this.cbCashFlowType.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Type:";
            // 
            // txtCashFlowDate
            // 
            this.txtCashFlowDate.Location = new System.Drawing.Point(110, 129);
            this.txtCashFlowDate.Name = "txtCashFlowDate";
            this.txtCashFlowDate.Size = new System.Drawing.Size(149, 20);
            this.txtCashFlowDate.TabIndex = 9;
            // 
            // txtCashFlowDueDate
            // 
            this.txtCashFlowDueDate.Location = new System.Drawing.Point(110, 155);
            this.txtCashFlowDueDate.Name = "txtCashFlowDueDate";
            this.txtCashFlowDueDate.Size = new System.Drawing.Size(149, 20);
            this.txtCashFlowDueDate.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Transaction Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Due Date:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(69, 223);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(153, 223);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(234, 223);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(265, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "(mm/dd/yyyy)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(265, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "(mm/dd/yyyy)";
            // 
            // frmCashFlowDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 335);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCashFlowDueDate);
            this.Controls.Add(this.txtCashFlowDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbCashFlowType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCashFlowAmount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCashFlowName);
            this.Controls.Add(this.ssCashFlowStatus);
            this.Controls.Add(this.msCashFlowDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.msCashFlowDetails;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCashFlowDetails";
            this.ShowInTaskbar = false;
            this.Text = "frmCashFlowDetails";
            this.Load += new System.EventHandler(this.frmCashFlowDetails_Load);
            this.msCashFlowDetails.ResumeLayout(false);
            this.msCashFlowDetails.PerformLayout();
            this.ssCashFlowStatus.ResumeLayout(false);
            this.ssCashFlowStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msCashFlowDetails;
        private System.Windows.Forms.StatusStrip ssCashFlowStatus;
        private System.Windows.Forms.ToolStripStatusLabel tsslFlowStatus;
        private System.Windows.Forms.ToolStripMenuItem cashFlowToolStripMenuItem;
        private System.Windows.Forms.TextBox txtCashFlowName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCashFlowAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbCashFlowType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCashFlowDate;
        private System.Windows.Forms.TextBox txtCashFlowDueDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem deleteFlowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem saveAndCloseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ToolStripMenuItem clearFieldsToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}