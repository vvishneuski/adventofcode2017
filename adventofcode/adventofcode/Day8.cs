using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace adventofcode
{
    public static class Day8
    {
        public static Instruction ParseInstruction(string instruction)
        {
            var regex = new Regex(@"(?<register>\w+) (?<function>inc|dec) (?<parameter>\d+) if (?<reference>\w+) (?<operator>\S+) (?<value>\d+)");

            var match = regex.Match(instruction);

            return new Instruction
            {
                Register = match.Groups["register"].Value,
                Function = match.Groups["function"].Value,
                Parameter = int.Parse(match.Groups["parameter"].Value),
                Reference = match.Groups["reference"].Value,
                Operator = match.Groups["operator"].Value,
                Value = int.Parse(match.Groups["value"].Value)
            };
        }

        public class Instruction
        {
            public string Register { get; set; }
            public string Function { get; set; }
            public int Parameter { get; set; }
            public string Reference { get; set; }
            public string Operator { get; set; }
            public int Value { get; set; }
        }

        public static int ProcessInstructions(string _instructions)
        {
            var instructions = GetInstructionList(_instructions).Select(ParseInstruction).ToList();

            var registers = new HashSet<Register>(instructions.Select(GetRegister), Register.NameComparer);

            return 2;
        }

        private static string[] GetInstructionList(string _instructions)
        {
            return _instructions.Split(new []{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
        }

        private static Register GetRegister(Instruction instruction)
        {
            return new Register{Name = instruction.Register};
        }

        public class Register
        {
            private sealed class NameEqualityComparer : IEqualityComparer<Register>
            {
                public bool Equals(Register x, Register y)
                {
                    if (ReferenceEquals(x, y)) return true;
                    if (ReferenceEquals(x, null)) return false;
                    if (ReferenceEquals(y, null)) return false;
                    if (x.GetType() != y.GetType()) return false;
                    return string.Equals(x.Name, y.Name);
                }

                public int GetHashCode(Register obj)
                {
                    return (obj.Name != null ? obj.Name.GetHashCode() : 0);
                }
            }

            public static IEqualityComparer<Register> NameComparer { get; } = new NameEqualityComparer();

            public string Name { get; set; }
            public int Value { get; set; }
        }
    }
}