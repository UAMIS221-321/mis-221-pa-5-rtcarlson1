using mis_221_pa_5_rtcarlson1;

// MAIN START
Console.Clear();

System.Console.WriteLine("Welcome to Train Like A Champion - Personal Fitness!");
PauseAction();

Trainer[] trainers = new Trainer[100];

TrainerUtility trainerUtility = new TrainerUtility(trainers);

Listing[] listings = new Listing[100];

ListingUtility listingUtility = new ListingUtility(listings);

Booking[] bookings = new Booking[100];

BookingUtility bookingUtility = new BookingUtility(bookings);

Report report = new Report(listings, bookings, trainers);

trainerUtility.GetAllTrainersFromFile();
listingUtility.GetAllListingsFromFile();
bookingUtility.GetAllBookingsFromFile();

// listingUtility.PrintAllAvailableListings();

int decision = 0;
decision = PrintMainMenu();

while(decision != 5)
{
    if(decision == 1)
    {
        int trainerDecision = 0;

        trainerDecision = TrainerMainMenu();

        if(trainerDecision == 1)
        {
            trainerUtility.AddTrainer();
        }
        else if(trainerDecision == 2)
        {
            trainerUtility.EditTrainer();
        }
        else if(trainerDecision == 3)
        {
            trainerUtility.DeleteTrainer();
        }
        else
        {
            System.Console.WriteLine("\nInvalid input!");
            PauseAction();

            trainerDecision = TrainerMainMenu();
        }
    }
    else if(decision == 2)
    {
        int listingDecision = 0;

        listingDecision = ListingMainMenu();

        if(listingDecision == 1)
        {
            listingUtility.AddListing();
        }
        else if(listingDecision == 2)
        {
            listingUtility.EditListing();
        }
        else if(listingDecision == 3)
        {
            listingUtility.DeleteListing();
        }
        else
        {
            System.Console.WriteLine("Invalid input!");
            PauseAction();

            listingDecision = ListingMainMenu();
        }
    }
    else if(decision == 3)
    {
        int bookingDecision = 0;

        bookingDecision = BookingMainMenu();

        if(bookingDecision == 1)
        {
            listingUtility.PrintAllAvailableListings();

            PauseAction();
        }
        else if(bookingDecision == 2)
        {
            bookingUtility.BookSession(listings, trainers);
        }
        else
        {
            System.Console.WriteLine("Invalid input!");
            PauseAction();

            bookingDecision = BookingMainMenu();
        }
    }
    else if(decision == 4)
    {
        int reportDecision = 0;

        reportDecision = ReportMainMenu();

        if(reportDecision == 1)
        {
            report.IndividualCustomerSessions();

            PauseAction();
        }
        else if(reportDecision == 2)
        {
            report.SortBookings();

            PauseAction();

            report.TotalHistoricalCustomerSessions();

            PauseAction();
        }
        else if(reportDecision == 3)
        {
            report.SortBookings();

            report.MonthlyHistoricalRevenueReport();

            PauseAction();

            report.YearlyHistoricalRevenueReport();

            PauseAction();

        }
        else
        {
            System.Console.WriteLine("Invalid input!");
            PauseAction();

            reportDecision = ReportMainMenu();
        }
    }
    else
    {
        System.Console.WriteLine("Invalid input!");
        PauseAction();
    }
    decision = PrintMainMenu();
}


// MAIN END

static int PrintMainMenu()
{
    Console.Clear();
    
    System.Console.WriteLine("Which function would you like to use?\n");
    System.Console.WriteLine("1. Trainer Functions");
    System.Console.WriteLine("2. Listing Functions");
    System.Console.WriteLine("3. Booking Functions");
    System.Console.WriteLine("4. Report Functions");
    System.Console.WriteLine("5. Exit");

    string decision = "";
    decision = Console.ReadLine();

    return int.Parse(decision);
    
}

static int TrainerMainMenu()
{
    Console.Clear();

    System.Console.WriteLine("Which Trainer function would you like to use?\n");
    System.Console.WriteLine("1. Add Trainer information");
    System.Console.WriteLine("2. Edit Trainer information");
    System.Console.WriteLine("3. Delete Trainer information");

    string decision = "";
    decision = Console.ReadLine();

    return int.Parse(decision);
    
}

static int ListingMainMenu()
{
    Console.Clear();

    System.Console.WriteLine("Which Listing function would you like to use?\n");
    System.Console.WriteLine("1. Add Listing information");
    System.Console.WriteLine("2. Edit Listing information");
    System.Console.WriteLine("3. Delete Listing information");

    string decision = "";
    decision = Console.ReadLine();

    return int.Parse(decision);
    
}

static int BookingMainMenu()
{
    Console.Clear();

    System.Console.WriteLine("Which Booking function would you like to use?\n");
    System.Console.WriteLine("1. View available training sessions");
    System.Console.WriteLine("2. Book a session");

    string decision = "";
    decision = Console.ReadLine();

    return int.Parse(decision);
    
}

static int ReportMainMenu()
{
    Console.Clear();

    System.Console.WriteLine("Which Report function would you like to use?\n");
    System.Console.WriteLine("1. Individual Customer Sessions");
    System.Console.WriteLine("2. Historical Customer Sessions");
    System.Console.WriteLine("3. Historical Revenue Report");

    string decision = "";
    decision = Console.ReadLine();

    return int.Parse(decision);
    
}

static void PauseAction()
{
    System.Console.WriteLine("\nPress any key to continue");
    Console.ReadKey();
    Console.Clear();
}