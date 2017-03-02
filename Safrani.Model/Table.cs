using System;
using System.Collections.Generic;
using System.Text;

namespace Safrani.Model
{
    public enum Side { Port, Starboard, Bow, Stern }
    public class Table
    {
        public List<Dictionary<Side, Person>> FacingPirates = new List<Dictionary<Side, Person>>();

        public Table(Person p)
        {
            FacingPirates.Add(new Dictionary<Side, Person> { { Side.Bow, p } });
        }

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
