using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace adventofcode
{
    public static class Day7
    {
        public static string GetTowerName(string _programs)
        {
            return GetTower(_programs).Name;
        }

        public static int FindDisbalanceDiscAndGetDifference(string programs)
        {
            var tower = GetTower(programs);

            return FindDisbalanceDiscAndGetDifference(tower);
        }

        private static int FindDisbalanceDiscAndGetDifference(Program tower)
        {
            var groups = tower.SubTowers.GroupBy(p => p.TotalWeight).ToList();
            if (groups.Count == 1)
            {
                var bottom = tower.Bottom;
                var simbling = bottom.SubTowers.First(t => t != tower);
                return tower.Weight + (simbling.TotalWeight - tower.TotalWeight);
            }
            return FindDisbalanceDiscAndGetDifference(groups.First(group => group.Count() == 1).First());
        }

        private static Program GetTower(string _programs)
        {
            var programs = GetMatches(_programs).Select(GetProgram).ToList();

            foreach (var program in programs)
            {
                foreach (var tower in program.Towers)
                {
                    var subTower = programs.First(p => p.Name.Equals(tower));
                    subTower.Bottom = program;
                    program.SubTowers.Add(subTower);
                }
            }

            return programs.First(p => p.Bottom == null);
        }

        private static IEnumerable<Match> GetMatches(string _programs)
        {
            var regex = new Regex(@"(?<name>\w+) \((?<weight>\d+)\)(?: -> (?<towers>.*))?");

            return regex.Matches(_programs).OfType<Match>();
        }

        private static Program GetProgram(Match match)
        {
            return new Program
            {
                Name = match.Groups["name"].Value,
                Weight = int.Parse(match.Groups["weight"].Value),
                Towers = match.Groups["towers"].Value.Split(new[] {", ", "\r"}, StringSplitOptions.RemoveEmptyEntries)
            };
        }

        public class Program
        {
            public Program Bottom { get; set; }
            public string Name { get; set; }
            public int Weight { get; set; }
            public int TotalWeight => Weight + SubTowersWeight;
            public int SubTowersWeight => SubTowers.Sum(tower => tower.TotalWeight);
            public IEnumerable<string> Towers { get; set; }
            public IList<Program> SubTowers { get; } = new List<Program>();
        }
    }
}
