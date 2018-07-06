using Safrani.Model;
using Safrani.Model.People;
using System.Collections.Generic;
using System.Linq;

namespace Safrani.Data
{
    public static class People
    {
        private static int nextId = 1;
        private static List<Person> pList = new List<Person>();

        public static void AddPerson(Person p)
        {
            p.Id = nextId;
            pList.Add(p);
            nextId++;
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

        public static Group GetGroup(int id)
        {
            return pList.SelectMany(p => p.Groups).FirstOrDefault(g => g.Id == id);
        }

        public static void LoadTestData()
        {
            #region TestData
            Person Julien = new Host { Name = "Julien", Gender = Gender.Man };
            Person Justine = new Host { Name = "Justine", Gender = Gender.Woman };
            Person Theo = new Guest { Name = "Theo", Gender = Gender.Man };
            Person Nathou = new Guest { Name = "Nathou", Gender = Gender.Woman };
            Person Benji = new Guest { Name = "Benji", Gender = Gender.Man };
            Person Lancelot = new Guest { Name = "Lancelot", Gender = Gender.Man };
            Person Emeline = new Guest { Name = "Emeline", Gender = Gender.Woman };
            Person Cyril = new Guest { Name = "Cyril", Gender = Gender.Man, Soulmate = Emeline };
            Person Bernard = new Guest { Name = "Bernard", Gender = Gender.Man };
            Person Alison = new Guest { Name = "Alison", Gender = Gender.Woman, Soulmate = Bernard };
            Person Pierre = new Guest { Name = "Pierre", Gender = Gender.Man };
            Person Quentin = new Guest { Name = "Quentin", Gender = Gender.Man };
            Person Arnaud = new Guest { Name = "Arnaud", Gender = Gender.Man };
            Person Ophelie = new Guest { Name = "Ophelie", Gender = Gender.Woman, Soulmate = Arnaud };
            Person Antoine = new Guest { Name = "Antoine", Gender = Gender.Man };
            Person Adele = new Guest { Name = "Adele", Gender = Gender.Woman, Soulmate = Antoine };
            Person Tonio = new Guest { Name = "Tonio", Gender = Gender.Man };
            Person Simon = new Guest { Name = "Simon", Gender = Gender.Man };
            Person Adeline = new Guest { Name = "Adeline", Gender = Gender.Woman };
            Person Greg = new Guest { Name = "Greg", Gender = Gender.Man, Soulmate = Adeline };
            Person Marie = new Guest { Name = "Marie", Gender = Gender.Woman };
            Person Bapt = new Guest { Name = "Bapt", Gender = Gender.Man };
            Person Yannick = new Guest { Name = "Yannick", Gender = Gender.Man, Soulmate = Bapt };
            Person Sylvain = new Guest { Name = "Sylvain", Gender = Gender.Man };
            Person Celine = new Guest { Name = "Celine", Gender = Gender.Woman };
            Person Charly = new Guest { Name = "Charly", Gender = Gender.Man, Soulmate = Celine };
            Person Aurore = new Guest { Name = "Aurore", Gender = Gender.Woman };
            Person Mylene = new Guest { Name = "Mylene", Gender = Gender.Woman };
            Person Alain = new Guest { Name = "Alain", Gender = Gender.Man, Soulmate = Mylene };
            Person Anais = new Guest { Name = "Anais", Gender = Gender.Woman };
            Person Nico = new Guest { Name = "Nico", Gender = Gender.Man, Soulmate = Anais };
            Person Romain = new Guest { Name = "Romain", Gender = Gender.Man };
            Group GABS = new Group("GABS", Relation.Friend, Romain, Julien, Justine, Charly, Quentin, Cyril, Antoine);
            Group Famille = new Group("Family", Relation.Relative, Justine, Julien, Nico, Anais, Cyril, Emeline, Arnaud, Ophelie, Mylene, Alain);
            Group INSA = new Group("INSA", Relation.Friend, Theo, Nathou, Benji, Lancelot, Julien, Bernard, Pierre, Greg, Bapt, Marie, Yannick, Sylvain);
            Group Exs = new Group("Exs", Relation.Dislike, Julien, Aurore, Marie, Anais);
            Group Bels = new Group("Bels", Relation.Dislike, Romain, Adele);
            Group Bels2 = new Group("Bels", Relation.Dislike, Romain, Celine);
            Group Bels3 = new Group("Bels", Relation.Dislike, Romain, Emeline);
            Group Lycee = new Group("Lycee", Relation.Friend, Simon, Julien, Tonio);
            Group Geeks = new Group("Geeks", Relation.Interest, Julien, Theo, Greg, Simon);
            Group Geos = new Group("Geos", Relation.Interest, Alain, Cyril);
            AddPerson(Julien);
            AddPerson(Justine);
            AddPerson(Theo);
            AddPerson(Bapt);
            AddPerson(Nathou);
            AddPerson(Benji);
            AddPerson(Lancelot);
            AddPerson(Emeline);
            AddPerson(Cyril);
            AddPerson(Bernard);
            AddPerson(Arnaud);
            AddPerson(Alison);
            AddPerson(Pierre);
            AddPerson(Quentin);
            AddPerson(Ophelie);
            AddPerson(Antoine);
            AddPerson(Tonio);
            AddPerson(Simon);
            AddPerson(Adeline);
            AddPerson(Greg);
            AddPerson(Marie);
            AddPerson(Yannick);
            AddPerson(Sylvain);
            AddPerson(Adele);
            AddPerson(Celine);
            AddPerson(Charly);
            AddPerson(Mylene);
            AddPerson(Anais);
            AddPerson(Aurore);
            AddPerson(Alain);
            AddPerson(Nico);
            AddPerson(Romain);
            #endregion
        }
    }
}
