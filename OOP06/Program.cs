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

            #region Part 02 : Practical (Extending the Movie Ticket Booking System)

            // a. Open Cinema
            Cinema cinema = new Cinema();
            cinema.OpenCinema();

            // b. Try to create a plain Ticket object
            Console.WriteLine("// Ticket t = new Ticket(\"Test\", 100);");
            Console.WriteLine("// ERROR: Cannot create instance of abstract type 'Ticket'");

            // c. Create tickets and book them
            StandardTicket st = new StandardTicket("Inception", 80m, "A5");
            VIPTicket vip = new VIPTicket("Avengers", 200m, true);
            IMAXTicket imax = new IMAXTicket("Dune", 130m, true);

            st.Book();
            vip.Book();
            imax.Book();

            cinema.AddTicket(st);
            cinema.AddTicket(vip);
            cinema.AddTicket(imax);

            // Print all Uses the Reporting partial class
            cinema.PrintAllTickets();

            // d. Polymorphism: Loop array and call abstract method
            Console.WriteLine("--- Polymorphism: Final Price per Ticket ---");
            Ticket[] myTickets = { st, vip, imax };
            foreach (var t in myTickets)
            {
                Console.WriteLine($"{t.GetType().Name} => Final Price: {t.CalculateFinalPrice():F2}");
            }

            // e. Extension Method: Single Ticket Receipt
            Console.WriteLine("--- Extension Method: Receipt ---");
            Console.WriteLine(vip.GenerateReceipt());

            // f. Extension Method: Array Total Revenue
            Console.WriteLine("--- Extension Method: Total Revenue ---");
            Console.WriteLine($"Total Revenue: {myTickets.CalculateTotalRevenue():F2}");

            // g. Close Cinema
            cinema.CloseCinema();

            #endregion
        }
    }

         #region Part 02 Support Classes

    // 1. Abstract Base Class
    public abstract class Ticket
    {
        protected static int _counter = 0;
        public int TicketId { get; private set; }
        public string MovieName { get; set; }
        public decimal Price { get; set; }  // Concrete property
        public bool IsBooked { get; protected set; }

        // Concrete Constructor
        public Ticket(string movieName, decimal price)
        {
            MovieName = movieName;
            Price = price;
            TicketId = ++_counter;
        }

        // Concrete Method
        public void Book() => IsBooked = true;

        // Virtual Method
        public virtual void Cancel() => IsBooked = false;

        // Abstract Methods (Must be implemented by children)
        public abstract decimal CalculateFinalPrice();
        public abstract string GetDetails();
    }

    // Child Classes
    public class StandardTicket : Ticket
    {
        public string SeatNumber { get; set; }
        public StandardTicket(string movie, decimal price, string seat) : base(movie, price) => SeatNumber = seat;

        public override decimal CalculateFinalPrice() => Price * 1.14m; // 14% Tax
        public override string GetDetails() => $"[Ticket #{TicketId}] {MovieName} | Standard | Seat: {SeatNumber} | Price: {Price:F0} | Final: {CalculateFinalPrice():F2} | Booked: {(IsBooked ? "Yes" : "No")}";
    }

    public class VIPTicket : Ticket
    {
        public bool LoungeAccess { get; set; }
        public decimal ServiceFee { get; set; } = 50m;
        public VIPTicket(string movie, decimal price, bool lounge) : base(movie, price) => LoungeAccess = lounge;

        public override decimal CalculateFinalPrice() => Price * 1.14m;
        public override string GetDetails() => $"[Ticket #{TicketId}] {MovieName} | VIP | Lounge: {(LoungeAccess ? "Yes" : "No")} | Fee: {ServiceFee:F0} | Price: {Price:F0} | Final: {CalculateFinalPrice():F2} | Booked: {(IsBooked ? "Yes" : "No")}";
    }

    public class IMAXTicket : Ticket
    {
        public bool Is3D { get; set; }
        public IMAXTicket(string movie, decimal price, bool is3d) : base(movie, price) => Is3D = is3d;

        public override decimal CalculateFinalPrice() => Price * 1.14m;
        public override string GetDetails() => $"[Ticket #{TicketId}] {MovieName} | IMAX | 3D: {(Is3D ? "Yes" : "No")} | Price: {Price:F0} | Final: {CalculateFinalPrice():F2} | Booked: {(IsBooked ? "Yes" : "No")}";
    }

    // 2. Partial Class
    public partial class Cinema
    {
        private Ticket[] _tickets = new Ticket[20];
        private int _count = 0;

        public void OpenCinema() => Console.WriteLine("=== Cinema Opened ===");
        public void CloseCinema() => Console.WriteLine("=== Cinema Closed ===");

        public void AddTicket(Ticket t)
        {
            if (_count < 20) _tickets[_count++] = t;
        }
    }

    // 2. Partial Class 
    public partial class Cinema
    {
        public void PrintAllTickets()
        {
            Console.WriteLine("--- All Tickets (from Cinema.Reporting) ---");
            for (int i = 0; i < _count; i++)
            {
                Console.WriteLine(_tickets[i].GetDetails());
            }
        }
    }

    // 3. Extension Methods Class
    public static class TicketExtensions
    {
        // Extension for a single Ticket
        public static string GenerateReceipt(this Ticket t)
        {
            string typeName = t.GetType().Name.Replace("Ticket", "");
            string status = t.IsBooked ? "Booked" : "Not Booked";

            return $"========== RECEIPT ==========\n" +
                   $"  Movie    : {t.MovieName}\n" +
                   $"  Type     : {typeName}\n" +
                   $"  Price    : {t.Price:F0}\n" +
                   $"  Final    : {t.CalculateFinalPrice():F2}\n" +
                   $"  Status   : {status}\n" +
                   $"=============================";
        }

        // Extension for an Array of Tickets
        public static decimal CalculateTotalRevenue(this Ticket[] tickets)
        {
            decimal total = 0;
            foreach (var t in tickets)
            {
                if (t != null) total += t.CalculateFinalPrice();
            }
            return total;
        }
    }

    #endregion
}