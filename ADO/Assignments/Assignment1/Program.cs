using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employeeHelper = new Employee();

            List<Employee> employees = new List<Employee>
            {
                new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = DateTime.Parse("1984-11-16"), DOJ = DateTime.Parse("2011-6-8"), City = "Mumbai"},
                new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = DateTime.Parse("1994-08-20"), DOJ = DateTime.Parse("2012-07-07"), City = "Mumbai" },
                new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = DateTime.Parse("1987-11-14"), DOJ = DateTime.Parse("2015-04-12"), City = "Pune" },
                new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("1990-06-03"), DOJ = DateTime.Parse("2016-02-02"), City = "Pune" },
                new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("1991-03-08"), DOJ = DateTime.Parse("2016-02-02"), City = "Mumbai" },
                new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = DateTime.Parse("1989-11-07"), DOJ = DateTime.Parse("2014-08-08"), City = "Chennai" },
                new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = DateTime.Parse("1989-12-02"), DOJ = DateTime.Parse("2015-06-01"), City = "Mumbai" },
                new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = DateTime.Parse("1993-11-11"), DOJ = DateTime.Parse("2014-11-06"), City = "Chennai" },
                new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = DateTime.Parse("1992-08-12"), DOJ = DateTime.Parse("2014-12-03"), City = "Chennai" },
                new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = DateTime.Parse("1991-04-12"), DOJ = DateTime.Parse("2016-01-02"), City = "Pune" }
            };

            // 1. Employees who joined before 1/1/2015
            var employeesJoinedBefore2015 = employees.Where(emp => emp.DOJ < new DateTime(2015, 1, 1));
            Console.WriteLine("Employees who joined before 1/1/2015:");
            employeeHelper.DisplayEmployee(employeesJoinedBefore2015);

            // 2. Employees born after 1/1/1990
            var employeesBornAfter1990 = employees.Where(emp => emp.DOB > new DateTime(1990, 1, 1));
            Console.WriteLine("Employees born after 1/1/1990:");
            employeeHelper.DisplayEmployee(employeesBornAfter1990);

            // 3. Consultants and Associates
            var consultantsAndAssociates = employees.Where(emp => emp.Title == "Consultant" || emp.Title == "Associate");
            Console.WriteLine("Employees who are Consultants or Associates:");
            employeeHelper.DisplayEmployee(consultantsAndAssociates);

            // 4. Total number of employees
            int totalEmployees = employees.Count;
            Console.WriteLine($"Total number of employees: {totalEmployees}");

            // 5. Employees from Chennai
            int chennaiEmployeesCount = employees.Count(emp => emp.City == "Chennai");
            Console.WriteLine($"Total number of employees from Chennai: {chennaiEmployeesCount}");

            // 6. Highest Employee ID
            int highestEmployeeId = employees.Max(emp => emp.EmployeeID);
            Console.WriteLine($"Highest Employee ID: {highestEmployeeId}");

            // 7. Employees joined after 1/1/2015
            int joinedAfter2015Count = employees.Count(emp => emp.DOJ > new DateTime(2015, 1, 1));
            Console.WriteLine($"Employees who joined after 1/1/2015: {joinedAfter2015Count}");

            // 8. Employees not titled as Associate
            int notAssociateCount = employees.Count(emp => emp.Title != "Associate");
            Console.WriteLine($"Employees not titled as Associate: {notAssociateCount}");

            // 9. Employee count by city
            var employeesByCity = employees.GroupBy(emp => emp.City)
                                           .Select(group => new { City = group.Key, Count = group.Count() });
            Console.WriteLine("Employee count by City:");
            foreach (var cityGroup in employeesByCity)
            {
                Console.WriteLine($"{cityGroup.City}: {cityGroup.Count}");
            }

            // 10. Employee count by city and title
            var employeesByCityAndTitle = employees.GroupBy(emp => new { emp.City, emp.Title })
                                                   .Select(group => new { group.Key.City, group.Key.Title, Count = group.Count() });
            Console.WriteLine("Employee count by City and Title:");
            foreach (var group in employeesByCityAndTitle)
            {
                Console.WriteLine($"{group.City}, {group.Title}: {group.Count}");
            }

            // 11. Youngest employee(s)
            DateTime maxDob = employees.Max(emp => emp.DOB);
            var youngestEmployees = employees.Where(emp => emp.DOB == maxDob);
            Console.WriteLine("Details of the youngest employee(s):");
            employeeHelper.DisplayEmployee(youngestEmployees);

            Console.Read();
        }
    }

    class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }

        public void DisplayEmployee(IEnumerable<Employee> employeeList)
        {
            foreach (var emp in employeeList)
            {
                Console.WriteLine($"Employee ID: {emp.EmployeeID}, Name: {emp.FirstName} {emp.LastName}, Title: {emp.Title}, DOB: {emp.DOB:dd-MM-yyyy}, DOJ: {emp.DOJ:dd-MM-yyyy}, City: {emp.City}");
            }
        }
    }
}
