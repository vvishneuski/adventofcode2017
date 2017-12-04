using NUnit.Framework;

namespace adventofcode.test
{
    [TestFixture]
    public class Day3Test
    {
        [TestCase(1, ExpectedResult = 0)]
        [TestCase(2, ExpectedResult = 1)]
        [TestCase(3, ExpectedResult = 2)]
        [TestCase(4, ExpectedResult = 1)]
        [TestCase(5, ExpectedResult = 2)]
        [TestCase(6, ExpectedResult = 1)]
        [TestCase(7, ExpectedResult = 2)]
        [TestCase(8, ExpectedResult = 1)]
        [TestCase(9, ExpectedResult = 2)]
        [TestCase(10, ExpectedResult = 3)]
        [TestCase(11, ExpectedResult = 2)]
        [TestCase(12, ExpectedResult = 3)]
        [TestCase(20, ExpectedResult = 3)]
        [TestCase(23, ExpectedResult = 2)]
        [TestCase(33, ExpectedResult = 4)]
        [TestCase(34, ExpectedResult = 3)]
        [TestCase(35, ExpectedResult = 4)]
        [TestCase(36, ExpectedResult = 5)]
        [TestCase(37, ExpectedResult = 6)]
        [TestCase(38, ExpectedResult = 5)]
        [TestCase(39, ExpectedResult = 4)]
        [TestCase(40, ExpectedResult = 3)]
        [TestCase(50, ExpectedResult = 7)]
        [TestCase(1024, ExpectedResult = 31)]
        [TestCase(277678, ExpectedResult = 475)]
        public int GetDistance(int number)
        {
            return Day3.GetDistance(number);
        }

        [Ignore("for while")]
        [TestCase(277678, ExpectedResult = 59)]
        public int GetFirstLarger(int number)
        {
            return Day3.GetFIrstLarger(number);
        }
    }
}
