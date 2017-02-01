using System;
using System.Collections.Generic;
using System.Text;

namespace Safran.Scoring.Model
{
    public enum Side { Port, Starboard, Bow, Stern }
    public class Seat
    {
        public Side Side { get; set; }
        public Person Pirate { get; set; }
    }
}
