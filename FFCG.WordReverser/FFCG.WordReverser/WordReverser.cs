using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FFCG.WordReverser
{
    public class WordReverser
    {
        public string ReverseWords(string text)
        {
            List<Tuple<int, string>> listOfTuples = new List<Tuple<int, string>>();
            string[] customString = text.Split(' ');
            for (int i = 0; i < customString.Length; i++)
            {
                string currentWord = customString[i];
                if (ContainsDelimiter(currentWord))
                {
                    CreateTuple(i, customString, listOfTuples);
                }
            }
            Array.Reverse(customString);
            if (listOfTuples.Count > 0)
            {
                for (int i = 0; i < listOfTuples.Count; i++)
                {
                    int positionToChange = listOfTuples[i].Item1;
                    string charToAdd = listOfTuples[i].Item2;
                    customString[positionToChange] = string.Concat(customString[positionToChange], charToAdd);
                }
               
            }
           
            string result = string.Join(" ", customString);
            return result;
        }

        private static void CreateTuple(int i, string[] customString, List<Tuple<int, string>> listOfTuples)
        {
            Tuple<int, string> testTuple = new Tuple<int, string>(i, customString[i].Last().ToString());
            listOfTuples.Add(testTuple);
            customString[i] = customString[i].TrimEnd(customString[i].Last());
        }

        private static bool ContainsDelimiter(string word)
        {
            return word.Contains("!")||word.Contains("?")||word.Contains(".")||word.Contains(",");
        }
    }

    public class WordReverserTests
    {
        [TestCase("hello", "hello")]
        public void ReturnWordAsItComes(string text, string expected)
        {
            var reverser = new WordReverser();

            var result = reverser.ReverseWords(text);

            Assert.AreEqual(expected, result);
        }

        [TestCase("hello world", "world hello")]
        public void ReturnTwoWordsInReverseOrder(string text, string expected)
        {
            var reverser = new WordReverser();

            var result = reverser.ReverseWords(text);

            Assert.AreEqual(expected, result);
        }

        [TestCase("hello glorious world", "world glorious hello")]
        [TestCase("ready set go vrooooom", "vrooooom go set ready")]
        public void ReturnUnknownAmmountOfWordsInReverseOrder(string text, string expected)
        {
            var reverser = new WordReverser();

            var result = reverser.ReverseWords(text);

            Assert.AreEqual(expected, result);
        }

        [TestCase("hello! hej world, top.", "top! world hej, hello.")]
        public void ReturnUnknownAmmountOfWordsInReverseOrderWithDelimiter(string text, string expected)
        {
            var reverser = new WordReverser();

            var result = reverser.ReverseWords(text);

            Assert.AreEqual(expected, result);
        }

    }
}
