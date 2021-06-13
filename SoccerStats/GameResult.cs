using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerStats
{
    public class GameResult
    {

        public DateTime GameDate { get; set; }
        public string TeamName { get; set; }
        public HomeOrAway HomeOrAway { get; set; }
        public int Goals { get; set; }
        public int GoalAttempts { get; set; }
        public int ShotsOnGoal { get; set; }
        public int ShotsOffGoal { get; set; }
        public double PossesionPercent {get; set;}

        // Only calculated when we use it saves memory
        public double ConversionRate
        {
            get
            {
                return (double)Goals / (Double)GoalAttempts;
            }
        }
       


    }
    // Enum has two possible constant values, each has backing integer starting with 0
    // can change the backing integer and change its type through inheritance
    public enum HomeOrAway
    { 
        Home,
        Away
    }
}
