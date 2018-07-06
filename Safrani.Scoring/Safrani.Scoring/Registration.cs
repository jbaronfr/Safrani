using Safrani.Data;
using Safrani.Model;
using Safrani.Model.People;

namespace Safrani.Scoring
{
    public static class Registration
    {
        public static bool AddPerson(Person pirate)
        {
            bool sameName = People.Exists(pirate.Name);

            if (!sameName)
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
