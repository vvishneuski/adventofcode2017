using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode
{
    public static class Day2
    {
        public static IEnumerable<IEnumerable<int>> ParseSpreadsheet(string spreadsheet)
        {
            return spreadsheet.Split(new[] {Environment.NewLine}, StringSplitOptions.None)
                .Select(str => str.Split(new[] {" ", "\t"}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
        }

        public static int GetCheckSum(string spreadsheet, Func<IEnumerable<int>, int> checkSumFunction)
        {
            return ParseSpreadsheet(spreadsheet).Sum(checkSumFunction);
        }

        public static int GetDifference(IEnumerable<int> row)
        {
            var max = int.MinValue;
            var min = int.MaxValue;
            foreach (var value in row)
            {
                if (max < value) max = value;
                if (min > value) min = value;
            }
            var difference = max - min;
            return difference;
        }

        public static int GetDivision(IEnumerable<int> row)
        {
            var list = row.ToList();
            for (var i = 0; i < list.Count; i++)
            {
                var ii = list[i];
                for (var j = i + 1; j < list.Count; j++)
                {
                    var jj = list[j];
                    if (ii % jj == 0)
                        return ii / jj;
                    if (jj % ii == 0)
                        return jj / ii;
                }
            }
            return 0;
        }
    }
}
