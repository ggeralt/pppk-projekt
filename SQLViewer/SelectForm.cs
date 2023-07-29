using System.Data;
using System.Windows.Forms;

namespace SQLViewer
{
    public partial class SelectForm : Form
    {
        public SelectForm(DataTable dataTable)
        {
            InitializeComponent();
            Initialize(dataTable);
        }

        private void Initialize(DataTable dataTable)
        {
            Text = dataTable.TableName;
            dataGridView.DataSource = dataTable;
        }
    }
}
