using System;
using System.Collections.Generic;
using System.Text;

namespace Safran.Scoring.Model
{
    public enum Relation { Soulmate, Friend, Relative, Enemy, Acquaintance }
    public class Person
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public bool IsGuest { get; set; }

        public Dictionary<Person, Relation> Relations = new Dictionary<Person, Relation>();
    }
}
