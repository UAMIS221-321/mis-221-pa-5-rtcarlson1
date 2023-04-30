namespace mis_221_pa_5_rtcarlson1
{
    public class Listing
    {
        private int listingID;
        private string trainerName;
        private string date;
        private string time;
        private double cost;
        private bool taken;
        static private int count;

        public Listing()
        {

        }
        public Listing(int listingID, string trainerName, string date, string time, double cost, bool taken)
        {
            this.listingID = listingID;
            this.trainerName = trainerName;
            this.date = date;
            this.time = time;
            this.cost = cost;
            this.taken = taken;
        }

        public int GetListingID()
        {
            return listingID;
        }
        public void SetListingID(int listingID)
        {
            this.listingID = listingID;
        }
        public string GetTrainerName()
        {
            return trainerName;
        }
        public void SetTrainerName(string trainerName)
        {
            this.trainerName = trainerName;
        }
        public string GetDate()
        {
            return date;
        }
        public void SetDate(string date)
        {
            this.date = date;
        }
        public string GetTime()
        {
            return time;
        }
        public void SetTime(string time)
        {
            this.time = time;
        }
        public double GetCost()
        {
            return cost;
        }
        public void SetCost(double cost)
        {
            this.cost = cost;
        }
        public bool GetTaken()
        {
            return taken;
        }
        public void SetTaken(bool taken)
        {
            this.taken = taken;
        }
        public void ListingTaken(bool taken)
        {
            this.taken = !taken;
        }
        static public void SetCount(int count)
        {
            Listing.count = count;
        }
        static public void IncCount()
        {
            Listing.count++;
        }
        static public void DecCount()
        {
            Listing.count--;
        }
        static public int GetCount()
        {
            return count;
        }

        public override string ToString()
        {
            return $"Listing ID: {this.listingID}\nTrainer Name: {this.trainerName}\nDate: {this.date}\nTime:{this.time}\nCost: ${this.cost}\nTaken: {this.taken}\n";
        }

        public string ToFile()
        {
            return $"{this.listingID}#{this.trainerName}#{this.date}#{this.time}#{this.cost}#{this.taken}";
        }
    }
}