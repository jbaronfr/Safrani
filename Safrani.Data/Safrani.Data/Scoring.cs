using Safrani.Model;
using System.Collections.Generic;

namespace Safrani.Data
{
    public static class Scoring
    {
        public static Dictionary<Relation, Dictionary<Position, Mark>> ByRelation = new Dictionary<Relation, Dictionary<Position, Mark>>{
            { Relation.Soulmate, new Dictionary<Position, Mark> {
                    { Position.Front, Mark.Best },
                    { Position.Side, Mark.Best },
                    { Position.Diagonal, Mark.Yeah }
                }
            },
            { Relation.Enemy, new Dictionary<Position, Mark> {
                    { Position.Front, Mark.Nope },
                    { Position.Side, Mark.Nope },
                    { Position.Diagonal, Mark.Nope }
                }
            },
            { Relation.Friend, new Dictionary<Position, Mark> {
                    { Position.Front, Mark.Top },
                    { Position.Side, Mark.Top },
                    { Position.Diagonal, Mark.Good }
                }
            },
            { Relation.Relative, new Dictionary<Position, Mark> {
                    { Position.Front, Mark.Good },
                    { Position.Side, Mark.Good },
                    { Position.Diagonal, Mark.Good }
                }
            },
            { Relation.Acquaintance, new Dictionary<Position, Mark> {
                    { Position.Front, Mark.Yeah },
                    { Position.Side, Mark.Yeah },
                    { Position.Diagonal, Mark.Good }
                }
            },
            { Relation.Unknown, new Dictionary<Position, Mark> {
                    { Position.Front, Mark.Neutral },
                    { Position.Side, Mark.Neutral },
                    { Position.Diagonal, Mark.Neutral }
                }
            },
        };
    }
}
