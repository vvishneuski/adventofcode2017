using System;
using System.Collections.Generic;
using System.Linq;

namespace adventofcode
{
    public static class Day4
    {
        private static IEnumerable<string> GetWords(string phrase)
        {
            return phrase.Split(new[] {" ", "\t"}, StringSplitOptions.RemoveEmptyEntries);
        }

        public static bool RegularPhraseValidator(string phrase)
        {
            return NoDuplicates(phrase, value => value);
        }

        private static bool NoDuplicates(string phrase, Func<string, string> keySelector)
        {
            return !GetWords(phrase).GroupBy(keySelector)
                .Any(group => group.Count() > 1);
        }

        public static bool AnagramPhraseValidator(string phrase)
        {
            return NoDuplicates(phrase, GetSorted);
        }

        private static string GetSorted(string value)
        {
            var characters = value.ToCharArray();
            Array.Sort(characters);
            return new string(characters);
        }

        public static int ValidPassPhraseCount(string test, Func<string, bool> validator)
        {
            return test.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries).Count(validator);
        }
    }
}
