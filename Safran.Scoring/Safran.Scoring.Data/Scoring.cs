using Safran.Scoring.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Safran.Scoring.Data
{
    public static class Scoring
    {
        public static Dictionary<Relation, Score> ByRelation = new Dictionary<Relation, Score>{
            { Relation.Soulmate, new Score {
                Value = new Dictionary<Position, Mark> {
                    { Position.Front, Mark.Best },
                    { Position.Side, Mark.Best },
                    { Position.Diagonal, Mark.Yeah }
                }
            } },
            { Relation.Enemy, new Score {
                Value = new Dictionary<Position, Mark> {
                    { Position.Front, Mark.Nope },
                    { Position.Side, Mark.Nope },
                    { Position.Diagonal, Mark.Nope }
                }
            } },
            { Relation.Friend, new Score {
                Value = new Dictionary<Position, Mark> {
                    { Position.Front, Mark.Top },
                    { Position.Side, Mark.Top },
                    { Position.Diagonal, Mark.Good }
                }
            } },
            { Relation.Relative, new Score {
                Value = new Dictionary<Position, Mark> {
                    { Position.Front, Mark.Good },
                    { Position.Side, Mark.Good },
                    { Position.Diagonal, Mark.Good }
                }
            } },
            { Relation.Acquaintance, new Score {
                Value = new Dictionary<Position, Mark> {
                    { Position.Front, Mark.Yeah },
                    { Position.Side, Mark.Yeah },
                    { Position.Diagonal, Mark.Good }
                }
            } },
        };
    }
}
