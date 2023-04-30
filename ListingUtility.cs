namespace mis_221_pa_5_rtcarlson1
{
    public class ListingUtility
    {
        private Listing[] listings;

        public ListingUtility(Listing[] listings)
        {
            this.listings = listings;
        }

        public void GetAllListingsFromFile()
        {
            StreamReader inFile = new StreamReader("listings.txt");
            Listing NewListing = new Listing();

            Listing.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split('#');
                listings[Listing.GetCount()] = new Listing(int.Parse(temp[0]), temp[1], temp[2], temp[3], double.Parse(temp[4]), bool.Parse(temp[5]));
                Listing.IncCount();
                line = inFile.ReadLine();
            }

            inFile.Close();
        }

        public void PrintAllListings()
        {
            for(int i = 0; i < Listing.GetCount(); i++)
            {
                System.Console.WriteLine(listings[i].ToString());
            }
        }

        public void PrintAllAvailableListings()
        {
            for(int i = 0; i < Listing.GetCount(); i++)
            {
                if(listings[i].GetTaken() == false)
                {
                    System.Console.WriteLine(listings[i].ToString());
                }
            }
        }

        public void AddListing()
        {
            Listing myListing = new Listing();

            //Do we enter listing ID or does the user?

            System.Console.WriteLine("\nPlease enter the listing ID:");
            myListing.SetListingID(int.Parse(Console.ReadLine()));

            System.Console.WriteLine("\nPlease enter the trainers name:");
            myListing.SetTrainerName(Console.ReadLine());
            System.Console.WriteLine("\nPlease enter the date of the listing:");
            myListing.SetDate(Console.ReadLine());
            System.Console.WriteLine("\nPlease enter the time of the listing:");
            myListing.SetTime(Console.ReadLine());
            System.Console.WriteLine("\nPlease enter the listing cost:");
            myListing.SetCost(double.Parse(Console.ReadLine()));

            listings[Listing.GetCount()] = myListing;
            Listing.IncCount();

            Save();
        }

        public void Save()
        {
            StreamWriter outFile = new StreamWriter("listings.txt");

            for(int i = 0; i < Listing.GetCount(); i++)
            {
                outFile.WriteLine(listings[i].ToFile());
            }

            outFile.Close();
        }

        public int Find(int searchVal)
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

        public void DeleteListing()
        {
            System.Console.WriteLine("\nWhat is the ID of the listing you'd like to delete:");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if(foundIndex != -1)
            {
                for(int i = foundIndex; i < Listing.GetCount() - 1; i++)
                {
                    listings[i].SetListingID(listings[i + 1].GetListingID());
                    listings[i].SetTrainerName(listings[i + 1].GetTrainerName());
                    listings[i].SetDate(listings[i + 1].GetDate());
                    listings[i].SetTime(listings[i + 1].GetTime());
                    listings[i].SetCost(listings[i + 1].GetCost());
                    listings[i].SetTaken(listings[i + 1].GetTaken());
                }

                Listing.DecCount();
            }
            else
            {
                System.Console.WriteLine("Listing not found");
            }

            Save();
        }

        public void EditListing()
        {
            System.Console.WriteLine("\nWhat is the ID of the listing you'd like to update:\n");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if(foundIndex != -1)
            {
                System.Console.WriteLine("Please enter the listing ID:");
                listings[foundIndex].SetListingID(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("\nPlease enter the trainers name:");
                listings[foundIndex].SetTrainerName(Console.ReadLine());
                System.Console.WriteLine("\nPlease enter the date of the listing:");
                listings[foundIndex].SetDate(Console.ReadLine());
                System.Console.WriteLine("\nPlease enter the time of the listing:");
                listings[foundIndex].SetTime(Console.ReadLine());
                System.Console.WriteLine("\nPlease enter the listing cost:");
                listings[foundIndex].SetCost(double.Parse(Console.ReadLine()));

                Save();
            }
            else
            {
                System.Console.WriteLine("Listing not found");
            }
        }
    }
}