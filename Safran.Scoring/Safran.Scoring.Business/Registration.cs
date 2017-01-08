using Safran.Scoring.Data;
using Safran.Scoring.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Safran.Scoring.Business
{
    public static class Registration
    {
        public static bool AddPerson(Person pirate)
        {
            bool sameName = People.Exists(pirate.Name);

            if(!sameName)
            {
                People.AddPerson(pirate);
                return true;
            }

            return false;
        }

        public static bool IsAvailable(string name)
        {
            return !People.Exists(name);
        }
    }
}
