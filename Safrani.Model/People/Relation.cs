using System;
using System.Collections.Generic;
using System.Text;

namespace Safrani.Model.People
{
    public class Relation : Notion
    {
        public static Relation Unknown = new Relation() { Id = 0, Title = "Unknown", Importance = 0 };
        public static Relation Soulmate = new Relation() { Id = 1, Title = "Soulmate", Importance = sbyte.MaxValue };
        public static Relation Relative = new Relation() { Id = 2, Title = "Relative", Importance = 50 };
        public static Relation Friend = new Relation() { Id = 3, Title = "Friend", Importance = 50 };
        public static Relation Acquaintance = new Relation() { Id = 4, Title = "Acquaintance", Importance = 10 };
        public static Relation Dislike = new Relation() { Id = 5, Title = "Dislike", Importance = -100 };
        public static Relation Interest = new Relation() { Id = 6, Title = "Interest", Importance = 25 };

        public sbyte Importance { get; set; }

        public static implicit operator int(Relation r)
        {
            return r.Id;
        }
    }
}
