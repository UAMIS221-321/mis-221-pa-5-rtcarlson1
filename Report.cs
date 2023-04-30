namespace mis_221_pa_5_rtcarlson1
{
    public class Report
    {
        private Listing[] listings;
        private Booking[] bookings;
        private Trainer[] trainers;

        public Report()
        {

        }
        public Report(Listing[] listings, Booking[] bookings, Trainer[] trainers)
        {
            this.listings = listings;
            this.bookings = bookings;
            this.trainers = trainers;
        }

        public void IndividualCustomerSessions()
        {
            System.Console.WriteLine("Please enter the email of the individual:");
            string individual = Console.ReadLine();

            FindEmail(individual);
        }

        public void FindEmail(string searchVal)
        {
            for(int i = 0; i < Booking.GetCount(); i++)
            {
                if(bookings[i].GetCustomerEmail() == searchVal)
                {
                    System.Console.WriteLine(bookings[i].ToString());
                }
            }
        }

        public void TotalHistoricalCustomerSessions()
        {
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Customer Name\t\t| Total Number of Sessions");
            Console.WriteLine("----------------------------------------------------");
            string curr = bookings[0].GetCustomerName();

            int count = 1;

            for( int i = 1; i < Booking.GetCount(); i++)
            {
                if(bookings[i].GetCustomerName() == curr)
                {
                    count++;
                }
                else
                {
                    ProcessBreak(ref curr, ref count, bookings[i]);
                    count = 1;
                }
            }
            ProcessBreak(curr, count);
            Console.WriteLine("----------------------------------------------------");
        }

        public void ProcessBreak(ref string curr, ref int count, Booking newBooking)
        {

            Console.WriteLine(String.Format("{0,-23} | {1,-10}", curr, count));

            curr = newBooking.GetCustomerName();
        }

        public void ProcessBreak(string curr, int count)
        {
            Console.WriteLine(String.Format("{0,-23} | {1,-10}", curr, count));
        }

        public void SortBookings()
        {
            for(int i = 0; i < Booking.GetCount() - 1; i++)
            {
                int min = i;
                for(int j = i + 1; j < Booking.GetCount(); j++)
                {

                    if(bookings[j].GetCustomerName().CompareTo(bookings[min].GetCustomerName()) < 0 || bookings[j].GetCustomerName().ToUpper() == bookings[min].GetCustomerName().ToUpper() && bookings[j].GetYear() <= bookings[min].GetYear())
                    {
                        min = j;
                    }
                }
                if(min != i)
                {
                    Swap(min, i);
                }
                Save();
            }
        }

        private void Swap(int x, int y)
        {
            Booking temp = bookings[x];
            bookings[x] = bookings[y];
            bookings[y] = temp;
        }
        public void Save()
        {
            StreamWriter outFile = new StreamWriter("transactions.txt");

            for(int i = 0; i < Booking.GetCount(); i++)
            {
                outFile.WriteLine(bookings[i].ToFile());
            }

            outFile.Close();
        }

        public void MonthlyHistoricalRevenueReport()
        {
            System.Console.WriteLine("\nMonthly Revenues:\n");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Year\t   | Month      | Total Revenue");
            Console.WriteLine("----------------------------------------------------");
            int currYear = bookings[0].GetYear();
            int currMonth = bookings[0].GetMonth();

            double yearTotal = bookings[0].GetCost();
            double monthTotal = bookings[0].GetCost();

            for( int i = 1; i < Booking.GetCount(); i++)
            {
                if(bookings[i].GetMonth() == currMonth && bookings[i].GetYear() == currYear)
                {
                    monthTotal += bookings[i].GetCost();
                }
                else
                {
                    ProcessBreakMonth(ref currYear, ref currMonth, ref monthTotal, bookings[i]);
                }
            }
            ProcessBreakMonth(currYear, currMonth, monthTotal);
            Console.WriteLine("----------------------------------------------------");
        }

        public void YearlyHistoricalRevenueReport()
        {
            System.Console.WriteLine("\nYearly Revenues:\n");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Year\t | Total Revenue");
            Console.WriteLine("----------------------------------------------------");
            int currYear = bookings[0].GetYear();
            int currMonth = bookings[0].GetMonth();

            double yearTotal = bookings[0].GetCost();
            double monthTotal = bookings[0].GetCost();

            for( int i = 1; i < Booking.GetCount(); i++)
            {
                if(bookings[i].GetYear() == currYear)
                {
                    yearTotal += bookings[i].GetCost();
                }
                else
                {
                    ProcessBreakYear(ref currYear, ref yearTotal, bookings[i]);
                }
            }
            ProcessBreakYear(currYear, monthTotal);
            Console.WriteLine("----------------------------------------------------");
        }

        public void ProcessBreakYear(ref int currYear, ref double yearTotal, Booking newBooking)
        {

            Console.WriteLine(String.Format("{0,-10} | {1,-10}", currYear, yearTotal));

            currYear = newBooking.GetYear();
            yearTotal = newBooking.GetCost();
        }

        public void ProcessBreakMonth(int currYear, int currMonth, double monthTotal)
        {
            Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,-10}", currYear, currMonth, monthTotal));
        }

        public void ProcessBreakYear(int currYear, double yearTotal)
        {
            Console.WriteLine(String.Format("{0,-10} | {1,-10}", currYear, yearTotal));
        }

        public void ProcessBreakMonth(ref int currYear, ref int currMonth, ref double monthTotal, Booking newBooking)
        {

            Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,-10}", currYear, currMonth, monthTotal));

            currYear = newBooking.GetYear();
            currMonth = newBooking.GetMonth();
            monthTotal = newBooking.GetCost();
        }

        public void SaveToFile()
        {
            System.Console.WriteLine("Would you like to save the report to a file?(Yes/No)\n");
            string answer = Console.ReadLine();

            if(answer.ToUpper() == "YES")
            {
                System.Console.WriteLine("What is the name of the file you'd like to save to?\n");
                string fileName = Console.ReadLine();

                StreamWriter outFile = new StreamWriter(fileName);

                for(int i = 0; i < Booking.GetCount(); i++)
                {
                    outFile.WriteLine(bookings[i].ToFile());
                }

                outFile.Close();
            }
        }
    }
}