using Safran.Scoring.Business;
using Safran.Scoring.Model;
using Safran.Scoring.CLI.Views;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hosts");

        RegistrationView.GetForm(forGuest : false);

        Console.WriteLine("Guests");

        RegistrationView.GetForm();

        DirectoryView.DetailledList();

        TableView.Display(Calculation.ComputeBestTable());

        Console.ReadLine();
    }
}