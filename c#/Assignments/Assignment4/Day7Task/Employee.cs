using System;
using System.Collections.Generic;

   class Employee
   {
    public int EmoployeeId { get; set; }
    public string EmoployeeName { get; set; }
    public string EmoployeeDepartment { get; set; }
    public double EmoployeeSalary { get; set; }

    public override string ToString()
    {
        return $"ID: {EmoployeeId}, Name: {EmoployeeName}, Department: {EmoployeeDepartment}, Salary: {EmoployeeSalary}";
    }
    }

class Program
{
    static List<Employee> employees = new List<Employee>();
    static int nextId = 1;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("===== Employee Management Menu =====");
            Console.WriteLine("Enter 1 to Add New Employee");
            Console.WriteLine("Enter 2 to View All Employees");
            Console.WriteLine("Enter 3 to Search Employee by ID");
            Console.WriteLine("Enter 4 to Update Employee Details");
            Console.WriteLine("Enter 5 to Delete Employee");
            Console.WriteLine("Enter 6 to Exit");
            Console.WriteLine("====================================");
            Console.Write("Enter your choice: ");

            try
            {
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        ViewAllEmployees();
                        break;
                    case 3:
                        SearchEmployeeById();
                        break;
                    case 4:
                        UpdateEmployeeDetails();
                        break;
                    case 5:
                        DeleteEmployee();
                        break;
                    case 6:
                        Console.WriteLine("Exiting the program. Goodbye!");
                      //  Console.Read();
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.Read();
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    static void AddEmployee()
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Department: ");
        string department = Console.ReadLine();
        Console.Write("Enter Salary: ");
        double salary = double.Parse(Console.ReadLine());

        Employee newEmployee = new Employee
        {
            EmoployeeId = nextId++,
            EmoployeeName = name,
            EmoployeeDepartment = department,
            EmoployeeSalary = salary
        };

        employees.Add(newEmployee);
        Console.WriteLine("Employee added successfully.");
    }

    static void ViewAllEmployees()
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees found.");
            return;
        }

        Console.WriteLine("List of Employees:");
        foreach (var employee in employees)
        {
            Console.WriteLine(employee);
        }
    }

    static void SearchEmployeeById()
    {
        Console.Write("Enter Employee ID to search: ");
        int id = int.Parse(Console.ReadLine());

        Employee employee = employees.Find(e => e.EmoployeeId == id);
        if (employee != null)
        {
            Console.WriteLine("Employee found:");
            Console.WriteLine(employee);
        }
        else
        {
            Console.WriteLine("Employee not found.");
        }
    }

    static void UpdateEmployeeDetails()
    {
        Console.Write("Enter Employee ID to update: ");
        int id = int.Parse(Console.ReadLine());

        Employee employee = employees.Find(e => e.EmoployeeId == id);
        if (employee != null)
        {
            Console.Write("Enter new Name (If Empty Current Entry Remains): ");
            string name = Console.ReadLine();
            Console.Write("Enter new Department (If Empty Current Entry Remains): ");
            string department = Console.ReadLine();
            Console.Write("Enter new Salary (If Empty Current Entry Remains): ");
            string salaryInput = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name))
                employee.EmoployeeName = name;
            if (!string.IsNullOrWhiteSpace(department))
                employee.EmoployeeDepartment = department;
            if (double.TryParse(salaryInput, out double salary))
                employee.EmoployeeSalary = salary;

            Console.WriteLine("Employee details updated successfully.");
        }
        else
        {
            Console.WriteLine("Employee not found.");
        }
    }

    static void DeleteEmployee()
    {
        Console.Write("Enter Employee ID to delete: ");
        int id = int.Parse(Console.ReadLine());

        Employee employee = employees.Find(e => e.EmoployeeId == id);
        if (employee != null)
        {
            employees.Remove(employee);
            Console.WriteLine("Employee deleted successfully.");
        }
        else
        {
            Console.WriteLine("Employee not found.");
        }
    }
}
