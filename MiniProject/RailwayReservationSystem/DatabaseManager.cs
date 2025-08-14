using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

public class DatabaseManager
{
    private string connectionString = "data source=ICS-LT-DZYM473\\SQLEXPRESS;initial catalog=RailwayReservationDB;user id=sa;password=Developer1234";

    public SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }

    public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
    {
        using (SqlConnection con = GetConnection())
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
        }
    }

    public object ExecuteScalar(string query, SqlParameter[] parameters = null)
    {
        using (SqlConnection con = GetConnection())
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteScalar();
            }
        }
    }
    public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
    {
        DataTable dt = new DataTable();
        using (SqlConnection con = GetConnection())
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                try
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
                catch (SqlException ex)
                {
                    // Log full query and parameters
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("SQL Error executing query:");
                    Console.WriteLine(query);
                    if (parameters != null)
                   
                    Console.WriteLine($"Error Message: {ex.Message}");
                    Console.ResetColor();

                    throw;
                }
            }
        }
        return dt;
    }
}
