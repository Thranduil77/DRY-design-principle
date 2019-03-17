namespace DRY_Design_Principle.MagicStrings
{
    #region Using

    using System;

    #endregion

    class MagicStringsBadCode
    {
        public void Start()
        {
            DoSomething();
            DoSomethingAgain();
            DoSomethingMore();
            DoSomethingExtraordinary();
        }

        private static void DoSomething()
        {
            string address = "Stockholm, Sweden";
            string format = "{0} is {1}, lives in {2}, age {3}";
            Console.WriteLine(format, "Nils", "a good friend", address, 30);
        }

        private static void DoSomethingAgain()
        {
            string address = "Stockholm, Sweden";
            string format = "{0} is {1}, lives in {2}, age {3}";
            Console.WriteLine(format, "Christian", "a neighbour", address, 54);
        }

        private static void DoSomethingMore()
        {
            string address = "Stockholm, Sweden";
            string format = "{0} is {1}, lives in {2}, age {3}";
            Console.WriteLine(format, "Eva", "my daughter", address, 4);
        }

        private static void DoSomethingExtraordinary()
        {
            string address = "Stockholm, Sweden";
            string format = "{0} is {1}, lives in {2}, age {3}";
            Console.WriteLine(format, "Lilly", "my daughter's best friend", address, 4);
        }
    }
}