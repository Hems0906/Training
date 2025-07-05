//1.) 
//Write a query that returns list of numbers and their squares only if square is greater than 20 

//Example input [7, 2, 30]
//Expected output
//→ 7 - 49, 30 - 900


//2.)

//Write a query that returns words starting with letter 'a' and ending with letter 'm'.


//Expected input and output
//"mum", "amsterdam", "bloom" → "amsterdam"


//3.	Create a list of employees with following property EmpId, EmpName, EmpCity, EmpSalary. Populate some data
//Write a program for following requirement
//a.	To display all employees data
//b.	To display all employees data whose salary is greater than 45000
//c.	To display all employees data who belong to Bangalore Region
//d.	To display all employees data by their names is Ascending order

//4.    Create a class library with a function CalculateConcession()  that takes age as an input and calculates concession for travel as below:
//If age <= 5 then “Little Champs - Free Ticket” should be displayed
//If age > 60 then calculate 30% concession on the totalfare(Which is a constant Eg:500 / -) and Display “ Senior Citizen” + Calculated Fare
//Else “Print Ticket Booked” + Fare. 
//Create a Console application with a Class called Program which has TotalFare as Constant, Name, Age.  Accept Name, Age from the user and call the CalculateConcession() function to test the Classlibrary functionality


using System;
using System.Linq;
using System.Collections.Generic;

namespace Assingnment7

{
    class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCity { get; set; }
        public double EmpSalary { get; set; }
    }

    class Program
    {
        const double TotalFare = 500;

        static void Main()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("===== MENU =====");
                Console.WriteLine("1. Numbers & Squares > 20");
                Console.WriteLine("2. Words starting with 'a' and ending with 'm'");
                Console.WriteLine("3. Employee Data Queries");
                Console.WriteLine("4. Travel Concession");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        SquareQuery();
                        break;
                    case "2":
                        WordQuery();
                        break;
                    case "3":
                        EmployeeQuery();
                        break;
                    case "4":
                        TravelConcession();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        static void SquareQuery()
        {
            Console.Write("Enter Numbers Separated By Commas (e.g:- 7,2,30): ");
            string[] input = Console.ReadLine().Split(',');
            List<int> numbers = input.Select(x => int.Parse(x.Trim())).ToList();

            var result = numbers
                .Select(n => new { Number = n, Square = n * n })
                .Where(x => x.Square > 20);

            Console.WriteLine("Numbers and Squares > 20:");
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Number} - {item.Square}");
            }
        }

        static void WordQuery()
        {
            Console.Write("Enter words separated by commas (e.g:- Apple,mango,Amalgum): ");
            string[] words = Console.ReadLine().Split(',');

            var result = words
                .Where(w => w.Trim().StartsWith("a") && w.Trim().EndsWith("m"));

            Console.WriteLine("Matching words:");
            foreach (var word in result)
            {
                Console.WriteLine(word.Trim());
            }
        }

        static void EmployeeQuery()
        {
            Console.Write("How many employees do you want to add? ");
            int count = Convert.ToInt32(Console.ReadLine());
            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Enter details for Employee {i + 1}:");
                Console.Write("EmpId: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("City: ");
                string city = Console.ReadLine();
                Console.Write("Salary: ");
                double salary = Convert.ToDouble(Console.ReadLine());

                employees.Add(new Employee { EmpId = id, EmpName = name, EmpCity = city, EmpSalary = salary });
            }

            Console.WriteLine("All Employees:");
            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.EmpId} - {emp.EmpName} - {emp.EmpCity} - {emp.EmpSalary}");
            }

            Console.WriteLine("Employees with salary > 45000:");
            var highSalary = employees.Where(e => e.EmpSalary > 45000);
            foreach (var emp in highSalary)
            {
                Console.WriteLine($"{emp.EmpName} - {emp.EmpSalary}");
            }

            Console.WriteLine("Employees from Bangalore:");
            var bangaloreEmps = employees.Where(e => e.EmpCity.Trim().ToLower() == "bangalore");

            foreach (var emp in bangaloreEmps)
            {
                Console.WriteLine($"{emp.EmpName} - {emp.EmpCity}");
            }

            Console.WriteLine("Employees sorted by name:");
            var sorted = employees.OrderBy(e => e.EmpName);
            foreach (var emp in sorted)
            {
                Console.WriteLine(emp.EmpName);
            }
        }

        static void TravelConcession()
        {
            Console.Write("Enter your Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your Age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            string result = CalculateConcession(age);

            Console.WriteLine($"Hello {name}!");
            Console.WriteLine(result);
        }

        static string CalculateConcession(int age)
        {
            if (age <= 5)
            {
                return "Little Champs - Free Ticket";
            }
            else if (age > 60)
            {
                double discountedFare = TotalFare * 0.7;
                return $"Senior Citizen - Fare after 30% discount: {discountedFare}";
            }
            else
            {
                return $"Ticket Booked - Fare: {TotalFare}";
            }
        }
    }

}
