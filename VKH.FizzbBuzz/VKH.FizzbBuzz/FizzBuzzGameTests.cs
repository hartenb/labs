using NUnit.Framework;

namespace VKH.FizzbBuzz
{
    [TestFixture]
    public class FizzBuzzGameTests
    {

        private static void ArrangeActAssert(int number, string expected)
        {
            var fizzBuzzer = new FizzBuzzGame();

            var result = fizzBuzzer.Answer(number);

            Assert.AreEqual(expected, result);
        }

        [TestCase(0, "fizzbuzz")]
        [TestCase(15, "fizzbuzz")]
        public void NumberDivisibleByThreeAndFive_ShouldReturnFizzbuzz(int number, string expected)
        {
            ArrangeActAssert(number, expected);
        }

        [TestCase(14, "14")]
        [TestCase(13 , "13")]
        [TestCase(11, "11")]
        [TestCase(8, "8")]
        [TestCase(7, "7")]
        [TestCase(4, "4")]
        [TestCase(2, "2")]
        [TestCase(1, "1")]
        public void NumberNotDivisibleByThreeAndFive_ShouldReturnNumber(int number, string expected)
        {
            ArrangeActAssert(number, expected);
        }

        [TestCase(3, "fizz")]
        public void NumberDivisibleByThree_ShouldReturnFizz(int number, string expected)
        {
            ArrangeActAssert(number, expected);
        }

        [TestCase(5, "buzz")]
        public void NumberDivisibleByFive_ShouldReturnBuzz(int number, string expected)
        {
            ArrangeActAssert(number, expected);
        }

    }
}