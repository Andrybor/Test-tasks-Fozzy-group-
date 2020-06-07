using SalaryCalculator.Base;
using SalaryCalculator.Extensions;
using SalaryCalculator.Helper;
using SalaryCalculator.Models;
using SalaryCalculator.Services.Implementations;
using System;
using System.Collections.Generic;

namespace SalaryCalculator
{
    class Program
    {
        static void Main(string[] args)
        { 
            // Initialize test employees
            var employees = new List<Employee>(6)
            {
                 new FixedRateEmployee("Alexandr", 1000),
                 new FixedRateEmployee("Misha", 1500),
                 new FixedRateEmployee("Andrii", 500),
                 new HourlyRateEmployee("Liza", 10),
                 new HourlyRateEmployee("Masha", 30),
                 new HourlyRateEmployee("Stefan", 20),
            };

            IFileService service = new EmployeeFileService(employees);

            employees.OrderByRateAndPrintOnConsoleEmployees();
            employees.PrintFirstFiveNamesEmployees();
            employees.PrintLastThreeIds();
           
            service.WriteToFile(Constants.Constants.fileName);
            Console.WriteLine(" Read employees data from file");
            // Print last 3 Id's ordered employees list
            string data = service.ReadFromFile(Constants.Constants.fileName);
            Console.WriteLine(data);

            Console.ReadKey();
        }
    }
}
