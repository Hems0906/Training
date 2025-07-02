using System;

namespace Assignment5
{
    public class Scholarship
    {
        public decimal Merit(int marks, decimal fees)
        {
            if (marks < 0 || fees < 0)
                throw new ArgumentException("Marks and fees must be non-negative.");

            if (marks >= 70 && marks <= 80)
                return fees * 0.20m;
            else if (marks > 80 && marks <= 90)
                return fees * 0.30m;
            else if (marks > 90)
                return fees * 0.50m;
            else
                throw new Exception("No scholarship applicable for the given marks.");
        }
    }
    public class Program2
    {
        public static void Main()
        {
            try
            {
                Console.Write("Enter marks: ");
                int marks = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter fees: ");
                decimal fees = Convert.ToDecimal(Console.ReadLine());

                Scholarship scholarship = new Scholarship();
                decimal amount = scholarship.Merit(marks, fees);
                Console.WriteLine("Scholarship Amount: " + amount);

                Console.Read();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter valid numbers for marks and fees.");
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
            }
        }
    }
}
