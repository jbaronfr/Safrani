using Safrani.Model;
using Safrani.Model.People;
using System.Collections.Generic;

namespace Safrani.CLI
{
    public static class Strings
    {
        public static Dictionary<int, Relation> Relations = new Dictionary<int, Relation> {
            { (int)Relation.Acquaintance, Relation.Acquaintance },
            { (int)Relation.Dislike, Relation.Dislike },
            { (int)Relation.Friend, Relation.Friend },
            { (int)Relation.Relative, Relation.Relative },
            { (int)Relation.Soulmate, Relation.Soulmate },
            { (int)Relation.Interest, Relation.Interest },
        };
    }
}
