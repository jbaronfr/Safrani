using Safrani.Data;
using Safrani.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Safrani.Scoring
{
    public static class Calculation
    {
        public static Table ComputeBestTable(List<Person> pirates = null, bool peopleAtEnds = true)
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

            scores.OrderByDescending(score => score.Item2);

            return scores.FirstOrDefault().Item1;
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
                pickingList = peopleSelect;
            else
                pickingList = people;

            if (!aTable.FacingPirates.LastOrDefault().ContainsKey(Side.Port))
            {
                // find person w/ best score with people at side and diagonal
                Person nearPirate = pickingList.OrderByDescending(pp => PreviewLastScore(pp, Side.Port, previousLine)).FirstOrDefault();
                aTable.FacingPirates.LastOrDefault().Add(Side.Port, nearPirate);
                people.Remove(nearPirate);
            }

            if (!aTable.FacingPirates.LastOrDefault().ContainsKey(Side.Starboard))
            {
                // find person w/ best score with people at side and diagonal
                Person nearPirate = pickingList.OrderByDescending(pp => PreviewLastScore(pp, Side.Starboard, previousLine)).FirstOrDefault();
                aTable.FacingPirates.LastOrDefault().Add(Side.Starboard, nearPirate);
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
                score += 2 * (int)Data.Scoring.ByRelation[lastest.FirstOrDefault().Value.GetRelationWith(lastest.LastOrDefault().Value)][Position.Front];
            return 0;
        }
    }
}
