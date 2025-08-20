using System;
using System.Data;
using System.Data.SqlClient;

namespace ElectricityBillingSystem
{
    public partial class ViewBills : System.Web.UI.Page
    {
        private string conStr = "data source=ICS-LT-DZYM473\\SQLEXPRESS;initial catalog=EBDB;user id=sa;password=Developer1234";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBills(5); 
            }
        }

        protected void btnFetch_Click(object sender, EventArgs e)
        {
            int n;
            if (!int.TryParse(txtN.Text, out n) || n <= 0)
            {
                litSummary.Text = "<span style='color:red'>Please enter a valid positive number.</span>";
                return;
            }

            LoadBills(n);
        }

        private void LoadBills(int n)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    string query = @"
    SELECT TOP (@n) ConsumerNo, ConsumerName, Units, Amount, BillDate
    FROM Bills
    ORDER BY BillNo DESC";


                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    da.SelectCommand.Parameters.AddWithValue("@n", n);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                    if (dt.Rows.Count > 0)
                    {
                        litSummary.Text = $"<b>{dt.Rows.Count}</b> latest bills retrieved.";
                    }
                    else
                    {
                        litSummary.Text = "<span style='color:orange'>No bills found.</span>";
                    }
                }
            }
            catch (Exception ex)
            {
                litSummary.Text = "<span style='color:red'>Error: " + ex.Message + "</span>";
            }
        }
    }
}
