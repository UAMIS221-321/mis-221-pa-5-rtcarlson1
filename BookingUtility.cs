namespace mis_221_pa_5_rtcarlson1
{
    public class BookingUtility
    {
        private Booking[] bookings;

        public BookingUtility(Booking[] bookings)
        {
            this.bookings = bookings;
        }

        public void GetAllBookingsFromFile()
        {
            StreamReader inFile = new StreamReader("transactions.txt");
            Booking NewBooking = new Booking();

            Booking.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split('#');
                bookings[Booking.GetCount()] = new Booking(int.Parse(temp[0]), temp[1], temp[2], temp[3], temp[4], temp[5], int.Parse(temp[6]), double.Parse(temp[7]), temp[8]);
                Booking.IncCount();
                line = inFile.ReadLine();
            }

            inFile.Close();
        }

        public void BookSession(Listing[] listings, Trainer[] trainers)
        {
            Booking myBooking = new Booking();


            System.Console.WriteLine("\nPlease enter your name:");
            myBooking.SetCustomerName(Console.ReadLine());
            System.Console.WriteLine("\nPlease enter your email:");
            myBooking.SetCustomerEmail(Console.ReadLine());
            System.Console.WriteLine("\nWhat is the ID of the listing you'd like to book:");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = FindListing(searchVal, listings);

            //Take listing and record it in file

            if(foundIndex != -1)
            {
                myBooking.SetSessionID(listings[foundIndex].GetListingID());
                myBooking.SetSessionDate(listings[foundIndex].GetDate());
                myBooking.SetSessionTime(listings[foundIndex].GetTime());
                myBooking.SetTrainerName(listings[foundIndex].GetTrainerName());
                myBooking.SetCost(listings[foundIndex].GetCost());

                myBooking.SetTrainerID(FindTrainerID(myBooking.GetTrainerName(), trainers));

                listings[foundIndex].ListingTaken(listings[foundIndex].GetTaken());
                System.Console.WriteLine(listings[foundIndex].GetTaken());

            }

            bookings[Booking.GetCount()] = myBooking;
            Booking.IncCount();

            Save(listings);

            System.Console.WriteLine("\nWhat was the result of the session?\n");
            myBooking.SetStatus(Console.ReadLine());

            Save(listings);

        }

        public int FindListing(int searchVal, Listing[] listings)
        {
            for(int i = 0; i < Listing.GetCount(); i++)
            {
                if(listings[i].GetListingID() == searchVal)
                {
                    return i;
                }
            }
            return -1;
        }
        public int FindTrainerID(string trainerName, Trainer[] trainers)
        {
            for(int i = 0; i < Trainer.GetCount(); i++)
            {
                if(trainers[i].GetTrainerName().ToUpper() == trainerName.ToUpper())
                {
                    return trainers[i].GetTrainerID();
                }
            }
            return -1;
        }
        public void Save(Listing[] listings)
        {
            StreamWriter outFile1 = new StreamWriter("transactions.txt");

            for(int i = 0; i < Booking.GetCount(); i++)
            {
                outFile1.WriteLine(bookings[i].ToFile());
            }

            outFile1.Close();

            StreamWriter outFile2 = new StreamWriter("listings.txt");

            for(int i = 0; i < Listing.GetCount(); i++)
            {
                outFile2.WriteLine(listings[i].ToFile());
            }

            outFile2.Close();
        }
    }
}