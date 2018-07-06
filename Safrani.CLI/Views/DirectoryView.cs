using Safrani.Model;
using Safrani.Model.People;
using Safrani.Scoring;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Safrani.CLI.Views
{
    public static class DirectoryView
    {
        public static void SimpleList(IEnumerable<Person> plst)
        {
            foreach (var p in plst)
                Console.WriteLine(p.Id + " - " + p.Name + (p.IsGuest ? "" : " (Host)"));
        }

        public static void GroupList(IEnumerable<Person> plst)
        {
            foreach (var g in plst.SelectMany(g => g.Groups).Distinct())
            {
                Console.WriteLine(g.Id + " - " + g.Name);
            }
        }

        public static void DetailledList()
        {
            foreach (var p in Directory.GetList())
            {
                Console.WriteLine(p.Id + " - " + p.Name + (p.IsGuest ? "" : " (Host)"));
                Console.WriteLine("-> Relations :");
                foreach (var m in p.Groups.SelectMany(g => g.Members).Distinct())
                    if (m != p)
                        Console.WriteLine("\t" + m.Name + " - " + m.GetRelationWith(p).Title);
                Console.WriteLine();
            }
        }
    }
}
