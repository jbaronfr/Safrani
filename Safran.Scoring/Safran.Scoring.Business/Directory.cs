using Safran.Scoring.Data;
using Safran.Scoring.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Safran.Scoring.Business
{
    public class Directory
    {
        public static List<Person> GetList()
        {
            return People.GetList();
        }
        public static Person GetById(string id)
        {
            return People.GetPerson(int.Parse(id));
        }
    }
}
