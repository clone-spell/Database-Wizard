namespace Database_Wizard
{
    partial class Edit_fSettings
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
            this.dgvWelkin = new System.Windows.Forms.DataGridView();
            this.cbDatabase = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblfSettings = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblRcptno = new System.Windows.Forms.Label();
            this.lblReceiptPrinter = new System.Windows.Forms.Label();
            this.lblCashAcceptor = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWelkin)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvWelkin
            // 
            this.dgvWelkin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvWelkin.BackgroundColor = System.Drawing.Color.White;
            this.dgvWelkin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvWelkin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWelkin.Location = new System.Drawing.Point(12, 71);
            this.dgvWelkin.Name = "dgvWelkin";
            this.dgvWelkin.Size = new System.Drawing.Size(760, 129);
            this.dgvWelkin.TabIndex = 0;
            this.dgvWelkin.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWelkin_CellValueChanged);
            // 
            // cbDatabase
            // 
            this.cbDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDatabase.FormattingEnabled = true;
            this.cbDatabase.Items.AddRange(new object[] {
            "WelkinATP",
            "BWelkinATP"});
            this.cbDatabase.Location = new System.Drawing.Point(516, 16);
            this.cbDatabase.Name = "cbDatabase";
            this.cbDatabase.Size = new System.Drawing.Size(166, 21);
            this.cbDatabase.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.lblfSettings);
            this.panel1.Controls.Add(this.cbDatabase);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnGenerate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 52);
            this.panel1.TabIndex = 5;
            // 
            // lblfSettings
            // 
            this.lblfSettings.AutoSize = true;
            this.lblfSettings.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfSettings.ForeColor = System.Drawing.Color.White;
            this.lblfSettings.Location = new System.Drawing.Point(16, 14);
            this.lblfSettings.Name = "lblfSettings";
            this.lblfSettings.Size = new System.Drawing.Size(91, 25);
            this.lblfSettings.TabIndex = 0;
            this.lblfSettings.Text = "fSettings";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(449, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Database :";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerate.Location = new System.Drawing.Point(688, 15);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Last Receipt Number :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Receipt Printer Port :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Cash Acceptor Port :";
            // 
            // lblRcptno
            // 
            this.lblRcptno.AutoSize = true;
            this.lblRcptno.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRcptno.Location = new System.Drawing.Point(177, 43);
            this.lblRcptno.Name = "lblRcptno";
            this.lblRcptno.Size = new System.Drawing.Size(0, 17);
            this.lblRcptno.TabIndex = 6;
            // 
            // lblReceiptPrinter
            // 
            this.lblReceiptPrinter.AutoSize = true;
            this.lblReceiptPrinter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiptPrinter.Location = new System.Drawing.Point(177, 74);
            this.lblReceiptPrinter.Name = "lblReceiptPrinter";
            this.lblReceiptPrinter.Size = new System.Drawing.Size(0, 17);
            this.lblReceiptPrinter.TabIndex = 6;
            // 
            // lblCashAcceptor
            // 
            this.lblCashAcceptor.AutoSize = true;
            this.lblCashAcceptor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashAcceptor.Location = new System.Drawing.Point(177, 105);
            this.lblCashAcceptor.Name = "lblCashAcceptor";
            this.lblCashAcceptor.Size = new System.Drawing.Size(0, 17);
            this.lblCashAcceptor.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblCashAcceptor);
            this.groupBox1.Controls.Add(this.lblRcptno);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblReceiptPrinter);
            this.groupBox1.Location = new System.Drawing.Point(249, 281);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(287, 166);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data";
            // 
            // Edit_fSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 537);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvWelkin);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(784, 537);
            this.Name = "Edit_fSettings";
            this.Text = "Edit_fSettings";
            ((System.ComponentModel.ISupportInitialize)(this.dgvWelkin)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvWelkin;
        private System.Windows.Forms.ComboBox cbDatabase;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblfSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblRcptno;
        private System.Windows.Forms.Label lblReceiptPrinter;
        private System.Windows.Forms.Label lblCashAcceptor;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}