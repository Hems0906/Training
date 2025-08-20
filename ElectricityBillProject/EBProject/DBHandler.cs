using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace ElectricityBillingSystem
{

    public class DBHandler
    {
        private readonly string conStr = ConfigurationManager.ConnectionStrings["EBDB"].ConnectionString;

        public void AddBill(ElectricityBill bill)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = "INSERT INTO Bills (ConsumerNo, ConsumerName, Units, Amount, BillDate) VALUES (@no, @name, @units, @amt, @date)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@no", bill.ConsumerNumber);
                cmd.Parameters.AddWithValue("@name", bill.ConsumerName);
                cmd.Parameters.AddWithValue("@units", bill.UnitsConsumed);
                cmd.Parameters.AddWithValue("@amt", bill.BillAmount);
                cmd.Parameters.AddWithValue("@date", bill.BillDate);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<ElectricityBill> GetLastNBills(int n)
        {
            var list = new List<ElectricityBill>();
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = "SELECT TOP(@n) BillNo, ConsumerNo, ConsumerName, Units, Amount, BillDate FROM Bills ORDER BY BillNo DESC";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@n", n);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new ElectricityBill
                    {
                        BillNo = dr.GetInt32(0),
                        ConsumerNumber = dr.GetString(1),
                        ConsumerName = dr.GetString(2),
                        UnitsConsumed = dr.GetInt32(3),
                        BillAmount = dr.GetDouble(4),
                        BillDate = dr.GetDateTime(5)
                    });
                }
            }
            return list;
        }
      
        public SqlConnection GetConnection()
        {
            string conStr = ConfigurationManager.ConnectionStrings["EBDB"].ConnectionString;
            return new SqlConnection(conStr);
        }

        public bool ValidateLogin(string username, string password)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(*) FROM Admins WHERE Username=@u AND Password=@p", con))
            {
                cmd.Parameters.Add("@u", System.Data.SqlDbType.NVarChar, 50).Value = username;
                cmd.Parameters.Add("@p", System.Data.SqlDbType.NVarChar, 100).Value = password;

                con.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        public bool ConsumerNumberExists(string consumerNo)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(*) FROM Bills WHERE ConsumerNo=@no", con))
            {
                cmd.Parameters.AddWithValue("@no", consumerNo);
                con.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }


    }
}
