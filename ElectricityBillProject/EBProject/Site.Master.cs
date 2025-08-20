using System;

namespace ElectricityBillingSystem
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!Request.Url.AbsolutePath.EndsWith("Login.aspx", StringComparison.OrdinalIgnoreCase))
            {
                if (Session["AdminUser"] == null) Response.Redirect("Login.aspx");
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}
