using Safrani.Data;
using Safrani.Model;
using Safrani.Model.People;
using System.Collections.Generic;

namespace Safrani.Scoring
{
    public class Directory
    {
        public static List<Person> GetList()
        {
            return People.GetList();
        }
        public static Person GetById(int id)
        {
            return People.GetPerson(id);
        }
    }
}
