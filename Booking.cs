namespace mis_221_pa_5_rtcarlson1
{
    public class Booking
    {
        private int sessionID;
        private string customerName;
        private string customerEmail;
        private string sessionDate;
        private int month;
        private int day;
        private int year;
        private string sessionTime;
        private string trainerName;
        private int trainerID;
        private double cost;
        private string status = "Booked";
        static private int count;

        public Booking()
        {

        }
        public Booking(int sessionID, string customerName, string customerEmail, string sessionDate, string sessionTime, string trainerName, int trainerID, double cost, string status)
        {
            this.sessionID = sessionID;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.sessionDate = sessionDate;
            this.sessionTime = sessionTime;
            this.trainerName = trainerName;
            this.trainerID = trainerID;
            this.cost = cost;
            this.status = status;

            string[] temp = sessionDate.Split('/');
            this.month = int.Parse(temp[0]);
            this.day = int.Parse(temp[1]);
            this.year = int.Parse(temp[2]);
        }

        public int GetSessionID()
        {
            return sessionID;
        }
        public void SetSessionID(int sessionID)
        {
            this.sessionID = sessionID;
        }
        public double GetCost()
        {
            return cost;
        }
        public void SetCost(double cost)
        {
            this.cost = cost;
        }
        public string GetCustomerName()
        {
            return customerName;
        }
        public void SetCustomerName(string customerName)
        {
            this.customerName = customerName;
        }
        public string GetCustomerEmail()
        {
            return customerEmail;
        }
        public void SetCustomerEmail(string customerEmail)
        {
            this.customerEmail = customerEmail;
        }
        public string GetSessionDate()
        {
            return sessionDate;
        }
        public void SetSessionDate(string sessionDate)
        {
            this.sessionDate = sessionDate;
        }
        public int GetMonth()
        {
            return month;
        }
        public int GetDay()
        {
            return day;
        }
        public int GetYear()
        {
            return year;
        }
        public string GetSessionTime()
        {
            return sessionTime;
        }
        public void SetSessionTime(string sessionTime)
        {
            this.sessionTime = sessionTime;
        }
        public string GetTrainerName()
        {
            return trainerName;
        }
        public void SetTrainerName(string trainerName)
        {
            this.trainerName = trainerName;
        }
        public int GetTrainerID()
        {
            return trainerID;
        }
        public void SetTrainerID(int trainerID)
        {
            this.trainerID = trainerID;
        }
        public string GetStatus()
        {
            return status;
        }
        public void SetStatus(string status)
        {
            this.status = status;
        }
        static public void SetCount(int count)
        {
            Booking.count = count;
        }
        static public void IncCount()
        {
            Booking.count++;
        }
        static public void DecCount()
        {
            Booking.count--;
        }
        static public int GetCount()
        {
            return count;
        }
        public override string ToString()
        {
            return $"Session ID: {this.sessionID}\nCustomer Name: {this.customerName}\nCustomer Email: {this.customerEmail}\nDate: {this.sessionDate}\nTime: {this.sessionTime}\nTrainer Name: {this.trainerName}\nTrainer ID: {this.trainerID}\nStatus: {this.status}\n";
        }
        public string ToFile()
        {
            return $"{this.sessionID}#{this.customerName}#{this.customerEmail}#{this.sessionDate}#{this.sessionTime}#{this.trainerName}#{this.trainerID}#{this.cost}#{this.status}";
        }
    }
}