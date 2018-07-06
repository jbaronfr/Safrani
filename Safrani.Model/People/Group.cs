using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Safrani.Model.People;

namespace Safrani.Model.People
{
    public class Group : Label
    {
        private static int _id = 0;

        public string Name { get; set; }
        public Relation Relation { get; set; }

        public ISet<Person> Members {get;set;}

        public Group(string aName, Relation aRelation, params Person[] people)
        {
            Id = _id++;
            Name = aName;
            Relation = aRelation;
            Members = new HashSet<Person>(people);
            foreach (var p in people)
            {
                p.Groups.Add(this);
            }
        }
    }
}