using System;
using System.Windows.Forms;

namespace LoginPortalApp
{
    public partial class LoginForm : Form
    {
        public bool IsLoggedIn { get; private set; } = false;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "admin" && txtPassword.Text == "admin")
            {
                IsLoggedIn = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
            }
        }
    }
}
