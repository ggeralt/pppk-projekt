namespace SQLViewer
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbDatabases = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTables = new System.Windows.Forms.ListBox();
            this.lbTableColumns = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbViewColumns = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbViews = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbProcedureParameters = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbProcedures = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbProcedureDefinitions = new System.Windows.Forms.TextBox();
            this.btnXMLTable = new System.Windows.Forms.Button();
            this.btnSelectTable = new System.Windows.Forms.Button();
            this.btnSelectView = new System.Windows.Forms.Button();
            this.btnXMLView = new System.Windows.Forms.Button();
            this.btnOpenQueryExecutionForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Database";
            // 
            // cbDatabases
            // 
            this.cbDatabases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDatabases.FormattingEnabled = true;
            this.cbDatabases.Location = new System.Drawing.Point(29, 62);
            this.cbDatabases.Name = "cbDatabases";
            this.cbDatabases.Size = new System.Drawing.Size(226, 21);
            this.cbDatabases.TabIndex = 1;
            this.cbDatabases.SelectedIndexChanged += new System.EventHandler(this.CbDatabases_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Table";
            // 
            // lbTables
            // 
            this.lbTables.FormattingEnabled = true;
            this.lbTables.Location = new System.Drawing.Point(29, 129);
            this.lbTables.Name = "lbTables";
            this.lbTables.Size = new System.Drawing.Size(226, 238);
            this.lbTables.TabIndex = 3;
            this.lbTables.SelectedIndexChanged += new System.EventHandler(this.LbTables_SelectedIndexChanged);
            // 
            // lbTableColumns
            // 
            this.lbTableColumns.FormattingEnabled = true;
            this.lbTableColumns.Location = new System.Drawing.Point(348, 129);
            this.lbTableColumns.Name = "lbTableColumns";
            this.lbTableColumns.Size = new System.Drawing.Size(226, 238);
            this.lbTableColumns.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(345, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Table column";
            // 
            // lbViewColumns
            // 
            this.lbViewColumns.FormattingEnabled = true;
            this.lbViewColumns.Location = new System.Drawing.Point(988, 129);
            this.lbViewColumns.Name = "lbViewColumns";
            this.lbViewColumns.Size = new System.Drawing.Size(226, 238);
            this.lbViewColumns.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(985, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "View column";
            // 
            // lbViews
            // 
            this.lbViews.FormattingEnabled = true;
            this.lbViews.Location = new System.Drawing.Point(669, 129);
            this.lbViews.Name = "lbViews";
            this.lbViews.Size = new System.Drawing.Size(226, 238);
            this.lbViews.TabIndex = 7;
            this.lbViews.SelectedIndexChanged += new System.EventHandler(this.LbViews_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(666, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "View";
            // 
            // lbProcedureParameters
            // 
            this.lbProcedureParameters.FormattingEnabled = true;
            this.lbProcedureParameters.Location = new System.Drawing.Point(988, 409);
            this.lbProcedureParameters.Name = "lbProcedureParameters";
            this.lbProcedureParameters.Size = new System.Drawing.Size(226, 238);
            this.lbProcedureParameters.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(985, 393);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Procedure parameter";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(345, 393);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Procedure definition";
            // 
            // lbProcedures
            // 
            this.lbProcedures.FormattingEnabled = true;
            this.lbProcedures.Location = new System.Drawing.Point(29, 409);
            this.lbProcedures.Name = "lbProcedures";
            this.lbProcedures.Size = new System.Drawing.Size(226, 238);
            this.lbProcedures.TabIndex = 11;
            this.lbProcedures.SelectedIndexChanged += new System.EventHandler(this.LbProcedures_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 393);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Procedure";
            // 
            // tbProcedureDefinitions
            // 
            this.tbProcedureDefinitions.Location = new System.Drawing.Point(348, 409);
            this.tbProcedureDefinitions.Multiline = true;
            this.tbProcedureDefinitions.Name = "tbProcedureDefinitions";
            this.tbProcedureDefinitions.Size = new System.Drawing.Size(547, 238);
            this.tbProcedureDefinitions.TabIndex = 18;
            // 
            // btnXMLTable
            // 
            this.btnXMLTable.Location = new System.Drawing.Point(261, 315);
            this.btnXMLTable.Name = "btnXMLTable";
            this.btnXMLTable.Size = new System.Drawing.Size(75, 23);
            this.btnXMLTable.TabIndex = 19;
            this.btnXMLTable.Text = "<-- XML";
            this.btnXMLTable.UseVisualStyleBackColor = true;
            this.btnXMLTable.Click += new System.EventHandler(this.BtnXMLClick);
            // 
            // btnSelectTable
            // 
            this.btnSelectTable.Location = new System.Drawing.Point(261, 344);
            this.btnSelectTable.Name = "btnSelectTable";
            this.btnSelectTable.Size = new System.Drawing.Size(75, 23);
            this.btnSelectTable.TabIndex = 20;
            this.btnSelectTable.Text = "<-- SELECT";
            this.btnSelectTable.UseVisualStyleBackColor = true;
            this.btnSelectTable.Click += new System.EventHandler(this.BtnSelectClick);
            // 
            // btnSelectView
            // 
            this.btnSelectView.Location = new System.Drawing.Point(901, 344);
            this.btnSelectView.Name = "btnSelectView";
            this.btnSelectView.Size = new System.Drawing.Size(75, 23);
            this.btnSelectView.TabIndex = 22;
            this.btnSelectView.Text = "<-- SELECT";
            this.btnSelectView.UseVisualStyleBackColor = true;
            this.btnSelectView.Click += new System.EventHandler(this.BtnSelectClick);
            // 
            // btnXMLView
            // 
            this.btnXMLView.Location = new System.Drawing.Point(901, 315);
            this.btnXMLView.Name = "btnXMLView";
            this.btnXMLView.Size = new System.Drawing.Size(75, 23);
            this.btnXMLView.TabIndex = 21;
            this.btnXMLView.Text = "<-- XML";
            this.btnXMLView.UseVisualStyleBackColor = true;
            this.btnXMLView.Click += new System.EventHandler(this.BtnXMLClick);
            // 
            // btnOpenQueryExecutionForm
            // 
            this.btnOpenQueryExecutionForm.Location = new System.Drawing.Point(988, 60);
            this.btnOpenQueryExecutionForm.Name = "btnOpenQueryExecutionForm";
            this.btnOpenQueryExecutionForm.Size = new System.Drawing.Size(226, 23);
            this.btnOpenQueryExecutionForm.TabIndex = 23;
            this.btnOpenQueryExecutionForm.Text = "QUERY EXECUTION";
            this.btnOpenQueryExecutionForm.UseVisualStyleBackColor = true;
            this.btnOpenQueryExecutionForm.Click += new System.EventHandler(this.BtnOpenQueryExecutionForm_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.btnOpenQueryExecutionForm);
            this.Controls.Add(this.btnSelectView);
            this.Controls.Add(this.btnXMLView);
            this.Controls.Add(this.btnSelectTable);
            this.Controls.Add(this.btnXMLTable);
            this.Controls.Add(this.tbProcedureDefinitions);
            this.Controls.Add(this.lbProcedureParameters);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbProcedures);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbViewColumns);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbViews);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbTableColumns);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbTables);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbDatabases);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQLViewer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDatabases;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbTables;
        private System.Windows.Forms.ListBox lbTableColumns;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbViewColumns;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbViews;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lbProcedureParameters;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lbProcedures;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbProcedureDefinitions;
        private System.Windows.Forms.Button btnXMLTable;
        private System.Windows.Forms.Button btnSelectTable;
        private System.Windows.Forms.Button btnSelectView;
        private System.Windows.Forms.Button btnXMLView;
        private System.Windows.Forms.Button btnOpenQueryExecutionForm;
    }
}