using Safrani.Model;
using System;
using System.Linq;

namespace Safrani.CLI.Views
{
    public static class TableView
    {
        public static void Display(Table aTable)
        {
            Console.WriteLine("\t" + aTable.FacingPirates.FirstOrDefault().FirstOrDefault().Value.Name);
            for (int i = 1; i < aTable.FacingPirates.Count - 1; i++)
            {
                Console.WriteLine(aTable.FacingPirates[i][Side.Port].Name + " - " + aTable.FacingPirates[i][Side.Starboard].Name);
            }
            if (aTable.FacingPirates.LastOrDefault().Count > 1)
                Console.WriteLine(aTable.FacingPirates.LastOrDefault()[Side.Port].Name + " - " + aTable.FacingPirates.LastOrDefault()[Side.Starboard].Name);
            else
                Console.WriteLine("\t" + aTable.FacingPirates.LastOrDefault().FirstOrDefault().Value.Name);
        }
    }
}
