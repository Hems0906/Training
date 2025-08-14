using System;
using System.Data;
using System.Linq;

class Program
{
    private static Admin admin = new Admin();
    private static Customer customer = new Customer();
    private static Train train = new Train();
    private static Reservation reservation = new Reservation();
    private static Reports reports = new Reports();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("RAILWAY RESERVATION SYSTEM");
            Console.WriteLine("--------------------------");
            Console.WriteLine("1. Admin Login");
            Console.WriteLine("2. Customer Registration");
            Console.WriteLine("3. Customer Login");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AdminLogin();
                    break;
                case "2":
                    CustomerRegistration();
                    break;
                case "3":
                    CustomerLogin();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void AdminLogin()
    {
        Console.Clear();
        Console.Write("AdminName: ");
        string username = Console.ReadLine();

        Console.Write("Password: ");
        string password = ReadPassword();

        if (admin.ValidateAdmin(username, password))
        {
            AdminMenu();
        }
        else
        {
            Console.WriteLine("Invalid credentials!");
            Console.ReadKey();
        }
    }

    static string ReadPassword()
    {
        string password = "";
        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey(true);
            if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
            {
                password += key.KeyChar;
                Console.Write("*");
            }
            else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password.Substring(0, (password.Length - 1));
                Console.Write("\b \b");
            }
        } while (key.Key != ConsoleKey.Enter);
        Console.WriteLine();
        return password;
    }

    static void AdminMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("ADMIN MENU");
            Console.WriteLine("----------");
            Console.WriteLine("1. Add Train");
            Console.WriteLine("2. View All Trains");
            Console.WriteLine("3. View Ticket Report");
            Console.WriteLine("4. View Cancellation Report");
            Console.WriteLine("5. Logout");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.Write("Train Number: ");
                    int trainNo = int.Parse(Console.ReadLine());

                    Console.Write("Train Name: ");
                    string trainName = Console.ReadLine();

                    Console.Write("Source: ");
                    string source = Console.ReadLine();

                    Console.Write("Destination: ");
                    string destination = Console.ReadLine();



                    int acSeats = GetIntInput("AC Seats: ");
                    int twoACSeats = GetIntInput("2AC Seats: ");
                    int threeACSeats = GetIntInput("3AC Seats: ");
                    int sleeperSeats = GetIntInput("Sleeper Seats: ");

                    decimal acCost = GetDecimalInput("AC Cost: ");
                    decimal twoACCost = GetDecimalInput("2AC Cost: ");
                    decimal threeACCost = GetDecimalInput("3AC Cost: ");
                    decimal sleeperCost = GetDecimalInput("Sleeper Cost: ");

                    TimeSpan departureTime = GetTimeSpanInput("Departure Time (HH:MM:SS): ");
                    TimeSpan arrivalTime = GetTimeSpanInput("Arrival Time (HH:MM:SS): ");

                    int result = train.AddTrain(trainNo, trainName, source, destination,
                                            acSeats, twoACSeats, threeACSeats, sleeperSeats,
                                            acCost, twoACCost, threeACCost, sleeperCost,
                                            departureTime, arrivalTime);


                    Console.WriteLine(result > 0 ? "Train added successfully!" : "Failed to add train!");
                    Console.ReadKey();
                    break;

                case "2":
                    Console.Clear();
                    DataTable trains = train.Trains();
                    Console.WriteLine("TrainNo  TrainName         Source    Destination AC  2AC  3AC   SLPR   AC_Cost    2AC_Cost    3AC_Cost   SLEEPER_Cost           Dep.           Arr.");
                    Console.WriteLine("---------------------------------------------------------------------------------------------------");
                    foreach (DataRow row in trains.Rows)
                    {
                        Console.WriteLine($"{row["TrainNo"],-7} {row["TrainName"],-17} {row["Source"],-9} {row["Destination"],-11} " +
                                        $"{row["AvailabilityAC"],-3} {row["Availability2AC"],-4} {row["Availability3AC"],-4} {row["AvailabilitySleeper"],-5} " +
                                        $"{row["CostAC"],-8:C2} {row["Cost2AC"],-8:C2} {row["Cost3AC"],-8:C2} {row["CostSleeper"],-8:C2} " +
                                        $"{row[  "DepartureTime"],-5} {row["ArrivalTime"]}");
                    }
                    Console.ReadKey();
                    break;

          
                case "3":
                    Console.Clear();
                    DataTable ticketReport = reports.GetTicketReport();

                    Console.WriteLine("Tickets Booked: " + ticketReport.Rows.Count + " total reservations");
                    Console.WriteLine();

                    Console.WriteLine("Booking ID    | Customer Name  |   Train Name   |     Travel Date    |   Class    |   Tickets    |  Total Cost   |  Status  ");
                    Console.WriteLine("-------------------------------------------------------------------------------------------");

                    foreach (DataRow row in ticketReport.Rows)
                    {
                        Console.WriteLine(
                            $"{row["BookingId"],-10} | {row["CustName"],-15} | {row["TrainName"],-10} | " +
                            $"{Convert.ToDateTime(row["TravelDate"]):yyyy-MM-dd, -20} | {row["Class"],-9} | " +
                             $"{row["TicketCount"],-7} | "+
                            $"{Convert.ToDecimal(row["TotalCost"]),-9:C} | {row["Status"], -10}"
                        );
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "4":
                    Console.Clear();
                    DataTable cancellationReport = reports.GetCancellationReport(); 

                    Console.WriteLine("┌──────────┬───────────┬────────────────┬───────────────────┬──────────────┬──────────────┬──────────────────┐");
                    Console.WriteLine("│ CancelID │ BookingID │ Customer Name  │     Train Name    │ Refund Amt   │ Cancel Date  │ Original Status  │");
                    Console.WriteLine("├──────────┼───────────┼────────────────┼───────────────────┼──────────────┼──────────────┼──────────────────┤");

                    foreach (DataRow row in cancellationReport.Rows)
                    {
                            Console.WriteLine(
                            $"│ {row["CancelId"],-8} │ {row["BookingId"],-9} │ {row["CustName"],-14} │ " +
                            $"{row["TrainName"],-10} │ {Convert.ToDecimal(row["RefundAmount"]),-12:C} │ " +
                            $"{Convert.ToDateTime(row["CancellationDate"]).ToString("yyyy-MM-dd"),-12} │ {row["OriginalStatus"],-16} │"
                        );
                    }
                    Console.WriteLine("└──────────┴───────────┴────────────────┴───────────────────┴──────────────┴──────────────┴──────────────────┘");

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "5":
                    Console.WriteLine("Logging out...");
                    Console.ReadKey();
                    return;

                default:
                    Console.WriteLine("Invalid choice!");
                    Console.ReadKey();
                    break;
            }
        }
    }
    static int GetIntInput(string prompt)
    {
        int result;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out result) && result > 0)
                return result;
            Console.WriteLine("Please enter a valid positive integer.");
        }
    }

    static decimal GetDecimalInput(string prompt)
    {
        decimal result;
        while (true)
        {
            Console.Write(prompt);
            if (decimal.TryParse(Console.ReadLine(), out result) && result >= 0)
                return result;
            Console.WriteLine("Please enter a valid non-negative decimal.");
        }
    }

    static string GetStringInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

 

    static TimeSpan GetTimeSpanInput(string prompt)
    {
        TimeSpan result;
        while (true)
        {
            Console.Write(prompt);
            if (TimeSpan.TryParse(Console.ReadLine(), out result))
                return result;
            Console.WriteLine("Please enter a valid time in HH:MM:SS format.");
        }
    }

    static void CustomerRegistration()
    {
        Console.Clear();
        Console.Write("Full Name: ");
        string name = Console.ReadLine();

        Console.Write("Phone: ");
        string phone = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Password: ");
        string password = ReadPassword();

        int result = customer.Register(name, phone, email, password);
        Console.WriteLine(result > 0 ? "Registration successful!" : "Registration failed!");
        Console.ReadKey();
    }

    static void CustomerLogin()
    {
        Console.Clear();
        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Password: ");
        string password = ReadPassword();

        int? custId = customer.ValidateCustomer(email, password);
        if (custId.HasValue)
        {
            CustomerMenu(custId.Value);
        }
        else
        {
            Console.WriteLine("Invalid login credentials!");
            Console.ReadKey();
        }
    }
 

static DateTime GetDateInput(string prompt)
{
    DateTime result;
    while (true)
    {
        Console.Write(prompt);
        string input = Console.ReadLine();

        if (DateTime.TryParse(input, out result))
        {
            // Optional: Ensure date is today or future
            if (result >= DateTime.Today)
                return result;
            else
                Console.WriteLine("Travel date must be today or in the Upcoming Days.");
        }
        else
        {
            Console.WriteLine("Invalid date format. Use YYYY-MM-DD.");
        }
    }
}

static void CustomerMenu(int custId)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("CUSTOMER MENU");
            Console.WriteLine("-------------");
            Console.WriteLine("1. View All Trains");
            Console.WriteLine("2. Book Ticket");
            Console.WriteLine("3. View My Bookings");
            Console.WriteLine("4. Cancel Ticket");
            Console.WriteLine("5. Logout");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Display all trains
                    DataTable trains = train.Trains();
                    Console.WriteLine("TrainNo | TrainName | Source | Destination | AC | 2AC | 3AC | SLPR | AC_Cost | 2AC_Cost | 3AC_Cost | SLPR_Cost | Dep. | Arr.");
                    Console.WriteLine("---------------------------------------------------------------------------------------------------");
                    foreach (DataRow row in trains.Rows)
                    {
                        Console.WriteLine($"{row["TrainNo"],-7} | {row["TrainName"],-10} | {row["Source"],-7} | {row["Destination"],-11} | " +
                                          $"{row["AvailabilityAC"],-3} | {row["Availability2AC"],-4} | {row["Availability3AC"],-4} | {row["AvailabilitySleeper"],-5} | " +
                                          $"{row["CostAC"],-8:C} | {row["Cost2AC"],-8:C} | {row["Cost3AC"],-8:C} | {row["CostSleeper"],-8:C} | " +
                                          $"{row["DepartureTime"],-5} | {row["ArrivalTime"]}");
                    }
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "2":
                    // Book a ticket
                    int trainNo = GetIntInput("Enter Train Number: ");
                    DateTime travelDate = GetDateInput("Enter Travel Date (YYYY-MM-DD): ");
                    string trainClass = GetStringInput("Enter Class (AC/2AC/3AC/SLEEPER): ");
                    int ticketCount = GetIntInput("Enter Number of Tickets: ");

                    int bookingResult = reservation.BookTicket(custId, trainNo, travelDate, trainClass, ticketCount);
                    Console.WriteLine(bookingResult > 0 ? "Ticket booked successfully!" : "Failed to book ticket!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;

                case "3":
                    // View bookings
                    DataTable bookings = reservation.GetCustomerReservations(custId);
                    Console.WriteLine("Booking ID | Train Name | Travel Date | Class | Total Cost | Booking Date | Status | Refund");
                    Console.WriteLine("----------------------------------------------------------------------------------------------");

                    foreach (DataRow row in bookings.Rows)
                    {
                        string refundInfo = "";
                        if (row.Table.Columns.Contains("RefundAmount") && row["Status"].ToString() == "Cancelled")
                        {
                            refundInfo = $"{Convert.ToDecimal(row["RefundAmount"]):C}";
                        }

                        Console.WriteLine(
                            $"{row["BookingId"],-11} | {row["TrainName"],-10} | {row["TravelDate"],-12} | {row["Class"],-5} | " +
                            $"{row["TotalCost"],-10:C} | {row["BookingDate"],-12} | {row["Status"],-9} | {refundInfo,-10}"
                        );
                    }

                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;


                case "4": // Cancel Ticket
                    int bookingId = GetIntInput("Enter Booking ID to cancel: ");
                    int cancelResult = reservation.CancelTicket(bookingId, custId);
                    Console.WriteLine(cancelResult > 0 ? "Ticket canceled successfully!" : "Failed to cancel ticket!");
                    Console.ReadKey();
                    break;

                  

                case "5":
                    return; 

                default:
                    Console.WriteLine("Invalid choice!");
                    Console.ReadKey();
                    break;
            }
        }
    }


}
