# DRY - Design Principle (Don’t-Repeat-Yourself)

The idea behind the Don’t-Repeat-Yourself (DRY) design principle is an easy one: a piece of logic should only be represented once in an application. In other words avoiding the repetition of any part of a system is a desirable trait. Code that is common to at least two different parts of your system should be factored out into a single location so that both parts call upon in. In plain English all this means that you should stop doing copy+paste right away in your software. Your motto should be the following:

Repetition is the root of all software evil.

Repetition does not only refer to writing the same piece of logic twice in two different places. It also refers to repetition in your processes – testing, debugging, deployment etc. Repetition in logic is often solved by abstractions or some common service classes whereas repetition in your process is tackled by automation. A lot of tedious processes can be automated by concepts from Continuous Integration and related automation software such as TeamCity. Unit testing can be automated by testing tools such as nUnit. You can read more on Test Driven Development and unit testing here.

The DRY principle is stated as "Every piece of knowledge must have a single, unambiguous, authoritative representation within a system". The principle has been formulated by Andy Hunt and Dave Thomas in their book The Pragmatic Programmer. They apply it quite broadly to include "database schemas, test plans, the build system, even documentation". When the DRY principle is applied successfully, a modification of any single element of a system does not require a change in other logically unrelated elements. 

Additionally, elements that are logically related all change predictably and uniformly, and are thus kept in sync. Besides using methods and subroutines in their code, Thomas and Hunt rely on code generators, automatic build systems, and scripting languages to observe the DRY principle across layers.

In this ahort series on DRY I’ll concentrate on the ‘logic’ side of DRY. DRY is known by other names as well: Once and Only Once, and Duplication is Evil (DIE).

## DRY vs WET solutions

Violations of DRY are typically referred to as WET solutions, which is commonly taken to stand for either "write everything twice", "we enjoy typing" or "waste everyone's time". WET solutions are common in multi-tiered architectures where a developer may be tasked with, for example, adding a comment field on a form in a web application. The text string "comment" might be repeated in the label, the HTML tag, in a read function name, a private variable, database DDL, queries, and so on. A DRY approach eliminates that redundancy by using frameworks that reduce or eliminate all those edit tasks excepting the most important one, leaving the extensibility of adding new knowledge variables in one place.

## Author

* **Andras Nemes** 

## Content of this project:

## Example 1: Magic strings

These are hard-coded strings that pop up at different places throughout your code: 
             * connection strings, formats, constants

Why this is bad?

This is obviously a very simplistic example but imagine that the methods are located
in different sections or even different modules in your application. In case you want
to change the address you’ll need to find every hard-coded instance of the address. 
Likewise if you want to change the format you’ll need to update it in several different
places. We can put these values into a separate location, such as Constants.cs:

If you have a database connection string then that can be put into the configuration 
file app.config or web.config.

## Example 2: Magic numbers

It’s not only magic strings that can cause trouble but magic numbers as well.

Notice the usage of the index 1 in the following method: DoMagicInteger()

So we only want to output the properties of the second employee in the list, i.e. the one with index 1. One issue is a conceptual one: why are we only interested in that particular employee? What’s so special about him/her? This is not clear for anyone investigating the code. The second issue is that if we want to change the value of the index then we’ll need to do it in three places. If this particular index is important elsewhere as well then we’ll have to visit those places too and update the index.

We can solve both issues using the same simple techniques as in the previous example. Set a new constant in Constants.cs: IndexOfMyFavouriteEmployee 

## Example 3: If statements (including Switch-Case statement) (DRY & LSP (L from SOLID design principles))

If statements are very important building blocks of an application. It would probably be impossible to write any real life app without them. However, it does not mean they should be used without any limitation. Consider the following objects in our model:

Shape (base class), Triangle and Rectangle.

Let's analyze CalculateTotalArea() method.
This is actually quite a common approach in a software design where our domain objects are mere collections of properties and are void of any self-contained logic. Look at the Triangle and Rectangle classes, they contain no logic whatsoever, they only have properties. They are reduced to the role of data-transfer-objects (DTOs). If you don’t understand at first what’s wrong with the above solution then I suggest you go through the Liskov Substitution Principle here. 
[Liskov Substitution Principle](https://github.com/Thranduil77/SOLID-design-principles/Liskov_substitution_principle)

This post is about DRY so you may ask what this method has to do with DRY at all as we do not seem to repeat anything. Yes we do, although indirectly. Our initial intention was to create a class hierarchy so that we can work with the abstract class Shape elsewhere. Well, guess what, we’ve failed miserably. In this method we need to reveal not only the concrete implementation types of Shape but we’re forcing an external class to know about the internals of those concrete types.

This is a typical example for how not to use if statements in software. The Tell-Don’t-Ask (TDA) principle, basically states that you should not ask an object questions about its current state before you ask it to perform something. Well, this piece of code is a clear violation of TDA although the lack of logic in the Triangle and Rectangle classes forced us to ask these questions.

The solution – or at least one of the viable solutions – will be to hide this calculation logic behind each concrete Shape class:

Ending: 
We’ve got rid of the if statements, we don’t violate TDA and the logic to calculate the area is hidden behind each concrete type. This allows us even to follow the above mentioned Liskov Substitution Principle.

## Example 4: Repeated Execution Pattern

This pattern can be used when you see similar chunks of code repeated at several places. Here we talk about code bits that are not 100% identical but follow the same pattern and can clearly be factored out.

We’re simulating a simple logging function every time we run we run one of these “dosomething” methods. The pattern is clear: write a message to the console, carry out an action and write another message to the console. The actions have an identical void, parameterless signature. The logging message all have the same format, it’s only the method name that varies. If this chain of actions continues to grow then we have to come back here and add the same type of logging messages. Also, if you later wish to change the logging message format then you’ll have to do it in many different places.

The first step is to factor out a single console-action-console chunk to its own method: ExecuteStep()

This is of course not good enough as the method is very rigid. It is hard coded to execute the first step only. We can vary the action to be executed using the Action object: ExecuteStep(Action action)

Except that we’re not logging the method names correctly. That’s still hard coded to “DoSomething”. That’s easy to fix as the Action object has public properties to read off the method name using: action.Method.Name;

We’re almost done. If you look at the Main method then the ExecuteStep(somemethod) is called 4 times. That is also a form of DRY-violation. Imagine that you have a long workflow, such as the steps in a chemical experiment. In that case you may need to repeat the call to ExecuteStep many times.

We can instead put the methods to be executed in a collection of actions.

Now it’s not the responsibility of the Main method to define the steps to be executed. It only iterates through a loop and calls ExecuteStep for each action.