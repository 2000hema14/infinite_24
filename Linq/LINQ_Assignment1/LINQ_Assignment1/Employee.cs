using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement
{
        public class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }

        public void DisplayDetails()
        {
            Console.WriteLine($"Employee ID: {EmployeeID}\nFirst Name: {FirstName}\nLast Name: {LastName}" +
                $"\nTitle: {Title}\nDate of Birth: {DOB.ToShortDateString()}\nDate of Joining: {DOJ.ToShortDateString()}\nCity: {City}\n");

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>
            {
                new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = new DateTime(1984, 11, 16), DOJ = new DateTime(2011, 6, 8), City = "Mumbai" },
                new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = new DateTime(1984, 8, 20), DOJ = new DateTime(2012, 7, 7), City = "Mumbai" },
                new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = new DateTime(1987, 11, 14), DOJ = new DateTime(2015, 4, 12), City = "Pune" },
                new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1990, 6, 3), DOJ = new DateTime(2016, 2, 2), City = "Pune" },
                new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1991, 3, 8), DOJ = new DateTime(2016, 2, 2), City = "Mumbai" },
                new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = new DateTime(1989, 11, 7), DOJ = new DateTime(2014, 8, 8), City = "Chennai" },
                new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = new DateTime(1989, 12, 2), DOJ = new DateTime(2015, 6, 1), City = "Mumbai" },
                new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = new DateTime(1993, 11, 11), DOJ = new DateTime(2014, 11, 6), City = "Chennai" },
                new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = new DateTime(1992, 8, 12), DOJ = new DateTime(2014, 12, 3), City = "Chennai" },
                new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = new DateTime(1991, 4, 12), DOJ = new DateTime(2016, 1, 2), City = "Pune" }
            };

            // 1.Display a list of all the employees who have joined before 1/1/2015
            Console.WriteLine("Employees  joined before 1/1/2015:");
            var joinedBefore2015 = empList.Where(emp => emp.DOJ < new DateTime(2015, 1, 1));
            foreach (var emp in joinedBefore2015)
            {
                emp.DisplayDetails();
            }

            //2. Display a list of all the employees whose date of birth is after 1/1/1990
            Console.WriteLine("Employees whose date of birth is after 1/1/1990:");
            var dobAfter1990 = empList.Where(emp => emp.DOB > new DateTime(1990, 1, 1));
            foreach (var emp in dobAfter1990)
            {
                emp.DisplayDetails();
            }

            //3. Display a list of all the employees whose designation is Consultant or Associate
            Console.WriteLine("Employees whose designation is Consultant or Associate:");
            var consultantOrAssociate = empList.Where(emp => emp.Title == "Consultant" || emp.Title == "Associate");
            foreach (var emp in consultantOrAssociate)
            {
                emp.DisplayDetails();
            }

            // 4.Display total number of employees
            Console.WriteLine($"Total number of employees: {empList.Count}");

            //5. Display total number of employees belonging to "Chennai"
            Console.WriteLine($"Total number of employees belonging to Chennai: {empList.Count(emp => emp.City == "Chennai")}");

            //6. Display highest employee id from the list
            Console.WriteLine($"Highest employee ID: {empList.Max(emp => emp.EmployeeID)}");

            // 7.Display total number of employees who have joined after 1/1/2015
            Console.WriteLine($"Total number of employees  joined after 1/1/2015: {empList.Count(emp => emp.DOJ > new DateTime(2015, 1, 1))}");

            //8. Display total number of employees whose designation is not "Associate"
            Console.WriteLine($"Total number of employees whose designation is not Associate: {empList.Count(emp => emp.Title != "Associate")}");

            //9. Display total number of employees based on City
            var employeesByCity = empList.GroupBy(emp => emp.City).Select(group => new { City = group.Key, Count = group.Count() });
            foreach (var city in employeesByCity)
            {
                Console.WriteLine($"Total number of employees in {city.City}: {city.Count}");
            }

            //10. Display total number of employees based on city and title
            var employeesByCityAndTitle = empList.GroupBy(emp => new { emp.City, emp.Title }).Select(group => new { City = group.Key.City, Title = group.Key.Title, Count = group.Count() });
            foreach (var item in employeesByCityAndTitle)
            {
                Console.WriteLine($"Total number of {item.Title} in {item.City}: {item.Count}");
            }

            // 11.Display total number of employee who is youngest in the list
            var youngestEmployee = empList.OrderBy(emp => emp.DOB).First();
            Console.WriteLine($"Total number of employees who is youngest in the list: {empList.Count(emp => emp.DOB == youngestEmployee.DOB)}");

            Console.ReadKey();
        }
    }
}
