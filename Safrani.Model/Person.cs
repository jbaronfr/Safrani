using System.Collections.Generic;
using System.Linq;

namespace Safrani.Model
{
    public enum Relation { Soulmate, Friend, Relative, Enemy, Acquaintance, Unknown }
    public class Person
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public bool IsGuest { get; set; }
        //public bool NotAtEnds { get; set; }

        public Dictionary<Person, Relation> Relations = new Dictionary<Person, Relation>();

        public bool HasSoulmate()
        {
            return Relations.ContainsValue(Relation.Soulmate);
        }

        public Person GetSoulmate()
        {
            return Relations.FirstOrDefault(p => p.Value == Relation.Soulmate).Key;
        }

        private bool IsRelation(Person p)
        {
            return Relations.ContainsKey(p);
        }
        public Relation GetRelationWith(Person p)
        {
            if (IsRelation(p))
                return Relations[p];
            return Relation.Unknown;
        }
    }
}
