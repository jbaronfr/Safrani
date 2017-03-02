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

        public static void LoadTestData()
        {
            Person Julien = new Person { Name = "Julien", Gender = Gender.Man, IsGuest = false };
            Person Justine = new Person { Name = "Justine", Gender = Gender.Woman, IsGuest = false };
            Person Theo = new Person { Name = "Theo", Gender = Gender.Man, IsGuest = true };
            Person Bapt = new Person { Name = "Bapt", Gender = Gender.Man, IsGuest = true };
            Person Nathou = new Person { Name = "Nathou", Gender = Gender.Woman, IsGuest = true };
            Person Benji = new Person { Name = "Benji", Gender = Gender.Man, IsGuest = true };
            Person Lancelot = new Person { Name = "Lancelot", Gender = Gender.Man, IsGuest = true };
            Person Emeline = new Person { Name = "Emeline", Gender = Gender.Woman, IsGuest = true };
            Person Cyril = new Person { Name = "Cyril", Gender = Gender.Man, IsGuest = true };
            Person Bernard = new Person { Name = "Bernard", Gender = Gender.Man, IsGuest = true };
            Person Arnaud = new Person { Name = "Arnaud", Gender = Gender.Man, IsGuest = true };
            Person Alison = new Person { Name = "Alison", Gender = Gender.Woman, IsGuest = true };
            Person Pierre = new Person { Name = "Pierre", Gender = Gender.Man, IsGuest = true };
            Person Quentin = new Person { Name = "Quentin", Gender = Gender.Man, IsGuest = true };
            Person Ophelie = new Person { Name = "Ophelie", Gender = Gender.Woman, IsGuest = true };
            Person Antoine = new Person { Name = "Antoine", Gender = Gender.Man, IsGuest = true };
            Person Simon = new Person { Name = "Simon", Gender = Gender.Man, IsGuest = true };
            Person Adeline = new Person { Name = "Adeline", Gender = Gender.Woman, IsGuest = true };
            Person Greg = new Person { Name = "Greg", Gender = Gender.Man, IsGuest = true };
            Person Marie = new Person { Name = "Marie", Gender = Gender.Woman, IsGuest = true };
            Person Yannick = new Person { Name = "Yannick", Gender = Gender.Man, IsGuest = true };
            Person Sylvain = new Person { Name = "Sylvain", Gender = Gender.Man, IsGuest = true };
            Person Adele = new Person { Name = "Adele", Gender = Gender.Woman, IsGuest = true };
            Person Celine = new Person { Name = "Celine", Gender = Gender.Woman, IsGuest = true };
            Person Charly = new Person { Name = "Charly", Gender = Gender.Man, IsGuest = true };
            Person Mylene = new Person { Name = "Mylene", Gender = Gender.Woman, IsGuest = true };
            Person Anais = new Person { Name = "Anais", Gender = Gender.Woman, IsGuest = true };
            Person Aurore = new Person { Name = "Aurore", Gender = Gender.Woman, IsGuest = true };
            Person Alain = new Person { Name = "Alain", Gender = Gender.Man, IsGuest = true };
            Person Nico = new Person { Name = "Nico", Gender = Gender.Man, IsGuest = true };
        }
    }
}
