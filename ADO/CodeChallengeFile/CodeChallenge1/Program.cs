using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Given Salary: ");
        string salaryInput = Console.ReadLine();
        decimal givenSalary = Convert.ToDecimal(salaryInput);  

        Console.Write("Enter Gender: ");
        string gender = Console.ReadLine();

        SqlConnection con = new SqlConnection("Data Source=ICS-LT-DZYM473\\SQLEXPRESS; Initial Catalog=Assesment; User ID=sa; Password=Developer1234");

        SqlCommand cmd = new SqlCommand("insert_employee", con);

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@name", name));
        cmd.Parameters.Add(new SqlParameter("@givensalary", givenSalary));
        cmd.Parameters.Add(new SqlParameter("@gender", gender));

        SqlParameter p1 = new SqlParameter("@newempid", SqlDbType.Int);
        p1.Direction = ParameterDirection.Output;

        SqlParameter p2 = new SqlParameter("@salary", SqlDbType.Decimal);
        p2.Direction = ParameterDirection.Output;

        SqlParameter p3 = new SqlParameter("@netsalary", SqlDbType.Decimal);
        p3.Direction = ParameterDirection.Output;

        cmd.Parameters.Add(p1);
        cmd.Parameters.Add(p2);
        cmd.Parameters.Add(p3);

        try
        {
            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine();
            Console.WriteLine("Employee inserted successfully!");
            Console.WriteLine("Generated EmpID     : " + p1.Value);
            Console.WriteLine("Calculated Salary   : " + p2.Value);
            Console.WriteLine("Calculated NetSalary: " + p3.Value);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Something went wrong: " + ex.Message);
        }
        finally
        {
            con.Close();
        }

        Console.ReadLine();
    }
}
