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
        #region TestData
            Person Julien = new Person { Id = 0, Name = "Julien", Gender = Gender.Man, IsGuest = false };
            AddPerson(Julien);
            Person Justine = new Person { Id = 1, Name = "Justine", Gender = Gender.Woman, IsGuest = false };
            Justine.Relations.Add(Julien, Relation.Relative);
            AddPerson(Justine);
            Person Theo = new Person { Id = 2, Name = "Theo", Gender = Gender.Man, IsGuest = true };
            Theo.Relations.Add(Julien, Relation.Friend);
            AddPerson(Theo);
            Person Bapt = new Person { Id = 3, Name = "Bapt", Gender = Gender.Man, IsGuest = true };
            Bapt.Relations.Add(Julien, Relation.Friend);
            Bapt.Relations.Add(Theo, Relation.Acquaintance);
            AddPerson(Bapt);
            Person Nathou = new Person { Id = 4, Name = "Nathou", Gender = Gender.Woman, IsGuest = true };
            Nathou.Relations.Add(Julien, Relation.Friend);
            Nathou.Relations.Add(Justine, Relation.Acquaintance);
            Nathou.Relations.Add(Bapt, Relation.Friend);
            AddPerson(Nathou);
            Person Benji = new Person { Id = 5, Name = "Benji", Gender = Gender.Man, IsGuest = true };
            Benji.Relations.Add(Julien, Relation.Friend);
            Benji.Relations.Add(Theo, Relation.Acquaintance);
            Benji.Relations.Add(Bapt, Relation.Friend);
            Benji.Relations.Add(Nathou, Relation.Friend);
            AddPerson(Benji);
            Person Lancelot = new Person { Id = 6, Name = "Lancelot", Gender = Gender.Man, IsGuest = true };
            Lancelot.Relations.Add(Julien, Relation.Friend);
            Lancelot.Relations.Add(Bapt, Relation.Friend);
            Lancelot.Relations.Add(Nathou, Relation.Friend);
            Lancelot.Relations.Add(Benji, Relation.Friend);
            AddPerson(Lancelot);
            Person Emeline = new Person { Id = 7, Name = "Emeline", Gender = Gender.Woman, IsGuest = true };
            Emeline.Relations.Add(Julien, Relation.Relative);
            Emeline.Relations.Add(Justine, Relation.Relative);
            AddPerson(Emeline);
            Person Cyril = new Person { Id = 8, Name = "Cyril", Gender = Gender.Man, IsGuest = true };
            Cyril.Relations.Add(Julien, Relation.Friend);
            Cyril.Relations.Add(Justine, Relation.Friend);
            Cyril.Relations.Add(Emeline, Relation.Soulmate);
            AddPerson(Cyril);
            Person Bernard = new Person { Id = 9, Name = "Bernard", Gender = Gender.Man, IsGuest = true };
            Bernard.Relations.Add(Julien, Relation.Friend);
            Bernard.Relations.Add(Bapt, Relation.Acquaintance);
            Bernard.Relations.Add(Nathou, Relation.Enemy);
            Bernard.Relations.Add(Benji, Relation.Friend);
            Bernard.Relations.Add(Lancelot, Relation.Friend);
            AddPerson(Bernard);
            Person Arnaud = new Person { Id = 10, Name = "Arnaud", Gender = Gender.Man, IsGuest = true };
            Arnaud.Relations.Add(Julien, Relation.Relative);
            Arnaud.Relations.Add(Justine, Relation.Relative);
            Arnaud.Relations.Add(Emeline, Relation.Acquaintance);
            AddPerson(Arnaud);
            Person Alison = new Person { Id = 11, Name = "Alison", Gender = Gender.Woman, IsGuest = true };
            Alison.Relations.Add(Julien, Relation.Friend);
            Alison.Relations.Add(Nathou, Relation.Acquaintance);
            Alison.Relations.Add(Benji, Relation.Friend);
            Alison.Relations.Add(Bernard, Relation.Soulmate);
            Alison.Relations.Add(Lancelot, Relation.Enemy);
            AddPerson(Alison);
            Person Pierre = new Person { Id = 12, Name = "Pierre", Gender = Gender.Man, IsGuest = true };
            Pierre.Relations.Add(Julien, Relation.Friend);
            Pierre.Relations.Add(Bapt, Relation.Acquaintance);
            Pierre.Relations.Add(Nathou, Relation.Friend);
            Pierre.Relations.Add(Benji, Relation.Friend);
            Pierre.Relations.Add(Lancelot, Relation.Friend);
            Pierre.Relations.Add(Bernard, Relation.Acquaintance);
            AddPerson(Pierre);
            Person Quentin = new Person { Id = 13, Name = "Quentin", Gender = Gender.Man, IsGuest = true };
            Quentin.Relations.Add(Julien, Relation.Friend);
            Quentin.Relations.Add(Nathou, Relation.Friend);
            Quentin.Relations.Add(Benji, Relation.Acquaintance);
            Quentin.Relations.Add(Lancelot, Relation.Soulmate);
            AddPerson(Quentin);
            Person Ophelie = new Person { Id = 14, Name = "Ophelie", Gender = Gender.Woman, IsGuest = true };
            Ophelie.Relations.Add(Julien, Relation.Relative);
            Ophelie.Relations.Add(Justine, Relation.Relative);
            Ophelie.Relations.Add(Arnaud, Relation.Soulmate);
            Ophelie.Relations.Add(Lancelot, Relation.Enemy);
            AddPerson(Ophelie);
            Person Antoine = new Person { Id = 15, Name = "Antoine", Gender = Gender.Man, IsGuest = true };
            Antoine.Relations.Add(Julien, Relation.Friend);
            Antoine.Relations.Add(Justine, Relation.Friend);
            Antoine.Relations.Add(Emeline, Relation.Friend);
            Antoine.Relations.Add(Cyril, Relation.Friend);
            AddPerson(Antoine);
            Person Tonio = new Person { Id = 16, Name = "Tonio", Gender = Gender.Man, IsGuest = true };
            Tonio.Relations.Add(Julien, Relation.Friend);
            AddPerson(Tonio);
            Person Simon = new Person { Id = 17, Name = "Simon", Gender = Gender.Man, IsGuest = true };
            Simon.Relations.Add(Julien, Relation.Friend);
            Simon.Relations.Add(Justine, Relation.Acquaintance);
            Simon.Relations.Add(Nathou, Relation.Acquaintance);
            Simon.Relations.Add(Benji, Relation.Acquaintance);
            Simon.Relations.Add(Lancelot, Relation.Acquaintance);
            Simon.Relations.Add(Tonio, Relation.Friend);
            AddPerson(Simon);
            Person Adeline = new Person { Id = 18, Name = "Adeline", Gender = Gender.Woman, IsGuest = true };
            Adeline.Relations.Add(Julien, Relation.Acquaintance);
            Adeline.Relations.Add(Theo, Relation.Friend);
            Adeline.Relations.Add(Lancelot, Relation.Acquaintance);
            Adeline.Relations.Add(Pierre, Relation.Acquaintance);
            AddPerson(Adeline);
            Person Greg = new Person { Id = 19, Name = "Greg", Gender = Gender.Man, IsGuest = true };
            Greg.Relations.Add(Julien, Relation.Friend);
            Greg.Relations.Add(Theo, Relation.Friend);
            Greg.Relations.Add(Benji, Relation.Acquaintance);
            Greg.Relations.Add(Lancelot, Relation.Friend);
            Greg.Relations.Add(Pierre, Relation.Friend);
            Greg.Relations.Add(Adeline, Relation.Soulmate);
            AddPerson(Greg);
            Person Marie = new Person { Id = 20, Name = "Marie", Gender = Gender.Woman, IsGuest = true };
            Marie.Relations.Add(Julien, Relation.Acquaintance);
            Marie.Relations.Add(Justine, Relation.Friend);
            Marie.Relations.Add(Nathou, Relation.Friend);
            Marie.Relations.Add(Benji, Relation.Friend);
            Marie.Relations.Add(Lancelot, Relation.Friend);
            Marie.Relations.Add(Emeline, Relation.Acquaintance);
            Marie.Relations.Add(Cyril, Relation.Acquaintance);
            Marie.Relations.Add(Pierre, Relation.Friend);
            Marie.Relations.Add(Bapt, Relation.Friend);
            Marie.Relations.Add(Simon, Relation.Acquaintance);
            AddPerson(Marie);
            Person Yannick = new Person { Id = 21, Name = "Yannick", Gender = Gender.Man, IsGuest = true };
            Yannick.Relations.Add(Julien, Relation.Enemy);
            Yannick.Relations.Add(Nathou, Relation.Friend);
            Yannick.Relations.Add(Benji, Relation.Friend);
            Yannick.Relations.Add(Bernard, Relation.Acquaintance);
            Yannick.Relations.Add(Lancelot, Relation.Friend);
            Yannick.Relations.Add(Pierre, Relation.Friend);
            Yannick.Relations.Add(Bapt, Relation.Soulmate);
            Yannick.Relations.Add(Marie, Relation.Enemy);
            AddPerson(Yannick);
            Person Sylvain = new Person { Id = 22, Name = "Sylvain", Gender = Gender.Man, IsGuest = true };
            Sylvain.Relations.Add(Julien, Relation.Friend);
            Sylvain.Relations.Add(Nathou, Relation.Friend);
            Sylvain.Relations.Add(Benji, Relation.Friend);
            Sylvain.Relations.Add(Bernard, Relation.Acquaintance);
            Sylvain.Relations.Add(Lancelot, Relation.Friend);
            Sylvain.Relations.Add(Pierre, Relation.Friend);
            Sylvain.Relations.Add(Bapt, Relation.Friend);
            Sylvain.Relations.Add(Marie, Relation.Friend);
            Sylvain.Relations.Add(Yannick, Relation.Friend);
            AddPerson(Sylvain);
            Person Adele = new Person { Id = 23, Name = "Adele", Gender = Gender.Woman, IsGuest = true };
            Adele.Relations.Add(Julien, Relation.Friend);
            Adele.Relations.Add(Justine, Relation.Friend);
            Adele.Relations.Add(Emeline, Relation.Friend);
            Adele.Relations.Add(Cyril, Relation.Friend);
            Adele.Relations.Add(Antoine, Relation.Soulmate);
            AddPerson(Adele);
            Person Celine = new Person { Id = 24, Name = "Celine", Gender = Gender.Woman, IsGuest = true };
            Celine.Relations.Add(Julien, Relation.Acquaintance);
            Celine.Relations.Add(Justine, Relation.Friend);
            Celine.Relations.Add(Emeline, Relation.Friend);
            Celine.Relations.Add(Cyril, Relation.Friend);
            Celine.Relations.Add(Adele, Relation.Friend);
            Celine.Relations.Add(Antoine, Relation.Friend);
            AddPerson(Celine);
            Person Charly = new Person { Id = 25, Name = "Charly", Gender = Gender.Man, IsGuest = true };
            Charly.Relations.Add(Julien, Relation.Friend);
            Charly.Relations.Add(Justine, Relation.Friend);
            Charly.Relations.Add(Emeline, Relation.Friend);
            Charly.Relations.Add(Cyril, Relation.Friend);
            Charly.Relations.Add(Adele, Relation.Friend);
            Charly.Relations.Add(Antoine, Relation.Friend);
            Charly.Relations.Add(Celine, Relation.Soulmate);
            AddPerson(Charly);
            Person Mylene = new Person { Id = 26, Name = "Mylene", Gender = Gender.Woman, IsGuest = true };
            Mylene.Relations.Add(Julien, Relation.Relative);
            Mylene.Relations.Add(Justine, Relation.Relative);
            Mylene.Relations.Add(Simon, Relation.Acquaintance);
            AddPerson(Mylene);
            Person Anais = new Person { Id = 27, Name = "Anais", Gender = Gender.Woman, IsGuest = true };
            Anais.Relations.Add(Julien, Relation.Relative);
            Anais.Relations.Add(Justine, Relation.Relative);
            Anais.Relations.Add(Ophelie, Relation.Friend);
            Anais.Relations.Add(Arnaud, Relation.Friend);
            Anais.Relations.Add(Emeline, Relation.Acquaintance);
            Anais.Relations.Add(Cyril, Relation.Acquaintance);
            Anais.Relations.Add(Mylene, Relation.Friend);
            AddPerson(Anais);
            Person Aurore = new Person { Id = 28, Name = "Aurore", Gender = Gender.Woman, IsGuest = true };
            Aurore.Relations.Add(Julien, Relation.Friend);
            Aurore.Relations.Add(Justine, Relation.Enemy);
            Aurore.Relations.Add(Nathou, Relation.Friend);
            Aurore.Relations.Add(Benji, Relation.Friend);
            Aurore.Relations.Add(Bernard, Relation.Friend);
            Aurore.Relations.Add(Lancelot, Relation.Friend);
            Aurore.Relations.Add(Pierre, Relation.Friend);
            Aurore.Relations.Add(Bapt, Relation.Acquaintance);
            Aurore.Relations.Add(Marie, Relation.Enemy);
            Aurore.Relations.Add(Anais, Relation.Enemy);
            Aurore.Relations.Add(Yannick, Relation.Friend);
            AddPerson(Aurore);
            Person Alain = new Person { Id = 29, Name = "Alain", Gender = Gender.Man, IsGuest = true };
            Alain.Relations.Add(Julien, Relation.Relative);
            Alain.Relations.Add(Justine, Relation.Relative);
            Alain.Relations.Add(Cyril, Relation.Acquaintance);
            Alain.Relations.Add(Mylene, Relation.Soulmate);
            Alain.Relations.Add(Anais, Relation.Friend);
            AddPerson(Alain);
            Person Nico = new Person { Id = 30, Name = "Nico", Gender = Gender.Man, IsGuest = true };
            Nico.Relations.Add(Julien, Relation.Relative);
            Nico.Relations.Add(Justine, Relation.Relative);
            Nico.Relations.Add(Arnaud, Relation.Relative);
            Nico.Relations.Add(Cyril, Relation.Acquaintance);
            Nico.Relations.Add(Benji, Relation.Acquaintance);
            Nico.Relations.Add(Emeline, Relation.Relative);
            Nico.Relations.Add(Anais, Relation.Soulmate);
            Nico.Relations.Add(Mylene, Relation.Relative);
            Nico.Relations.Add(Alain, Relation.Friend);
            Nico.Relations.Add(Ophelie, Relation.Friend);
            Nico.Relations.Add(Aurore, Relation.Enemy);
            AddPerson(Nico);
            Person Romain = new Person { Id = 31, Name = "Romain", Gender = Gender.Man, IsGuest = true };
            Romain.Relations.Add(Julien, Relation.Friend);
            Romain.Relations.Add(Justine, Relation.Friend);
            Romain.Relations.Add(Emeline, Relation.Enemy);
            Romain.Relations.Add(Cyril, Relation.Friend);
            Romain.Relations.Add(Adele, Relation.Enemy);
            Romain.Relations.Add(Charly, Relation.Friend);
            Romain.Relations.Add(Celine, Relation.Acquaintance);
            Romain.Relations.Add(Antoine, Relation.Friend);
            AddPerson(Romain);
            #endregion
        }
    }
}
