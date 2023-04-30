namespace mis_221_pa_5_rtcarlson1
{
    public class TrainerUtility
    {
        private Trainer[] trainers;

        public TrainerUtility(Trainer[] trainers)
        {
            this.trainers = trainers;
        }

        public void GetAllTrainersFromFile()
        {
            StreamReader inFile = new StreamReader("trainers.txt");
            Trainer NewTrainer = new Trainer();

            Trainer.SetCount(0);
            string line = inFile.ReadLine();
            while(line != null)
            {
                string[] temp = line.Split('#');
                trainers[Trainer.GetCount()] = new Trainer(int.Parse(temp[0]), temp[1], temp[2], temp[3]);
                Trainer.IncCount();
                line = inFile.ReadLine();
            }

            inFile.Close();
        }

        public void PrintAllTrainers()
        {
            for(int i = 0; i < Trainer.GetCount(); i++)
            {
                System.Console.WriteLine(trainers[i].ToString());
            }
        }

        public void AddTrainer()
        {
            Trainer myTrainer = new Trainer();

            //Enter ID as one more than variable trainerID. Never decrease this number

            System.Console.WriteLine("\nPlease enter the trainers ID:");
            myTrainer.SetTrainerID(int.Parse(Console.ReadLine()));

            System.Console.WriteLine("\nPlease enter the trainers name:");
            myTrainer.SetTrainerName(Console.ReadLine());
            System.Console.WriteLine("\nPlease enter the trainers mailing address:");
            myTrainer.SetMailingAddress(Console.ReadLine());
            System.Console.WriteLine("\nPlease enter the trainers email:");
            myTrainer.SetTrainerEmail(Console.ReadLine());

            trainers[Trainer.GetCount()] = myTrainer;
            Trainer.IncCount();

            Save();
        }

        public void Save()
        {
            StreamWriter outFile = new StreamWriter("trainers.txt");

            for(int i = 0; i < Trainer.GetCount(); i++)
            {
                outFile.WriteLine(trainers[i].ToFile());
            }

            outFile.Close();
        }

        public int Find(string searchVal)
        {
            for(int i = 0; i < Trainer.GetCount(); i++)
            {
                if(trainers[i].GetTrainerName().ToUpper() == searchVal.ToUpper())
                {
                    return i;
                }
            }
            return -1;
        }

        public void DeleteTrainer()
        {
            System.Console.WriteLine("\nWhat is the name of the trainer you'd like to delete:\n");
            string searchVal = Console.ReadLine();
            int foundIndex = Find(searchVal);

            if(foundIndex != -1)
            {
                for(int i = foundIndex; i < Trainer.GetCount() - 1; i++)
                {
                    trainers[i].SetTrainerID(trainers[i + 1].GetTrainerID());
                    trainers[i].SetTrainerName(trainers[i + 1].GetTrainerName());
                    trainers[i].SetMailingAddress(trainers[i + 1].GetMailingAddress());
                    trainers[i].SetTrainerEmail(trainers[i + 1].GetTrainerEmail());
                }

                Trainer.DecCount();
            }
            else
            {
                System.Console.WriteLine("\nTrainer not found");
            }

            Save();
        }

        public void EditTrainer()
        {
            System.Console.WriteLine("\nWhat is the name of the trainer you'd like to update:\n");
            string searchVal = Console.ReadLine();
            int foundIndex = Find(searchVal);

            if(foundIndex != -1)
            {
                System.Console.WriteLine("\nPlease enter the trainers ID:\n");
                trainers[foundIndex].SetTrainerID(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please enter the trainers name:\n");
                trainers[foundIndex].SetTrainerName(Console.ReadLine());
                System.Console.WriteLine("Please enter the trainers mailing address:\n");
                trainers[foundIndex].SetMailingAddress(Console.ReadLine());
                System.Console.WriteLine("Please enter the trainers email:\n");
                trainers[foundIndex].SetTrainerEmail(Console.ReadLine());

                Save();
            }
            else
            {
                System.Console.WriteLine("\nTrainer not found");
            }
        }
    }
}