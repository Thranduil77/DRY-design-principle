namespace DRY_Design_Principle.MagicNumbers
{
    #region Using

    using System;
    using System.Collections.Generic;

    #endregion

    class MagicNumbersBadCode
    {
        public void DoMagicInteger(List<Employee> employees)
        {
            if (employees.Count > 0)
            {
                Console.WriteLine(string.Concat("Age: ", employees[1].Age, ", department: ", employees[1].Department, ", name: ", employees[1].Name));
            }
        }
    }
}