using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerStats
{
    class PlayerComparer : IComparer<Player>
    {
        public int Compare(Player x, Player y)
        {
            return x.PointsPerGame.CompareTo(y.PointsPerGame) * -1;
            //if (x.PointsPerGame < y.PointsPerGame)
            //{
            //    return -1;
            //}
            //else if (x.PointsPerGame == y.PointsPerGame)
            //{
            //    return 0;
            //}
            //else if (x.PointsPerGame > y.PointsPerGame)
            //{
            //    return 1;
            //}
            //return 0;
        }
    }
}
