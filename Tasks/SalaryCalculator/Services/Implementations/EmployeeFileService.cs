using SalaryCalculator.Base;
using SalaryCalculator.Helper;
using System.Collections.Generic;
using System.IO;

namespace SalaryCalculator.Services.Implementations
{
    public class EmployeeFileService : IFileService
    {
        public List<Employee> Employees { get; set; }

        /// <summary>
        /// Initialize employees
        /// </summary>
        /// <param name="employees"></param>
        public EmployeeFileService(List<Employee> employees)
        {
            Employees = employees;
        }

        /// <summary>
        /// Write each employee data to dile
        /// </summary>
        /// <param name="path"></param>
        public void WriteToFile(string path)
        {
            using (TextWriter textWriter = new StreamWriter(path))
            {
                foreach (var employee in Employees)
                {
                    textWriter.WriteLine($"Id : {employee.Id}; Name : {employee.Name}; Salary : {employee.CalculateSalary()}");
                }
            }
        }

        /// <summary>
        /// Read each employee data from file 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string ReadFromFile(string path)
        {
            if (File.Exists(path))
            {
                // Read entire text file content in one string    
                return File.ReadAllText(path);
            }
            else
            {
               // Todo: log file not found exception (use custom logger)
            }

            return string.Empty;
        }
    }
}
