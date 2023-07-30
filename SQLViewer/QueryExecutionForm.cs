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

        private void BtnExecute_Click(object sender, EventArgs e)
        {
            tbResult.Controls.Clear();
            tbMessage.Controls.Clear();

            TextBox textBox = new TextBox();

            textBox.Width = tbResult.Width;
            textBox.Height = tbResult.Height;
            textBox.Enabled = false;

            try
            {
                string query = $"USE {cbDatabases.SelectedItem}" + "\n" + tbQuery.Text.Trim();
                DataGrid dataGrid = new DataGrid();
                DataSet dataSet = RepositoryFactory.GetRepository().Execute(query);

                foreach (DataTable dataTable in dataSet.Tables)
                {
                    dataGrid.DataSource = dataTable;
                    dataGrid.Height = tbResult.Height;
                    dataGrid.Width = tbResult.Width;
                    tbResult.Controls.Add(dataGrid);
                    textBox.Text = $"{dataTable.Rows.Count} rows affected. Completion time: {DateTime.Now}";
                    tbMessage.Controls.Add(textBox);
                    tcResult.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                textBox.Text = ex.Message;
                tbMessage.Controls.Add(textBox);
                tcResult.SelectedIndex = 1;
            }
        }
    }
}
