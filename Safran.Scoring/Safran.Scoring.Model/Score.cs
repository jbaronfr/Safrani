using System;
using System.Collections.Generic;
using System.Text;

namespace Safran.Scoring.Model
{
    public enum Mark { Nope = -6, Bad = -3, Meh = -1, Neutral = 0, Yeah = 1, Good = 3, Top = 6, Best = 10 }
    public enum Position { Front, Side, Diagonal }
    public class Score
    {
        public Dictionary<Position, Mark> Value = new Dictionary<Position, Mark>();
    }
}
