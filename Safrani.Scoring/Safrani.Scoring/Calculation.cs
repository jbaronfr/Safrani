using Safrani.Data;
using Safrani.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Safrani.Scoring
{
    public static class Calculation
    {
        public static List<Tuple<Table, int>> ComputeTopTables(List<Person> pirates = null, bool peopleAtEnds = true, int top = 3)
        {
            if (pirates == null)
                pirates = People.GetList();

            List<Tuple<Table, int>> scores = new List<Tuple<Table, int>>();

            foreach (Person pirate in pirates)
            {
                var list = new List<Person>(pirates);
                list.Remove(pirate);
                var table = new Table(pirate);
                scores.Add(Calculate(table, 0, list));
            }

            scores = scores.OrderByDescending(score => score.Item2).ToList();

            return scores.Take(top).ToList();
        }

        private static Tuple<Table, int> Calculate(Table aTable, int score, List<Person> people)
        {
            if (people.Count == 0)
                return new Tuple<Table, int>(aTable, score);

            var previousLine = aTable.FacingPirates.LastOrDefault();

            aTable.AddNewPirateLine();

            if (people.Count == 1)
            {
                aTable.AddPirateAtEnd(Side.Stern, people.LastOrDefault());
                score += ComputeLastScores(aTable.FacingPirates.LastOrDefault(), previousLine);
                return new Tuple<Table, int>(aTable, score);
            }

            var peopleInLove = previousLine.Where(p => p.Value.HasSoulmate());
            // if a previous has a soulmate put next to her/him
            if (peopleInLove.Count() > 0)
            {
                foreach (var p in peopleInLove)
                {
                    if (p.Key == Side.Starboard && people.Contains(p.Value.GetSoulmate()))
                    {
                        aTable.AddPirateAtEnd(Side.Starboard, p.Value.GetSoulmate());
                        people.Remove(p.Value.GetSoulmate());
                    }
                    else if (people.Contains(p.Value.GetSoulmate()))
                    {
                        aTable.AddPirateAtEnd(Side.Port, p.Value.GetSoulmate());
                        people.Remove(p.Value.GetSoulmate());
                    }
                }
                // if both had soulmates -> next
                if (aTable.FacingPirates.LastOrDefault().Count > 1)
                {
                    score += ComputeLastScores(aTable.FacingPirates.LastOrDefault(), previousLine);
                    return Calculate(aTable, score, people);
                }
            }

            List<Person> peopleSelect = null;

            foreach (var p in previousLine)
            {
                if (peopleSelect == null)
                    peopleSelect = PickPiratesFor(p.Value, people);
                else
                    peopleSelect = peopleSelect.Intersect(PickPiratesFor(p.Value, people)).ToList();
            }

            List<Person> pickingList;
            if (peopleSelect != null && peopleSelect.Count >= (2 - aTable.FacingPirates.LastOrDefault().Count))
                pickingList = new List<Person>(peopleSelect);
            else
                pickingList = new List<Person>(people);

            if (!aTable.FacingPirates.LastOrDefault().ContainsKey(Side.Port))
            {
                Person nearPirate = ChoosePirateFor(Side.Port, previousLine, pickingList, people);
                aTable.FacingPirates.LastOrDefault().Add(Side.Port, nearPirate);
                pickingList.Remove(nearPirate);
                people.Remove(nearPirate);
            }

            if (!aTable.FacingPirates.LastOrDefault().ContainsKey(Side.Starboard))
            {
                Person nearPirate = ChoosePirateFor(Side.Starboard, previousLine, pickingList, people);
                aTable.FacingPirates.LastOrDefault().Add(Side.Starboard, nearPirate);
                pickingList.Remove(nearPirate);
                people.Remove(nearPirate);
            }

            score += ComputeLastScores(aTable.FacingPirates.LastOrDefault(), previousLine);

            return Calculate(aTable, score, people);
        }

        private static List<Person> PickPiratesFor(Person p, List<Person> people)
        {
            // if soulmate in list return her/him
            if (p.HasSoulmate() && people.Contains(p.GetSoulmate()))
                return new List<Person> { p.GetSoulmate() };

            // don't return enemies to be at side
            return people.Where(other => other.GetRelationWith(p) != Relation.Enemy).ToList();
        }

        private static int PreviewLastScore(Person p, Side s, Dictionary<Side, Person> previousLine)
        {
            int score = 0;
            foreach (var neibourg in previousLine)
            {
                if (s == neibourg.Key)
                    score += (int)Data.Scoring.ByRelation[p.GetRelationWith(neibourg.Value)][Position.Side];
                else
                    score += (int)Data.Scoring.ByRelation[p.GetRelationWith(neibourg.Value)][Position.Diagonal];
            }
            return score;
        }

        private static Person ChoosePirateFor(Side side, Dictionary<Side,Person> previousLine, List<Person> pickingList, List<Person> people)
        {
            List<Tuple<Person, int>> pickingListScores = new List<Tuple<Person, int>>();
            foreach (var pp in pickingList)
                pickingListScores.Add(new Tuple<Person, int>(pp, PreviewLastScore(pp, side, previousLine)));
            var scoreMax = pickingListScores.Max(pps => pps.Item2);
            pickingListScores = pickingListScores.Where(pps => pps.Item2 == scoreMax).ToList();
            // pick ones w/ less remaining relations
            pickingListScores = pickingListScores.OrderBy(pp => pp.Item1.Relations.Keys.Intersect(people).Count()).ToList();
            return pickingListScores.FirstOrDefault().Item1;
        }

        private static int ComputeLastScores(Dictionary<Side, Person> lastest, Dictionary<Side, Person> previous)
        {
            int score = 0;
            foreach (var l in lastest)
            {
                foreach (var neibourg in previous)
                {
                    if (l.Key == neibourg.Key)
                        score += (int)Data.Scoring.ByRelation[l.Value.GetRelationWith(neibourg.Value)][Position.Side];
                    else
                        score += (int)Data.Scoring.ByRelation[l.Value.GetRelationWith(neibourg.Value)][Position.Diagonal];
                }
            }
            if (lastest.Count > 1)
                score += (int)Data.Scoring.ByRelation[lastest.FirstOrDefault().Value.GetRelationWith(lastest.LastOrDefault().Value)][Position.Front];
            return score;
        }
    }
}
