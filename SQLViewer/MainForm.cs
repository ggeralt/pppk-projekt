using SQLViewer.DAL;
using SQLViewer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace SQLViewer
{
    public partial class MainForm : Form
    {
        private const string FileFilter = "XML files(*.xml)|*.xml|All files(*.*)|*.*";
        private const string FileName = "{0}.xml";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cbDatabases.DataSource = new List<Database>(RepositoryFactory.GetRepository().GetDatabases());
        }

        private void CbDatabases_SelectedIndexChanged(object sender, EventArgs e)
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

        private void LbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbTableColumns.DataSource = (lbTables.SelectedItem as DatabaseEntity).Columns;
        }

        private void LbViews_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbViewColumns.DataSource = (lbViews.SelectedItem as DatabaseEntity).Columns;
        }

        private void LbProcedures_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbProcedureDefinitions.Text = (lbProcedures.SelectedItem as Procedure).Definition;
            lbProcedureParameters.DataSource = (lbProcedures.SelectedItem as Procedure).ProcedureParameters;
        }

        private void BtnOpenQueryExecutionForm_Click(object sender, EventArgs e)
        {
            new QueryExecutionForm().Show();
        }

        private void BtnXMLClick(object sender, EventArgs e)
        {
            DatabaseEntity databaseEntity;

            switch ((sender as Button).Name)
            {
                case nameof(btnXMLTable):
                    databaseEntity = lbTables.SelectedItem as DatabaseEntity;
                    break;
                case nameof(btnXMLView):
                    databaseEntity = lbViews.SelectedItem as DatabaseEntity;
                    break;
                default:
                    throw new Exception("Error");
            }

            var dialog = new SaveFileDialog()
            {
                FileName = string.Format(FileName, databaseEntity.Name),
                Filter = FileFilter
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                DataSet dataSet = RepositoryFactory.GetRepository().CreateDataSet(databaseEntity);
                dataSet.WriteXml(dialog.FileName, XmlWriteMode.WriteSchema);
            }
        }

        private void BtnSelectClick(object sender, EventArgs e)
        {
            DatabaseEntity databaseEntity;

            switch ((sender as Button).Name)
            {
                case nameof(btnSelectTable):
                    databaseEntity = lbTables.SelectedItem as DatabaseEntity;
                    break;
                case nameof(btnSelectView):
                    databaseEntity = lbViews.SelectedItem as DatabaseEntity;
                    break;
                default:
                    throw new Exception("Error");
            }

            DataSet dataSet = RepositoryFactory.GetRepository().CreateDataSet(databaseEntity);
            new SelectForm(dataSet.Tables[0]).ShowDialog();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
