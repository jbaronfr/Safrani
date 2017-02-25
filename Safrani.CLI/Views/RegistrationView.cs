using Safrani.Model;
using Safrani.Scoring;
using System;
using System.Collections.Generic;
using System.Text;

namespace Safrani.CLI.Views
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
                int pid, relid;
                string spid, srelid;
                do
                {
                    var relations = p.Relations;
                    var others = new List<Person>(peopleList);
                    others.RemoveAll(pers => relations.ContainsKey(pers));
                    DirectoryView.SimpleList(others);

                    do
                    {
                        Console.WriteLine("Enter Person Id :");
                        spid = Console.ReadLine();
                    }
                    while (!int.TryParse(spid, out pid) && spid != "end");
                    if (spid == "end") break;

                    do
                    {
                        Console.WriteLine("Enter Relation Id :");
                        srelid = Console.ReadLine();
                    }
                    while (!int.TryParse(srelid, out relid) && srelid != "end");
                    if (srelid == "end") break;

                    if (Directory.GetList().Exists(pers => pers.Id == pid))
                        p.Relations.Add(Directory.GetById(pid), Strings.Relations[relid]);
                    else
                        continue;

                } while (spid != "end" && srelid != "end" && p.Relations.Count < Directory.GetList().Count);
            }

        }
    }
}
