using SQLViewer.DAO;
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
            cbDatabases.DataSource = new List<Database>(Repository.GetDatabases());
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
