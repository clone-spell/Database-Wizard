namespace Database_Wizard
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.sqlServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startDatabasesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopSQLServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databasesSQLServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.servicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeFSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.daywiseTransactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateReceiptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nonPostedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceEngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customQueryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bootTimeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.punchTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSystemInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelFrag = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.panelFrag.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sqlServerToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsInfoToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(784, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // sqlServerToolStripMenuItem
            // 
            this.sqlServerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startDatabasesToolStripMenuItem,
            this.stopSQLServerToolStripMenuItem,
            this.databasesSQLServerToolStripMenuItem,
            this.changePassToolStripMenuItem,
            this.servicesToolStripMenuItem});
            this.sqlServerToolStripMenuItem.Name = "sqlServerToolStripMenuItem";
            this.sqlServerToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.sqlServerToolStripMenuItem.Text = "SQL Server";
            // 
            // startDatabasesToolStripMenuItem
            // 
            this.startDatabasesToolStripMenuItem.Name = "startDatabasesToolStripMenuItem";
            this.startDatabasesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.startDatabasesToolStripMenuItem.Text = "Start";
            this.startDatabasesToolStripMenuItem.Click += new System.EventHandler(this.startDatabasesToolStripMenuItem_Click);
            // 
            // stopSQLServerToolStripMenuItem
            // 
            this.stopSQLServerToolStripMenuItem.Name = "stopSQLServerToolStripMenuItem";
            this.stopSQLServerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stopSQLServerToolStripMenuItem.Text = "Stop";
            this.stopSQLServerToolStripMenuItem.Click += new System.EventHandler(this.stopSQLServerToolStripMenuItem_Click);
            // 
            // databasesSQLServerToolStripMenuItem
            // 
            this.databasesSQLServerToolStripMenuItem.Name = "databasesSQLServerToolStripMenuItem";
            this.databasesSQLServerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.databasesSQLServerToolStripMenuItem.Text = "Databases";
            this.databasesSQLServerToolStripMenuItem.Click += new System.EventHandler(this.databasesSQLServerToolStripMenuItem_Click);
            // 
            // changePassToolStripMenuItem
            // 
            this.changePassToolStripMenuItem.Name = "changePassToolStripMenuItem";
            this.changePassToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.changePassToolStripMenuItem.Text = "Change Password";
            this.changePassToolStripMenuItem.Click += new System.EventHandler(this.changePassToolStripMenuItem_Click);
            // 
            // servicesToolStripMenuItem
            // 
            this.servicesToolStripMenuItem.Name = "servicesToolStripMenuItem";
            this.servicesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.servicesToolStripMenuItem.Text = "Services";
            this.servicesToolStripMenuItem.Click += new System.EventHandler(this.servicesToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeFSettingsToolStripMenuItem,
            this.updateTransactionsToolStripMenuItem,
            this.serviceEngToolStripMenuItem,
            this.userToolStripMenuItem,
            this.customQueryToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // changeFSettingsToolStripMenuItem
            // 
            this.changeFSettingsToolStripMenuItem.Name = "changeFSettingsToolStripMenuItem";
            this.changeFSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.changeFSettingsToolStripMenuItem.Text = "fSettings";
            this.changeFSettingsToolStripMenuItem.Click += new System.EventHandler(this.changeFSettingsToolStripMenuItem_Click);
            // 
            // updateTransactionsToolStripMenuItem
            // 
            this.updateTransactionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.daywiseTransactionsToolStripMenuItem,
            this.duplicateReceiptToolStripMenuItem,
            this.nonPostedToolStripMenuItem});
            this.updateTransactionsToolStripMenuItem.Name = "updateTransactionsToolStripMenuItem";
            this.updateTransactionsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.updateTransactionsToolStripMenuItem.Text = "Transactions";
            // 
            // daywiseTransactionsToolStripMenuItem
            // 
            this.daywiseTransactionsToolStripMenuItem.Name = "daywiseTransactionsToolStripMenuItem";
            this.daywiseTransactionsToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.daywiseTransactionsToolStripMenuItem.Text = "Daywise";
            this.daywiseTransactionsToolStripMenuItem.Click += new System.EventHandler(this.daywiseTransactionsToolStripMenuItem_Click);
            // 
            // duplicateReceiptToolStripMenuItem
            // 
            this.duplicateReceiptToolStripMenuItem.Name = "duplicateReceiptToolStripMenuItem";
            this.duplicateReceiptToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.duplicateReceiptToolStripMenuItem.Text = "Duplicate";
            this.duplicateReceiptToolStripMenuItem.Click += new System.EventHandler(this.duplicateReceiptToolStripMenuItem_Click);
            // 
            // nonPostedToolStripMenuItem
            // 
            this.nonPostedToolStripMenuItem.Name = "nonPostedToolStripMenuItem";
            this.nonPostedToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.nonPostedToolStripMenuItem.Text = "Non Posted";
            this.nonPostedToolStripMenuItem.Click += new System.EventHandler(this.nonPostedToolStripMenuItem_Click);
            // 
            // serviceEngToolStripMenuItem
            // 
            this.serviceEngToolStripMenuItem.Name = "serviceEngToolStripMenuItem";
            this.serviceEngToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.serviceEngToolStripMenuItem.Text = "ServiceEng";
            this.serviceEngToolStripMenuItem.Click += new System.EventHandler(this.serviceEngToolStripMenuItem_Click);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.userToolStripMenuItem.Text = "User";
            this.userToolStripMenuItem.Click += new System.EventHandler(this.userToolStripMenuItem_Click);
            // 
            // customQueryToolStripMenuItem
            // 
            this.customQueryToolStripMenuItem.Name = "customQueryToolStripMenuItem";
            this.customQueryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.customQueryToolStripMenuItem.Text = "Custom Query";
            this.customQueryToolStripMenuItem.Click += new System.EventHandler(this.customQueryToolStripMenuItem_Click);
            // 
            // toolsInfoToolStripMenuItem
            // 
            this.toolsInfoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bootTimeToolStripMenuItem1,
            this.punchTimeToolStripMenuItem,
            this.showSystemInfoToolStripMenuItem});
            this.toolsInfoToolStripMenuItem.Enabled = false;
            this.toolsInfoToolStripMenuItem.Name = "toolsInfoToolStripMenuItem";
            this.toolsInfoToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsInfoToolStripMenuItem.Text = "Tools";
            // 
            // bootTimeToolStripMenuItem1
            // 
            this.bootTimeToolStripMenuItem1.Name = "bootTimeToolStripMenuItem1";
            this.bootTimeToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.bootTimeToolStripMenuItem1.Text = "Boot Time";
            // 
            // punchTimeToolStripMenuItem
            // 
            this.punchTimeToolStripMenuItem.Name = "punchTimeToolStripMenuItem";
            this.punchTimeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.punchTimeToolStripMenuItem.Text = "Punch Time";
            // 
            // showSystemInfoToolStripMenuItem
            // 
            this.showSystemInfoToolStripMenuItem.Name = "showSystemInfoToolStripMenuItem";
            this.showSystemInfoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showSystemInfoToolStripMenuItem.Text = "Show System Info";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // panelFrag
            // 
            this.panelFrag.BackColor = System.Drawing.Color.White;
            this.panelFrag.Controls.Add(this.label1);
            this.panelFrag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFrag.Location = new System.Drawing.Point(0, 24);
            this.panelFrag.Margin = new System.Windows.Forms.Padding(0);
            this.panelFrag.Name = "panelFrag";
            this.panelFrag.Size = new System.Drawing.Size(784, 537);
            this.panelFrag.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(168, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(448, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "WELCOME TO DATABASE WIZARD";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panelFrag);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(604, 525);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Database Wizard";
            this.Load += new System.EventHandler(this.Home_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.panelFrag.ResumeLayout(false);
            this.panelFrag.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem sqlServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeFSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateTransactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceEngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customQueryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startDatabasesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopSQLServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databasesSQLServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem servicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showSystemInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bootTimeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem punchTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem daywiseTransactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem duplicateReceiptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nonPostedToolStripMenuItem;
        private System.Windows.Forms.Panel panelFrag;
        private System.Windows.Forms.Label label1;
    }
}

