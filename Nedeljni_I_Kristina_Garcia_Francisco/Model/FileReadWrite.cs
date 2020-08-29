using System;
using System.IO;

namespace Nedeljni_I_Kristina_Garcia_Francisco.Model
{
    class FileReadWrite
    {
        private readonly string folderLocation = @"..\..\TextFiles";
        private readonly string randomNumbersFile = "ManagerAccess.txt";

        #region Delegate and Event
        public delegate void Notification();
        public event Notification OnNotification;
        internal void Notify()
        {
            if (OnNotification != null)
            {
                OnNotification();
            }
        }
        #endregion

        public int ReadRandomNumberFIle()
        {
            using (StreamReader reader = new StreamReader(folderLocation + @"\" + randomNumbersFile))
            {
                return int.Parse(reader.ReadLine());
            }
        }

        public void GenerateRandomNmuberToFile()
        {
            // Create Folder if it does not exist
            Directory.CreateDirectory(folderLocation);

            using (StreamWriter writer = new StreamWriter(folderLocation + @"\" + randomNumbersFile, append: false))
            {
                Random rng = new Random();
                writer.WriteLine(rng.Next(10000000, 100000000));
            }
        }
    }
}
