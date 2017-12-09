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
            var regex = new Regex(
                @"(?<register>\w+) (?<function>inc|dec) (?<parameter>\d+|-\d+) if (?<reference>\w+) (?<operator>\S+) (?<value>\d+|-\d+)");

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

        private static IDictionary<string, Func<int, int, bool>> Condition =
            new Dictionary<string, Func<int, int, bool>>
            {
                {"==", (x, y) => x == y},
                {"!=", (x, y) => x != y},
                {">", (x, y) => x > y},
                {">=", (x, y) => x >= y},
                {"<", (x, y) => x < y},
                {"<=", (x, y) => x <= y}
            };

        private static IDictionary<string, Func<int, int, int>> Function =
            new Dictionary<string, Func<int, int, int>>
            {
                {"inc", (x, y) => x + y},
                {"dec", (x, y) => x - y}
            };

        public static int ProcessInstructions(string _instructions)
        {
            var instructions = GetInstructions(_instructions);
            var registers = GetRegisters(instructions);

            foreach (var instruction in instructions)
            {
                if (Condition[instruction.Operator](registers[instruction.Reference], instruction.Value))
                    registers[instruction.Register] = Function[instruction.Function](registers[instruction.Register], instruction.Parameter);
            }

            return registers.Max(register => register.Value);
        }

        private static Dictionary<string, int> GetRegisters(List<Instruction> instructions)
        {
            return instructions.GroupBy(instruction => instruction.Register).ToDictionary(group => @group.Key, group => 0);
        }

        private static List<Instruction> GetInstructions(string _instructions)
        {
            return GetInstructionList(_instructions).Select(ParseInstruction).ToList();
        }

        private static string[] GetInstructionList(string _instructions)
        {
            return _instructions.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
        }

        public static int GetMaxValue(string _instructions)
        {
            var instructions = GetInstructions(_instructions);
            var registers = GetRegisters(instructions);

            int max = 0;

            foreach (var instruction in instructions)
            {
                if (Condition[instruction.Operator](registers[instruction.Reference], instruction.Value))
                    registers[instruction.Register] = Function[instruction.Function](registers[instruction.Register], instruction.Parameter);
                if (max < registers[instruction.Register])
                    max = registers[instruction.Register];
            }

            return max;
        }
    }
}
