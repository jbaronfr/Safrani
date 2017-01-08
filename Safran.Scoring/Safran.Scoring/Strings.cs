using Safran.Scoring.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Safran.Scoring
{
    public static class Strings
    {
        public static Dictionary<int, Relation> Relations = new Dictionary<int, Relation> {
            { (int)Relation.Acquaintance, Relation.Acquaintance },
            { (int)Relation.Enemy, Relation.Enemy },
            { (int)Relation.Friend, Relation.Friend },
            { (int)Relation.Relative, Relation.Relative },
            { (int)Relation.Soulmate, Relation.Soulmate },
        };
    }
}
