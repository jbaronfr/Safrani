using Safrani.CLI.Views;
using Safrani.Scoring;
using System;

namespace Safrani.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hosts");

            RegistrationView.GetForm(forGuest: false);

            Console.WriteLine("Guests");

            RegistrationView.GetForm();

            DirectoryView.DetailledList();

            TableView.Display(Calculation.ComputeBestTable());

            Console.ReadLine();
        }
    }
}