using SalaryCalculator.Base;

namespace SalaryCalculator.Models
{
    public class FixedRateEmployee : Employee
    {
        /// <summary>
        /// Create and set up employees fixed rate
        /// </summary>
        /// <param name="rate"></param>
        public FixedRateEmployee(string name, decimal rate)
            : base(name,rate)
        {

        }

        /// <summary>
        /// Calculate employees salary for fixed rate
        /// </summary>
        /// <returns>Salary employee</returns>
        public override decimal CalculateSalary()
        {
            return Rate;
        }
    }
}
