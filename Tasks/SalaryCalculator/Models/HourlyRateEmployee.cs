using SalaryCalculator.Base;
using SalaryCalculator.Constants;

namespace SalaryCalculator.Models
{
    public class HourlyRateEmployee : Employee
    {
        /// <summary>
        /// Create and set up employees rate
        /// </summary>
        /// <param name="rate"></param>
        public HourlyRateEmployee(string name, decimal rate) 
            : base(name,rate)
        {

        }

        /// <summary>
        /// Calculate employee salary for hourly rate
        /// </summary>
        /// <returns>Salary employee</returns>
        public override decimal CalculateSalary()
        {
            return Constants.Constants.coefficientFirst * Constants.Constants.coefficientSecond * Rate;
        }
    }
}
