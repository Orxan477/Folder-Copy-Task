using System;
using System.IO;

namespace FolderTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string CurrentDirectory = Environment.CurrentDirectory;
            DirectoryInfo TestingInfo = new DirectoryInfo(@"Testing");
            if (TestingInfo.Exists)
            {
                Directory.Delete(TestingInfo.FullName, true);
                Console.WriteLine("'Testing' Folder Removed");
                Console.WriteLine("-----------------------------");
            }
            Directory.CreateDirectory(@"Testing");
            Console.WriteLine("'Testing' Folder Created");
            Directory.CreateDirectory(@"Testing/FolderCheck1/FolderCheck2/FolderCheck3");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("'FolderCheck1', 'FolderCheck2' and 'FolderCheck3' Folders Created");
            Console.WriteLine("-----------------------------------------------------------------------");
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
            string NewDirectory = Path.Combine(CurrentDirectory, "TestingCopy");          
            DirectoryInfo NewDirectoryInfo = new DirectoryInfo(NewDirectory);
            if (NewDirectoryInfo.Exists)
            {                
                Directory.Delete(NewDirectoryInfo.FullName,true);
                Console.WriteLine("'TestingCopy' Folder Removed");
                Console.WriteLine("---------------------------------");
            }          
            Console.WriteLine("'TestingCopy' Folder Created");
            Directory.CreateDirectory(NewDirectoryInfo.FullName);
            CopyRekursiv("Testing", NewDirectory);
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("Directorys and Files Copy Completed");
            Console.WriteLine("-------------------------------------------\nFinished\n-----------------------");
        }
        public static void CopyRekursiv(string current, string newdirectory)
        {
            //Folder
            foreach (string folder in Directory.GetDirectories(current, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(folder.Replace(current, newdirectory));
            }
            //File
            foreach (string file in Directory.GetFiles(current, "*.*",SearchOption.AllDirectories))
            {
                File.Copy(file, file.Replace(current, newdirectory), true);
            }
        }
    }
}