namespace DRY_Design_Principle.RepeatedExecutionPattern
{
    #region Using

    using System;

    #endregion

    public class RepeatedExecutionPatternBad
    {
        private static readonly string _address = Constants.Address;
        private static readonly string _format = Constants.StandardFormat;

        public void Start()
        {
            Console.WriteLine("About to run the DoSomething method");
            DoSomething();
            Console.WriteLine("Finished running the DoSomething method");
            Console.WriteLine("About to run the DoSomethingAgain method");
            DoSomethingAgain();
            Console.WriteLine("Finished running the DoSomethingAgain method");
            Console.WriteLine("About to run the DoSomethingMore method");
            DoSomethingMore();
            Console.WriteLine("Finished running the DoSomethingMore method");
            Console.WriteLine("About to run the DoSomethingExtraordinary method");
            DoSomethingExtraordinary();
            Console.WriteLine("Finished running the DoSomethingExtraordinary method");

            Console.ReadLine();
        }

        private static void DoSomething()
        {
            WriteToConsole("Nils", "a good friend", 30);
        }

        private static void DoSomethingAgain()
        {
            WriteToConsole("Christian", "a neighbour", 54);
        }

        private static void DoSomethingMore()
        {
            WriteToConsole("Eva", "my daughter", 4);
        }

        private static void DoSomethingExtraordinary()
        {
            WriteToConsole("Lilly", "my daughter's best friend", 4);
        }

        private static void WriteToConsole(string name, string description, int age)
        {
            Console.WriteLine(_format, name, description, _address, age);
        }
    }
}