using System;
using System.IO;

namespace FolderTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //  We find the current location of the project
            string CurrentDirectory = Environment.CurrentDirectory;
            DirectoryInfo TestingInfo = new DirectoryInfo(@"Testing");
            // We will check if there is a Testing folder, delete it and re-create it.
            if (TestingInfo.Exists)
            {
                Directory.Delete(TestingInfo.FullName, true);
                Console.WriteLine("'Testing' Folder Removed");
                Console.WriteLine("-----------------------------");
            }
            Directory.CreateDirectory(@"Testing");
            Console.WriteLine("'Testing' Folder Created");
            // We create folders in the test folder.
            Directory.CreateDirectory(@"Testing/FolderCheck1/FolderCheck2/FolderCheck3");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("'FolderCheck1', 'FolderCheck2' and 'FolderCheck3' Folders Created");
            Console.WriteLine("-----------------------------------------------------------------------");
            // We create files in the folders we created in the test folder.
            FileStream fileStream = File.Create(@"Testing/OrxanAzTU.html");
            fileStream.Close();
            FileStream fileStream1 = File.Create(@"Testing/FolderCheck1/Check1.html");
            fileStream1.Close();
            FileStream fileStream2 = File.Create(@"Testing/FolderCheck1/FolderCheck2/Check2.txt");
            fileStream2.Close();
            FileStream fileStream3 = File.Create(@"Testing/FolderCheck1/FolderCheck2/FolderCheck3/Check3.txt");
            fileStream3.Close();
            Console.WriteLine("'OrxanAzTU.html', 'Check1.html', 'Check2.txt' and 'Check3.txt' Files Created");
            Console.WriteLine("---------------------------------------------------------------------------------");
            // We specify the location of the folder to be copied.
            string NewDirectory = Path.Combine(CurrentDirectory, "TestingCopy");          
            DirectoryInfo NewDirectoryInfo = new DirectoryInfo(NewDirectory);
            // If we check if there is a folder to be copied, we delete it and re-create it.
            if (NewDirectoryInfo.Exists)
            {                
                Directory.Delete(NewDirectoryInfo.FullName,true);
                Console.WriteLine("'TestingCopy' Folder Removed");
                Console.WriteLine("---------------------------------");
            }          
            Directory.CreateDirectory(NewDirectoryInfo.FullName);
            Console.WriteLine("'TestingCopy' Folder Created");
            CopyRekursiv("Testing", NewDirectory);
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Directorys and Files Copy Completed");
            Console.WriteLine("-------------------------------------------\nFinished\n-----------------------");
        }
        /// <summary>
        /// Method for copying folders and files
        /// </summary>
        /// <param name="current">Includes where the project is currently located</param>
        /// <param name="newdirectory">Includes the location of the new folder where the project is currently located</param>
        public static void CopyRekursiv(string current, string newdirectory)
        {
            //Folder Copy
            foreach (string folder in Directory.GetDirectories(current, "*.*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(folder.Replace(current, newdirectory));
            }
            //File Copy
            foreach (string file in Directory.GetFiles(current, "*.*",SearchOption.AllDirectories))
            {
                File.Copy(file, file.Replace(current, newdirectory), true);
            }
        }
    }
}