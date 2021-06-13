using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
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
            fileName = Path.Combine(directory.FullName, "players.json");
            var players = DeserializePlayers(fileName);

            foreach (var player in players)
            {
                Console.WriteLine(player.FirstName);
             }
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

        public static List<GameResult> ReadSoccerResults(string fileName)
        {
            var soccerResults = new List<GameResult>();
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
                    gameResult.TeamName = values[1];
                    HomeOrAway homeOrAway;
                    if (Enum.TryParse(values[2], out homeOrAway))
                    {
                        gameResult.HomeOrAway = homeOrAway;
                    }
                    int parseInt;
                    if (int.TryParse(values[3], out parseInt))
                    {
                        gameResult.Goals = parseInt;
                    }
                    if (int.TryParse(values[4], out parseInt))
                    {
                        gameResult.GoalAttempts = parseInt;
                    }
                    if (int.TryParse(values[5], out parseInt))
                    {
                        gameResult.ShotsOnGoal = parseInt;
                    }
                    if (int.TryParse(values[6], out parseInt))
                    {
                        gameResult.ShotsOffGoal = parseInt;
                    }

                    double possessionPercent;
                    if (double.TryParse(values[7], out possessionPercent))
                    {
                        gameResult.PossesionPercent = possessionPercent;
                    }
                    

                    soccerResults.Add(gameResult);
                }
            }
            return soccerResults;

        }

        public static List<Player> DeserializePlayers(string fileName)
        {
            var players = new List<Player>();
            var serializer = new JsonSerializer();
            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
            {

                players = serializer.Deserialize<List<Player>>(jsonReader);
            }
            return players;
        }
    }
}
