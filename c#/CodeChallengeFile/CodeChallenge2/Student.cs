using System;

namespace CodeChallenge2
{
   abstract class Student
    {
        public string Name { get; set; }
        public int StudentId { get; set; }
        public double Grade { get; set; }
        public abstract bool IsPassed(double grade);
    }
    class Undergraduate : Student
    {
        public override bool IsPassed(double grade)
        {
            return grade > 70.0;
        }
    }

    class Graduate : Student
    {
        public override bool IsPassed(double grade)
        {
            return grade > 80.0;
        }
    }

    class Program1
    {
        static void Main()
        {
            Console.WriteLine("Enter Details For UnderGraduate Student");
            Console.WriteLine("---------------------------------");
            Undergraduate undergrad = new Undergraduate();
            Console.Write("Name: ");
            undergrad.Name = Console.ReadLine();
            Console.Write("Student ID: ");
            undergrad.StudentId = int.Parse(Console.ReadLine());
            Console.Write("Grade: ");
            undergrad.Grade = double.Parse(Console.ReadLine());
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Undergraduate Student Passed: {undergrad.IsPassed(undergrad.Grade)}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Enter details for Graduate Student");
            Console.WriteLine("---------------------------------");
            Graduate grad = new Graduate();
            Console.Write("Name: ");
            grad.Name = Console.ReadLine();
            Console.Write("Student ID: ");
            grad.StudentId = int.Parse(Console.ReadLine());
            Console.Write("Grade: ");
            grad.Grade = double.Parse(Console.ReadLine());
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Graduate Student Passed: {grad.IsPassed(grad.Grade)}");
            Console.WriteLine("---------------------------------");
            Console.Read();
        }
    }
}
