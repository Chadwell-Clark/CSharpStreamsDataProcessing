using System;
using System.IO;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;

namespace SoccerStats
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            //var files = directory.GetFiles("*.txt");
            //foreach (var file in files)
            //{
            //    Console.WriteLine(file.Name);
            //}
            var fileName = Path.Combine(directory.FullName, "SoccerGameResults.csv");
            var fileContents = ReadSoccerResults(fileName);
            //var fileContents = ReadFile(fileName);
            //Console.WriteLine(fileContents);
            //string[] fileLines = fileContents.Split(new char[] { '\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            //foreach (var line in fileLines)
            //{
            //    Console.WriteLine(line);
            //}
            //var file = new FileInfo(fileName);
            //if (file.Exists)
            //{
            //    using (var reader = new StreamReader(file.FullName)) 
            //    {
            //        Console.SetIn(reader);
            //        Console.WriteLine(Console.ReadLine());
            //    }
                
            //}
            
          
        }

        public static string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }

        public static List<string[]> ReadSoccerResults(string fileName)
        {
            var soccerResults = new List<string[]>();
            using (var reader = new StreamReader(fileName))
            {
                string line = "";
                //get rid of header line in csv
                reader.ReadLine();
                //while we have not hit the end of the lines of data ReadLine 
                while ((line = reader.ReadLine()) != null)
                {
                    // instantiate instance of GameResult class
                    var gameResult = new GameResult();
                    // store split line of data in values array
                    string[] values = line.Split(',');
                    //gameResult.GameDate = DateTime.Parse(values[0]);

                    DateTime gameDate;
                    // if there is a datetime in the values array index 0 store game date in the gameResult object as GameDate
                    // if there is no datetime skip 
                    if (DateTime.TryParse(values[0], out gameDate))
                    {
                        gameResult.GameDate = gameDate;
                    }
                    //add the split line to SoccerResults
                    soccerResults.Add(values);
                }
            }
            return soccerResults;

        }
    }
}
