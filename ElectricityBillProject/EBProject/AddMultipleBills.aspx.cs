using System;
using System.Data.SqlClient;

namespace EBProject
{
    public partial class AddMultipleBills : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string[] consumerNos = Request.Form.GetValues("ConsumerNo");
            string[] consumerNames = Request.Form.GetValues("ConsumerName");
            string[] unitsArr = Request.Form.GetValues("Units");

            if (consumerNos == null) return;

            try
            {
                string connStr = "Data Source=.;Initial Catalog=EBDB;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();
                    SqlTransaction tran = con.BeginTransaction();

                    for (int i = 0; i < consumerNos.Length; i++)
                    {
                        string cNo = consumerNos[i];
                        string cName = consumerNames[i];
                        int units = int.Parse(unitsArr[i]);
                        decimal amount = units * 5; // Example rate = 5 per unit

                        string query = "INSERT INTO Bills(ConsumerNo, ConsumerName, Units, Amount, BillDate) VALUES(@cno, @cname, @u, @a, GETDATE())";
                        SqlCommand cmd = new SqlCommand(query, con, tran);
                        cmd.Parameters.AddWithValue("@cno", cNo);
                        cmd.Parameters.AddWithValue("@cname", cName);
                        cmd.Parameters.AddWithValue("@u", units);
                        cmd.Parameters.AddWithValue("@a", amount);

                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                }
                lblMsg.Text = " All bills saved successfully!";
            }
            catch (Exception ex)
            {
                lblMsg.Text = " Error: " + ex.Message;
            }
        }
    }
}
