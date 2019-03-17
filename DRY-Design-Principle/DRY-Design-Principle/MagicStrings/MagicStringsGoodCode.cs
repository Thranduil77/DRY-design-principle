namespace DRY_Design_Principle.MagicStrings
{
    #region Using

    using System;

    #endregion

    class MagicStringsGoodCode
    {
        private static readonly string _address = Constants.Address;
        private static readonly string _format = Constants.StandardFormat;

        public void Start()
        {
            DoSomething();
            DoSomethingAgain();
            DoSomethingMore();
            DoSomethingExtraordinary();
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