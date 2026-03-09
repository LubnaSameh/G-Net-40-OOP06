using System;

namespace OOP06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Part 01 : Theoretical Questions

                #region Q1 : Abstraction vs. Encapsulation
                /*
                 * 1. Abstraction: 
                 * It means showing only the important features and hiding the complex details. 
                 * It focuses on "What" the object does.
                 * * 2. Encapsulation: 
                 * It means wrapping data and methods into one unit and protecting them from 
                 * outside access (using private/public). It focuses on How the data is hidden.
                 * * 3. Example: 
                 * A TV Remote. Abstraction is that you only see buttons like "Power" or "Volume." 
                 * Encapsulation is the plastic case that hides the internal wires and chips 
                 * so you don't break them. 
                 */
                #endregion

                #region Q2 : Abstract Class vs. Interface
                /*
                 * Four Differences:
                 * 1. Inheritance: A class can inherit only one abstract class, but can implement many interfaces.
                 * 2. Members: Abstract classes can have fields (variables), but interfaces cannot.
                 * 3. Constructor: Abstract classes can have constructors, while interfaces cannot.
                 * 4. Purpose: Use Abstract class for "Is-A" relationship (shared identity). 
                 * Use Interface for "Can-Do" relationship (shared behavior). 
                 */
                #endregion

                #region Q3 : Appliance Code Analysis
                /*
                 * a) 
                 * No. Because 'Appliance' is an abstract class, and you cannot create an object 
                 * from an abstract class directly. 
                 * * b) 
                 * - PowerConsumption(): Abstract because every appliance consumes power differently, 
                 *    so we force children to define it.
                 * - Status(): Virtual because it has a default value ("Standby"), 
                 *   but children can change it if they want.
                 * - Label(): Concrete because the logic of showing the name and power is the same for everyone. 
                 * * c) 
                 * It will return "Standby" because the Toaster class did not override the Status() method.
                 */
                #endregion

                #region Q4 : Partial Classes and Extension Methods
                /*
                 * a) Partial Class: 
                 * It allows you to split one class into two or more files. Developers use it 
                 * to organize large code or separate machine-generated code from human code.
                 * * b) Partial Method: 
                 * It is a method defined in one part of a partial class and implemented in another. 
                 * If the implementation is deleted, the code will still compile, and the compiler 
                 * will simply ignore all calls to that method.
                 * * c) Extension Method: 
                 * It allows you to add new methods to existing classes without changing their original code.
                 * Three rules: 1. Must be in a static class. 2. Must be a static method. 
                 * 3. Use the 'this' keyword before the first parameter.
                 * * d) Output:
                 * Log: result = 20
                 * $20.00
                 * (Explanation: Add(19.5, 0.5) results in 20.0, which triggers the log partial method, 
                 * then ToCurrency formats it). 
                 */
                #endregion

            #endregion
        }
    }
}