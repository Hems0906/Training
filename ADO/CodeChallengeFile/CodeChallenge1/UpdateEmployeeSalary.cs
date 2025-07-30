using System;
using System.Data;
using System.Data.SqlClient;

class UpdateEmployeeSalary
{
    static void Main()
    {
        Console.Write("Enter Employee ID to update salary: ");
        int empid = Convert.ToInt32(Console.ReadLine());

        SqlConnection con = new SqlConnection("Data Source=ICS-LT-DZYM473\\SQLEXPRESS; Initial Catalog=Assesment; User ID=sa; Password=Developer1234");

        SqlCommand cmd = new SqlCommand("update_employee_salary", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.Add(new SqlParameter("@empid", empid));

        SqlParameter p1 = new SqlParameter("@updatedsalary", SqlDbType.Decimal);
        p1.Direction = ParameterDirection.Output;

        SqlParameter p2 = new SqlParameter("@updatednetsalary", SqlDbType.Decimal);
        p2.Direction = ParameterDirection.Output;

        cmd.Parameters.Add(p1);
        cmd.Parameters.Add(p2);

        try
        {
            con.Open();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Salary updated successfully!");
            Console.WriteLine("Updated Given Salary : " + p1.Value);
            Console.WriteLine("Updated Net Salary   : " + p2.Value);

            SqlCommand showCmd = new SqlCommand($"SELECT * FROM employee_details WHERE empid = {empid}", con);
            SqlDataReader reader = showCmd.ExecuteReader();

            Console.WriteLine("Updated Employee Details:");
            while (reader.Read())
            {
                Console.WriteLine($"EmpID      : {reader["empid"]}");
                Console.WriteLine($"Name       : {reader["name"]}");
                Console.WriteLine($"GivenSalary: {reader["givensalary"]}");
                Console.WriteLine($"Salary     : {reader["salary"]}");
                Console.WriteLine($"NetSalary  : {reader["netsalary"]}");
                Console.WriteLine($"Gender     : {reader["gender"]}");
            }

            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(" Error: " + ex.Message);
        }
        finally
        {
            con.Close();
        }

        Console.ReadLine();
    }
}
