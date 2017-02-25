using Safrani.Model;
using System.Collections.Generic;

namespace Safrani.Data
{
    public static class People
    {
        private static int nextId = 0;
        private static List<Person> pList = new List<Person>();

        public static void AddPerson(Person p)
        {
            p.Id = nextId;
            pList.Add(p);
            nextId++;
            foreach (var r in p.Relations)
                r.Key.Relations.Add(p, r.Value);
        }

        public static bool Exists(string name)
        {
            return pList.Exists(p => p.Name == name);
        }

        public static List<Person> GetList()
        {
            return pList;
        }

        public static Person GetPerson(int id)
        {
            return pList.Find(p => p.Id == id);
        }
    }
}
