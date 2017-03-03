using Safrani.CLI.Views;
using Safrani.Data;
using Safrani.Scoring;
using System;

namespace Safrani.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue ! ");
            string state = Console.ReadLine();

            if (state != "test")
            {
                Console.WriteLine("Hosts");

                RegistrationView.GetForm(forGuest: false);

                Console.WriteLine("Guests");

                RegistrationView.GetForm();
            }
            else
                People.LoadTestData();

            DirectoryView.DetailledList();

            TableView.Display(Calculation.ComputeBestTable());

            Console.ReadLine();
        }
    }
}