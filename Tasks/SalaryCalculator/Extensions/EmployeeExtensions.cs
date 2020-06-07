using SalaryCalculator.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalaryCalculator.Extensions
{
    public static class EmployeeExtensions
    {
        /// <summary>
        /// Order list of employees by salary and name then print on console
        /// </summary>
        /// <param name="employees"></param>
        public static void OrderByRateAndPrintOnConsoleEmployees(this List<Employee> employees)
        {
            // order employees
            var orderedEmployeesByRateAndName = employees.OrderByDescending(i => i.CalculateSalary()).ThenBy(i => i.Name).ToList();

            // Print ordered employee
            foreach (var employee in orderedEmployeesByRateAndName)
            {
                Console.WriteLine($"Id : {employee.Id}; Name : {employee.Name}; Salary : {employee.CalculateSalary()}");
            }
        }

        /// <summary>
        ///  Print first 5 names ordered employees list
        /// </summary>
        /// <param name="employees"></param>
        public static void PrintFirstFiveNamesEmployees(this List<Employee> employees)
        {
            Console.WriteLine(" Print first 5 names of ordered employee list");
           
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Name : {employees[i].Name}");
            }
        }

        /// <summary>
        /// Print last 3 Id's ordered employees list
        /// </summary>
        /// <param name="employees"></param>
        public static void PrintLastThreeIds(this List<Employee> employees)
        {
            Console.WriteLine(" Print last 3 Id's ordered employees list");

            for (int i = employees.Count - 3; i < employees.Count; i++)
            {
                Console.WriteLine($"Id : {employees[i].Id}");
            }
        }
    }
}
