namespace VKH.FizzbBuzz
{
    
    public interface IFizzBuzzKata
    {
        /// <summary>
        /// Give an answer to the current game
        /// </summary>
        /// <param name="number">current number in the game sequence</param>
        /// <returns>appropriate answer to the current number</returns>
        string Answer(int number);
    }


    public class FizzBuzzGame : IFizzBuzzKata
    {
        
        public string Answer(int number)
        {

            var result = number.ToString();

            if (IsDivisibleByThree(number))
                result = "fizz";
            if (IsDivisibleByFive(number))
                result = "buzz";
            if (IsDivisibleByBoth(number))
                result = "fizzbuzz";
         
            return result;

        }


        private static bool IsDivisibleByThree(int number)
        {
            return number % 3 == 0;
        }

        private static bool IsDivisibleByFive(int number)
        {
            return number % 5 == 0;
        }

        private static bool IsDivisibleByBoth(int number)
        {
            return number%3 == 0 && number%5 == 0;
        }

    }
}