using Safrani.Model;
using Safrani.Scoring;
using System;
using System.Collections.Generic;

namespace Safrani.CLI.Views
{
    public static class DirectoryView
    {
        public static void SimpleList(List<Person> plst)
        {
            foreach (var p in plst)
                Console.WriteLine(p.Id + " - " + p.Name + (p.IsGuest ? "" : " (Host)"));
        }

        public static void DetailledList()
        {
            foreach (var p in Directory.GetList())
            {
                Console.WriteLine(p.Id + " - " + p.Name + (p.IsGuest ? "" : " (Host)"));
                Console.WriteLine("-> Relations :");
                foreach (var r in p.Relations)
                    Console.WriteLine("\t" + r.Key.Name + " - " + r.Value);
                Console.WriteLine();
            }
        }
    }
}
