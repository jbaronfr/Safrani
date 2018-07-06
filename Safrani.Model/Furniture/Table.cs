using System;
using System.Collections.Generic;
using System.Text;
using Safrani.Model.People;

namespace Safrani.Model
{
    public enum Side { Port, Starboard, Bow, Stern }
    public enum Shape { Rectangle, Square, Circle }

    public class Table : Object
    {
        public uint TotalCapacity { get; set; }

        public uint _sideCapacity;

        public uint SideCapacity
        {
            get
            {
                switch (Shape)
                {
                    case Shape.Circle:
                        return TotalCapacity;
                    case Shape.Square:
                        return TotalCapacity / 4;
                }
                return _sideCapacity;
            }
            set { _sideCapacity = value; }
        }

        public Shape Shape { get; set; }

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
