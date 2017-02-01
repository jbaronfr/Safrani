using System;
using System.Collections.Generic;
using System.Text;

namespace Safran.Scoring.Model
{
    public class Table
    {
        // public Seat Bow { get; set; }
        public List<Dictionary<Side, Person>> FacingPirates = new List<Dictionary<Side, Person>>();
        // public Seat Stern { get; set; }

        public void AddNewPirateLine()
        {
            FacingPirates.Add(new Dictionary<Side, Person>());
        }
        public void AddPirateAtEnd(Side side, Person pirate)
        {
            FacingPirates[FacingPirates.Count - 1].Add(side, pirate);
        }
    }
}
