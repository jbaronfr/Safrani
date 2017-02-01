using Safran.Scoring.Business;
using Safran.Scoring.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Safran.Scoring.CLI.Views
{
    public static class DirectoryView
    {
        public static void SimpleList()
        {
            foreach (var p in Directory.GetList())
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
