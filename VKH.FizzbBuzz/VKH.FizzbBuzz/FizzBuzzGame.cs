using NUnit.Framework;


namespace VKH.FizzbBuzz
{
    public class FizzBuzzGame : IFizzBuzzKata
    {
        
        public string Answer(int number)
        {

            var result = number.ToString();

            if (number % 3 == 0)
                result = "fizz";
            if (number % 5 == 0)
                result = "buzz";
            if (number % 3 == 0 && number % 5 == 0)
                result = "fizzbuzz";
         
            return result;

        }
    }


    public interface IFizzBuzzKata
    {
        /// <summary>
        /// Give an answer to the current game
        /// </summary>
        /// <param name="number">current number in the game sequence</param>
        /// <returns>appropriate answer to the current number</returns>
        string Answer(int number);
    }

    [TestFixture]
    public class FizzBuzzGameTests
    {

        [TestCase(0, "fizzbuzz")]
        [TestCase(15, "fizzbuzz")]
        public void NumberDivisibleByThreeAndFive_Return_fizzbuzz(int number, string expected)
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
        public void NumberNotDivisibleByThreeAndFive_Return_number(int number, string expected)
        {
            ArrangeActAssert(number, expected);
        }

        [TestCase(3, "fizz")]
        public void NumberDivisibleByThree_Return_fizz(int number, string expected)
        {
            ArrangeActAssert(number, expected);
        }

        [TestCase(5, "buzz")]
        public void NumberDivisibleByFive_Return_buzz(int number, string expected)
        {
            ArrangeActAssert(number, expected);
        }


        private static void ArrangeActAssert(int number, string expected)
        {
            var fizzBuzzer = new FizzBuzzGame();

            var result = fizzBuzzer.Answer(number);

            Assert.AreEqual(expected, result);
        }
    }
}