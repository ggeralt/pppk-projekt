using SQLViewer.DAL;
using System;
using System.Windows.Forms;

namespace SQLViewer
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnLogIn_Click(object sender, System.EventArgs e)
        {
            try
            {
                RepositoryFactory.GetRepository().LogIn
                (
                    tbServer.Text.Trim(),
                    tbUsername.Text.Trim(),
                    tbPassword.Text.Trim()
                );

                new MainForm().Show();
                Hide();
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }
}
