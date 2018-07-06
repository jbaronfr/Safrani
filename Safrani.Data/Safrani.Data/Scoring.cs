using Safrani.Model;
using Safrani.Model.Calculation;
using Safrani.Model.People;
using System.Collections.Generic;

namespace Safrani.Data
{
    public static class Scoring
    {
        public static Dictionary<Relation, Dictionary<Position, Mark>> ByRelation = new Dictionary<Relation, Dictionary<Position, Mark>>{
            { Relation.Soulmate, new Dictionary<Position, Mark> {
                    { Position.Front, Mark.Best },
                    { Position.Side, Mark.Best },
                    { Position.Diagonal, Mark.Nope }
                }
            },
            { Relation.Dislike, new Dictionary<Position, Mark> {
                    { Position.Front, Mark.Nope },
                    { Position.Side, Mark.Nope },
                    { Position.Diagonal, Mark.Nope }
                }
            },
            { Relation.Friend, new Dictionary<Position, Mark> {
                    { Position.Front, Mark.Top },
                    { Position.Side, Mark.Top },
                    { Position.Diagonal, Mark.Top }
                }
            },
            { Relation.Relative, new Dictionary<Position, Mark> {
                    { Position.Front, Mark.Meh },
                    { Position.Side, Mark.Yeah },
                    { Position.Diagonal, Mark.Yeah }
                }
            },
            { Relation.Acquaintance, new Dictionary<Position, Mark> {
                    { Position.Front, Mark.Yeah },
                    { Position.Side, Mark.Yeah },
                    { Position.Diagonal, Mark.Neutral }
                }
            },
            { Relation.Interest, new Dictionary<Position, Mark> {
                    { Position.Front, Mark.Yeah },
                    { Position.Side, Mark.Yeah },
                    { Position.Diagonal, Mark.Neutral }
                }
            },
            { Relation.Unknown, new Dictionary<Position, Mark> {
                    { Position.Front, Mark.Bad },
                    { Position.Side, Mark.Bad },
                    { Position.Diagonal, Mark.Meh }
                }
            },
        };
    }
}
