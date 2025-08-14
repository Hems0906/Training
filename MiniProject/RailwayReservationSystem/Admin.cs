using System.Data.SqlClient;
using System;


public class Admin
{
    private DatabaseManager dbManager = new DatabaseManager();

    public bool ValidateAdmin(string username, string password)
    {
        string query = "SELECT AdminID FROM Admins WHERE Username = @Username AND Password = @Password";
        SqlParameter[] parameters = {
            new SqlParameter("@Username", username),
            new SqlParameter("@Password", password)
        };
        return dbManager.ExecuteScalar(query, parameters) != null;
    }
}
