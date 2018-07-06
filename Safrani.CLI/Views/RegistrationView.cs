using Safrani.Data;
using Safrani.Model;
using Safrani.Model.People;
using Safrani.Scoring;
using System;
using System.Collections.Generic;
using System.Linq;
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
                Console.WriteLine("Relations types :");
                foreach (var rtype in Strings.Relations)
                    Console.WriteLine(rtype.Key + " - " + rtype.Value.Title);
                Console.WriteLine("OK, add some relations ? ('end' to finish):");
                int pid, relid, grpid;
                string spid, srelid, sgrpid;
                do
                {
                    var relations = p.Groups;
                    var others = new List<Person>(peopleList);
                    others.RemoveAll(pers => relations.Overlaps(pers.Groups));
                    DirectoryView.SimpleList(others);

                    do
                    {
                        Console.WriteLine("Enter Person Id :");
                        spid = Console.ReadLine();
                    }
                    while (!int.TryParse(spid, out pid) && spid != "end");
                    if (spid == "end") break;
                    if (!Directory.GetList().Exists(pers => pers.Id == pid)) continue;

                    DirectoryView.GroupList(People.GetList());
                    do
                    {
                        Console.WriteLine("Enter Group Id, 'new' pour créer :");
                        sgrpid = Console.ReadLine();
                    }
                    while (!int.TryParse(sgrpid, out grpid) && sgrpid != "end" && sgrpid != "new");
                    if (sgrpid == "end") break;
                    Person r = People.GetPerson(pid);
                    Group grp = null;
                    if (sgrpid == "new")
                    {
                        do
                        {
                            Console.WriteLine("Enter Relation Id :");
                            srelid = Console.ReadLine();
                        }
                        while (!int.TryParse(srelid, out relid) && srelid != "end");
                        if (srelid == "end") break;
                        var rel = Strings.Relations[relid];
                        grp = new Group(rel.Title + p.Name + r.Name, rel, p, r);
                        continue;
                    }
                    else
                        grp = People.GetGroup(grpid);

                    if (grp != null)
                    {
                        grp.Members.Add(p);
                        grp.Members.Add(r);
                        p.Groups.Add(grp);
                        r.Groups.Add(grp);
                    }
                    else
                        continue;

                } while (spid != "end" && p.Groups.SelectMany(g => g.Members).Distinct().Count() < Directory.GetList().Count);
            }

        }
    }
}
