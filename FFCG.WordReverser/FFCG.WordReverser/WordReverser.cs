using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace FFCG.WordReverser
{
    public class WordReverser
    {
        public string ReverseWords(string text)
        {
            var listOfDelimiters = new List<Tuple<int, string>>();
            var arrayOfWordsToReverse = text.Split(' ');
            
            for (var i = 0; i < arrayOfWordsToReverse.Length; i++)
            {
                var currentWord = arrayOfWordsToReverse[i];

                if (ContainsDelimiter(currentWord))
                {
                    CreateTuple(i, arrayOfWordsToReverse, listOfDelimiters);
                }
            }
            
            Array.Reverse(arrayOfWordsToReverse);
            
            if (listOfDelimiters.Count > 0)
            {
                foreach(var t in listOfDelimiters) {
                    var positionToChange = t.Item1;
                    var charToAdd = t.Item2;
                    arrayOfWordsToReverse[positionToChange] = string.Concat(arrayOfWordsToReverse[positionToChange], charToAdd);
                }
            }
           
            return string.Join(" ", arrayOfWordsToReverse);
        }

        private static void CreateTuple(int i, IList<string> customString, ICollection<Tuple<int, string>> listOfTuples)
        {
            var testTuple = new Tuple<int, string>(i, customString[i].Last().ToString());
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
