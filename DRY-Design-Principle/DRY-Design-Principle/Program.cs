namespace DRY_Design_Principle
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using IfStatements;
    using MagicNumbers;
    using MagicStrings;
    using RepeatedExecutionPattern;

    #endregion

    public class Program
    {
        static void Main(string[] args)
        {
            /*
             * These are hard-coded strings that pop up at different places throughout your code: 
             * connection strings, formats, constants, like in the following code example:
             * */
            var magicStringsBadCode = new MagicStringsBadCode();
            magicStringsBadCode.Start();

            //Why this is bad?
            /*
             * This is obviously a very simplistic example but imagine that the methods are located
             * in different sections or even different modules in your application. In case you want
             * to change the address you’ll need to find every hard-coded instance of the address. 
             * Likewise if you want to change the format you’ll need to update it in several different
             * places. We can put these values into a separate location, such as Constants.cs:
             * 
             * If you have a database connection string then that can be put into the configuration 
             * file app.config or web.config.
             * */

            //The updated programme looks as follows:
            var magicStringsGoodCode = new MagicStringsGoodCode();
            magicStringsGoodCode.Start();


            // Do magic numbers 
            var employees = GetEmployees().ToList();
            var magicNumbersBadCode = new MagicNumbersBadCode();

            //Notice the usage of the index 1 in the following method
            magicNumbersBadCode.DoMagicInteger(employees);

            /*
             * So we only want to output the properties of the second employee in the list, i.e. the one with index 1. One issue is a 
             * conceptual one: why are we only interested in that particular employee? What’s so special about him/her? This is not clear
             * for anyone investigating the code. The second issue is that if we want to change the value of the index then we’ll need 
             * to do it in three places. If this particular index is important elsewhere as well then we’ll have to visit those places too 
             * and update the index.
             * 
             * We can solve both issues using the same simple techniques as in the previous example. Set a new constant in Constants.cs:
             * */


            //good code
            var magicNumbersGoodCode = new MagicNumbersGoodCode();
            magicNumbersGoodCode.DoMagicIntegerBetter(employees, Constants.IndexOfMyFavouriteEmployee);


            /*
             * If statements:
             * 
             * If statements are very important building blocks of an application. It would probably be impossible to write any real life app without them. 
             * However, it does not mean they should be used without any limitation. Consider the following domains:
             * 
             * */

            var badShapes = GetAllBadShapes();
            var totalArea = CalculateTotalArea(badShapes);
            Console.WriteLine($"Total area of shapes is: {totalArea} ");

            //Why is this solution bad?
            /*
             * This is actually quite a common approach in a software design where our domain objects are mere collections of properties and are void of any 
             * self-contained logic. Look at the Triangle and Rectangle classes, they contain no logic whatsoever, they only have properties. They are reduced
             * to the role of data-transfer-objects (DTOs). If you don’t understand at first what’s wrong with the above solution then I suggest you go through
             * * the Liskov Substitution Principle here. I won’t repeat what’s written in that post.
             * 
             * This post is about DRY so you may ask what this method has to do with DRY at all as we do not seem to repeat anything. Yes we do, 
             * although indirectly. Our initial intention was to create a class hierarchy so that we can work with the abstract class Shape elsewhere. Well,
             * guess what, we’ve failed miserably. In this method we need to reveal not only the concrete implementation types of Shape but we’re forcing an 
             * external class to know about the internals of those concrete types.
             * 
             * This is a typical example for how not to use if statements in software. In the posts on the SOLID design principles we mentioned the
             * Tell-Don’t-Ask (TDA) principle. It basically states that you should not ask an object questions about its current state before you ask it 
             * to perform something. Well, this piece of code is a clear violation of TDA although the lack of logic in the Triangle and Rectangle classes 
             * forced us to ask these questions.
             * 
             * The solution – or at least one of the viable solutions – will be to hide this calculation logic behind each concrete Shape class:
             * 
             * */

            var goodShapes = GetAllGoodShapes();
            var totalAreaGood = CalculateTotalAreaGood(goodShapes);
            Console.WriteLine($"Total area of shapes is: {totalAreaGood} ");
            Console.ReadLine();
            /*
             * We’ve got rid of the if statements, we don’t violate TDA and the logic to calculate the area is hidden behind each concrete type. 
             * This allows us even to follow the above mentioned Liskov Substitution Principle.
             * */


            //RepeatedExecutionPattern - Bad approach
            var repeatedExecutionPatternBad = new RepeatedExecutionPatternBad();
            repeatedExecutionPatternBad.Start();

            //RepeatedExecutionPattern - Good approach
            var repeatedExecutionPatternGood = new RepeatedExecutionPatternGood();
            repeatedExecutionPatternGood.Start();
        }

        //database lookup
        private static IEnumerable<Employee> GetEmployees()
        {
            return new List<Employee>()
                   {
                       new Employee() { Age = 30, Department = "IT", Name = "John" },
                       new Employee() { Age = 34, Department = "Marketing", Name = "Jane" },
                       new Employee() { Age = 28, Department = "Security", Name = "Karen" },
                       new Employee() { Age = 40, Department = "Management", Name = "Dave" }
                   };
        }

        //database lookup
        private static IEnumerable<ShapeBad> GetAllBadShapes()
        {
            List<ShapeBad> badShapes = new List<ShapeBad>
                                       {
                                           new TriangleBad() { Base = 5, Height = 3 },
                                           new RectangleBad() { Height = 6, Width = 4 },
                                           new TriangleBad() { Base = 9, Height = 5 },
                                           new RectangleBad() { Height = 3, Width = 2 }
                                       };


            return badShapes;
        }

        //database lookup
        private static IEnumerable<ShapeGood> GetAllGoodShapes()
        {
            List<ShapeGood> goodShapes = new List<ShapeGood>
                                         {
                                             new TriangleGood { Base = 5, Height = 3 },
                                             new RectangleGood { Height = 6, Width = 4 },
                                             new TriangleGood() { Base = 9, Height = 5 },
                                             new RectangleGood { Height = 3, Width = 2 }
                                         };


            return goodShapes;
        }

        private static double CalculateTotalArea(IEnumerable<ShapeBad> shapes)
        {
            double area = 0.0;
            foreach (ShapeBad shape in shapes)
            {
                if (shape is TriangleBad)
                {
                    TriangleBad triangle = shape as TriangleBad;
                    area += triangle.Base * triangle.Height / 2;
                }
                else if (shape is RectangleBad)
                {
                    RectangleBad recangle = shape as RectangleBad;
                    area += recangle.Height * recangle.Width;
                }
            }
            return area;
        }

        private static double CalculateTotalAreaGood(IEnumerable<ShapeGood> goodShapes)
        {
            double area = 0.0;

            foreach (var goodShape in goodShapes)
            {
                area += goodShape.CalculateAreaGood();
            }

            return area;
        }
    }
}