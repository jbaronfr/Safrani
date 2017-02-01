using Safran.Scoring.Business;
using Safran.Scoring.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Safran.Scoring.CLI.Views
{
    public static class RegistrationView
    {
        public static void GetForm(bool forGuest = true)
        {
            Console.WriteLine("Enter List (type 'end' to finish):");
            string name = "";
            do
            {
                Console.WriteLine("Enter Name :");
                name = Console.ReadLine();
                if (name == "end") break;
                bool success = Registration.IsAvailable(name);
                if (success)
                {
                    Person newOne = new Person
                    {
                        Name = name,
                        IsGuest = forGuest,
                    };
                    AddRelations(ref newOne);
                    Registration.AddPerson(newOne);
                }
                else
                    Console.WriteLine("Name already exists, please find another");
            } while (name != "end");
        }

        public static void AddRelations(ref Person p)
        {
            List<Person> peopleList = Directory.GetList();
            if (peopleList.Count > 0)
            {
                Console.WriteLine("Relations :");
                foreach (var rtype in Strings.Relations)
                    Console.WriteLine(rtype.Key + " - " + rtype.Value);
                Console.WriteLine("OK, add some relations ? ('end' to finish):");
                string pid = ""; int relid = -1;
                do
                {
                    DirectoryView.SimpleList();

                    Console.WriteLine("Enter Person Id :");
                    pid = Console.ReadLine();
                    if (pid == "end") break;

                    Console.WriteLine("Enter Relation Id :");
                    int.TryParse(Console.ReadLine(), out relid) ;
                    p.Relations.Add(Directory.GetById(pid), Strings.Relations[relid]);

                } while (pid != "end");
            }

        }
    }
}
