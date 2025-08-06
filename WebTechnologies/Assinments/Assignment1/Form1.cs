using System;
using System.Windows.Forms;

namespace LoginPortalApp
{
    public partial class btn : Form
    {
        public btn()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.ShowDialog();

            if (loginForm.IsLoggedIn)
            {
                PortalForm portal = new PortalForm();
                portal.ShowDialog();
            }

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }
    }
}
