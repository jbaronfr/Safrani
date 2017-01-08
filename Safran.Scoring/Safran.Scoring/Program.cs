using Safran.Scoring.Business;
using Safran.Scoring.Model;
using Safran.Scoring.Views;
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

        Console.ReadLine();
    }
}