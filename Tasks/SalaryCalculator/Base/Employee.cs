using System;

namespace SalaryCalculator.Base
{
    public abstract class Employee
    {
        public Guid Id { get; }
        public decimal Rate { get; }
        public string Name { get; set; }

        public Employee(string name, decimal rate)
        {
            Rate = rate;
            Name = name;
            Id = Guid.NewGuid();
        }

        public abstract decimal CalculateSalary();
    }
}
