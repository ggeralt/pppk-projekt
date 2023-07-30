namespace SQLViewer
{
    partial class QueryExecutionForm
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
            this.tcResult = new System.Windows.Forms.TabControl();
            this.tbResult = new System.Windows.Forms.TabPage();
            this.tbMessage = new System.Windows.Forms.TabPage();
            this.btnExecute = new System.Windows.Forms.Button();
            this.tbQuery = new System.Windows.Forms.TextBox();
            this.cbDatabases = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tcResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcResult
            // 
            this.tcResult.Controls.Add(this.tbResult);
            this.tcResult.Controls.Add(this.tbMessage);
            this.tcResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcResult.Location = new System.Drawing.Point(12, 385);
            this.tcResult.Name = "tcResult";
            this.tcResult.SelectedIndex = 0;
            this.tcResult.Size = new System.Drawing.Size(1100, 284);
            this.tcResult.TabIndex = 7;
            // 
            // tbResult
            // 
            this.tbResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbResult.Location = new System.Drawing.Point(4, 22);
            this.tbResult.Name = "tbResult";
            this.tbResult.Padding = new System.Windows.Forms.Padding(3);
            this.tbResult.Size = new System.Drawing.Size(1092, 258);
            this.tbResult.TabIndex = 0;
            this.tbResult.Text = "Result";
            this.tbResult.UseVisualStyleBackColor = true;
            // 
            // tbMessage
            // 
            this.tbMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMessage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbMessage.Location = new System.Drawing.Point(4, 22);
            this.tbMessage.Name = "tbMessage";
            this.tbMessage.Padding = new System.Windows.Forms.Padding(3);
            this.tbMessage.Size = new System.Drawing.Size(1092, 258);
            this.tbMessage.TabIndex = 1;
            this.tbMessage.Text = "Message";
            this.tbMessage.UseVisualStyleBackColor = true;
            // 
            // btnExecute
            // 
            this.btnExecute.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecute.Location = new System.Drawing.Point(1118, 407);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(134, 138);
            this.btnExecute.TabIndex = 6;
            this.btnExecute.Text = "EXECUTE";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.BtnExecute_Click);
            // 
            // tbQuery
            // 
            this.tbQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbQuery.Location = new System.Drawing.Point(12, 133);
            this.tbQuery.Multiline = true;
            this.tbQuery.Name = "tbQuery";
            this.tbQuery.Size = new System.Drawing.Size(1240, 246);
            this.tbQuery.TabIndex = 5;
            // 
            // cbDatabases
            // 
            this.cbDatabases.FormattingEnabled = true;
            this.cbDatabases.Location = new System.Drawing.Point(12, 51);
            this.cbDatabases.Name = "cbDatabases";
            this.cbDatabases.Size = new System.Drawing.Size(199, 21);
            this.cbDatabases.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Database";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Query";
            // 
            // QueryExecutionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tcResult);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.tbQuery);
            this.Controls.Add(this.cbDatabases);
            this.Name = "QueryExecutionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQLViewer - Query Execution";
            this.Load += new System.EventHandler(this.QueryExecutionForm_Load);
            this.tcResult.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcResult;
        private System.Windows.Forms.TabPage tbResult;
        private System.Windows.Forms.TabPage tbMessage;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.TextBox tbQuery;
        private System.Windows.Forms.ComboBox cbDatabases;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}