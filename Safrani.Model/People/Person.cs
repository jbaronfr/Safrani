using System;
using System.Collections.Generic;
using System.Linq;

namespace Safrani.Model.People
{
    public enum Gender { Woman, Man, Rainbow }

    public class Person : Thing
    {
        private static int _id = 0;

        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime? Birthdate { get; set; }
        public int? Age
        {
            get
            {
                if (Birthdate.HasValue)
                    return DateTime.Now.Year - Birthdate.Value.Year;
                return null;
            }
        }
        public virtual bool IsGuest { get; set; }
        public ISet<Group> Groups { get; set; }
        public bool NotAtEnds { get; set; }

        private Person _soulmate;
        public Person Soulmate
        {
            get
            {
                if(_soulmate == null)
                    _soulmate = Groups.FirstOrDefault(g => g.Relation == Relation.Soulmate)?.Members.FirstOrDefault();
                return _soulmate;
            }
            set
            {
                var grp = Groups.FirstOrDefault(g => g.Relation == Relation.Soulmate);
                if (grp == null)
                {
                    grp = new Group("Love" + Name + value.Name, Relation.Soulmate, this, value);
                }
                else
                {
                    grp.Members.Add(value);
                    value.Groups.Add(grp);
                }
                _soulmate = value;
            }
        }

        public Person() { Groups = new HashSet<Group>(); }

        private bool IsRelation(Person p)
        {
            return Groups.FirstOrDefault(g => g.Members.Contains(p)) != null;
        }
        public Relation GetRelationWith(Person p)
        {
            return
                Groups.Where(g => g.Members.Contains(p)).OrderByDescending(g => Math.Abs(g.Relation.Importance)).FirstOrDefault()?.Relation
                ?? Relation.Unknown;
        }
    }
}
