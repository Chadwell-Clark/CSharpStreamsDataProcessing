using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerStats
{

    public class RootObject
    {
        public Player[] Player { get; set; }
    }

    public class Player
    {
        
        
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "goals_conceded")]
        public int GoalsConceded { get; set; }

        [JsonProperty(PropertyName = "goals_scored")]
        public int GoalsScored { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "points_per_game")]
        public double PointsPerGame { get; set; }

        [JsonProperty(PropertyName = "position")]
        public string Position { get; set; }

        [JsonProperty(PropertyName = "second_name")]
        public string SecondName { get; set; }

        [JsonProperty(PropertyName = "team_name")]
        public string TeamName { get; set; }

        [JsonProperty(PropertyName = "total_points")]
        public int TotalPoints { get; set; }

      
      
    }

}
