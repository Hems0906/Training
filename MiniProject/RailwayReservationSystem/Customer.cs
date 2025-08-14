using System.Data.SqlClient;


public class Customer
{
    private DatabaseManager dbManager = new DatabaseManager();

    public int Register(string custName, string phone, string mailId, string password)
    {
        string query = @"INSERT INTO Customers 
                       (CustName, Phone, MailId, Password) 
                       VALUES 
                       (@CustName, @Phone, @MailId, @Password)";

        SqlParameter[] parameters = {
            new SqlParameter("@CustName", custName),
            new SqlParameter("@Phone", phone),
            new SqlParameter("@MailId", mailId),
            new SqlParameter("@Password", password)
        };

        return dbManager.ExecuteNonQuery(query, parameters);
    }

    public int? ValidateCustomer(string mailId, string password)
    {
        string query = "SELECT CustId FROM Customers WHERE MailId = @MailId AND Password = @Password";
        SqlParameter[] parameters = {
            new SqlParameter("@MailId", mailId),
            new SqlParameter("@Password", password)
        };
        return dbManager.ExecuteScalar(query, parameters) as int?;
    }
}


