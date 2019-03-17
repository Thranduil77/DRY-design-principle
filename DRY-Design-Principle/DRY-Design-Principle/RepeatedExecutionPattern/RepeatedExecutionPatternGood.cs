namespace DRY_Design_Principle.RepeatedExecutionPattern
{
    #region Using

    using System;
    using System.Collections.Generic;

    #endregion

    public class RepeatedExecutionPatternGood
    {
        private static readonly string _address = Constants.Address;
        private static readonly string _format = Constants.StandardFormat;

        public void Start()
        {
            var executionActions = GetExecutionSteps();
            foreach (Action executionAction in executionActions)
            {
                ExecuteStep(executionAction);
            }

            Console.ReadLine();
        }

        private static IEnumerable<Action> GetExecutionSteps()
        {
            return new List<Action>()
                   {
                       DoSomething,
                       DoSomethingAgain,
                       DoSomethingExtraordinary,
                       DoSomethingMore
                   };
        }

        private static void ExecuteStep(Action action)
        {
            var methodName = action.Method.Name;
            Console.WriteLine($"About to run the {methodName} method");
            action();
            Console.WriteLine($"Finished running the {methodName} method");
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