namespace DRY_Design_Principle.MagicNumbers
{
    #region Using

    using System;
    using System.Collections.Generic;

    #endregion

    class MagicNumbersGoodCode
    {
        public void DoMagicIntegerBetter(List<Employee> employees, int employeeIndex)
        {
            if (employees.Count > 0)
            {
                Console.WriteLine(string.Concat("Age: ", employees[employeeIndex].Age, ", department: ", employees[employeeIndex].Department
                                                , ", name: ", employees[employeeIndex].Name));
            }
        }
    }
}