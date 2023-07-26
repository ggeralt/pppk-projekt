using SQLViewer.DAL;
using SQLViewer.Model;
using System.Collections.Generic;
using System.Data;
using System;
using System.Windows.Forms;

namespace SQLViewer
{
    public partial class QueryExecutionForm : Form
    {
        public QueryExecutionForm()
        {
            InitializeComponent();
        }

        private void QueryExecutionForm_Load(object sender, EventArgs e)
        {
            cbDatabases.DataSource = new List<Database>(RepositoryFactory.GetRepository().GetDatabases());
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            tbResult.Controls.Clear();

            string query = $"USE {cbDatabases.SelectedItem}" + "\n" + tbQuery.Text.Trim();
            DataGrid dataGrid = new DataGrid();

            try
            {
                TextBox textBox = new TextBox();
                textBox.Width = tbResult.Width;
                textBox.Height = tbResult.Height;
                textBox.Enabled = false;

                DataSet dataSet = RepositoryFactory.GetRepository().Execute(query);
                foreach (DataTable dataTable in dataSet.Tables)
                {
                    dataGrid.DataSource = dataTable;
                    dataGrid.Height = tbResult.Height;
                    dataGrid.Width = tbResult.Width;
                    tbResult.Controls.Add(dataGrid);
                    textBox.Text = $"{dataTable.Rows.Count} rows affected \n Completion time: {DateTime.Now}";
                    tbMessage.Controls.Add(textBox);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
