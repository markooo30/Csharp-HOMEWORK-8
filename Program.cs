

using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;
namespace Reader_HOMEWORK
{
//    Create a C# console application that reads a text file and saves it in a list of
//strings.
//    The application should ask the user to enter text and then print all lines
//containing that text.
//To terminate the application, the user needs to enter an empty string

    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> ListOfStrings = new List<string>();

            string appPathHomework = "D:\\C# Advanced";
            string homeworkDir = appPathHomework + "\\Homework08";
            string filePath = homeworkDir + "\\Homework.txt";
            
            if (Directory.Exists(homeworkDir) == false)
            {
                Directory.CreateDirectory(homeworkDir);
            }
            if (File.Exists(filePath) == false)
            {
                File.Create(filePath).Close();
            }

            using (StreamWriter streamWriterHomework = new StreamWriter(filePath))
            {
                streamWriterHomework.WriteLine("1. Hello");
                streamWriterHomework.WriteLine("2. World");
                streamWriterHomework.WriteLine("3. Yes");
                streamWriterHomework.WriteLine("4. Cat");
                streamWriterHomework.WriteLine("5. Dog");
                streamWriterHomework.WriteLine("6. Hello again");
            }

            
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    ListOfStrings.Add(line);
                }
            }

            Console.WriteLine("Lines from the file:");
            foreach (string item in ListOfStrings)
            {
                Console.WriteLine(item);
            }


            while (true)
            {
                Console.Write("Enter text to search (or press Enter to exit): ");
                string searchText = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(searchText))
                    break; 

                var matches = ListOfStrings.Where(line => line.Contains(searchText)).ToList();

                if (matches.Any())
                {
                    foreach (string matchedLine in matches)
                    {
                        Console.WriteLine(matchedLine);
                    }
                }
                else
                {
                    Console.WriteLine($"No lines containing \"{searchText}\" found.");
                }
            }
            
        }
    }
}















