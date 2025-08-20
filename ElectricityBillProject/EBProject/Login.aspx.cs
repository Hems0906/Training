using System;
using System.Data.SqlClient;

namespace ElectricityBillingSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (Session["AdminUser"] != null) Response.Redirect("Home.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
                {
                    lblMsg.CssClass = "msg-err";
                    lblMsg.Text = "Username and Password are required.";
                    return;
                }

                DBHandler db = new DBHandler();
                bool ok = db.ValidateLogin(txtUser.Text.Trim(), txtPass.Text.Trim());

                if (ok)
                {
                    Session["AdminUser"] = txtUser.Text.Trim();
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    lblMsg.CssClass = "msg-err";
                    lblMsg.Text = "Invalid username or password.";
                }
            }
            catch (Exception ex)
            {
                lblMsg.CssClass = "msg-err";
                lblMsg.Text = "Login failed. Please try again later. " + ex.Message;
            }
        }


    }
}
