using SQLViewer.DAL;
using SQLViewer.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SQLViewer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cbDatabases.DataSource = new List<Database>(RepositoryFactory.GetRepository().GetDatabases());
        }

        private void cbDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clear();
            lbTables.DataSource = (cbDatabases.SelectedItem as Database).Tables;
            lbViews.DataSource = (cbDatabases.SelectedItem as Database).Views;
            lbProcedures.DataSource = (cbDatabases.SelectedItem as Database).Procedures;
            
        }

        private void Clear()
        {
            lbTableColumns.DataSource = null;
            lbViewColumns.DataSource = null;
            lbProcedureParameters.DataSource = null;
            tbProcedureDefinitions.Text = null;
        }

        private void lbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbTableColumns.DataSource = (lbTables.SelectedItem as DatabaseEntity).Columns;
        }

        private void lbViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbViewColumns.DataSource = (lbViews.SelectedItem as DatabaseEntity).Columns;
        }

        private void lbProcedures_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbProcedureDefinitions.Text = (lbProcedures.SelectedItem as Procedure).Definition;
            lbProcedureParameters.DataSource = (lbProcedures.SelectedItem as Procedure).ProcedureParameters;
        }

        private void btnOpenQueryExecutionForm_Click(object sender, EventArgs e)
        {
            new QueryExecutionForm().Show();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
