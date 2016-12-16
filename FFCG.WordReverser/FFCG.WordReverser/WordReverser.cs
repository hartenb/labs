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
            var delimiters = new List<Tuple<int, string>>();
            var wordsToReverse = text.Split(' ');
            
            for (var i = 0; i < wordsToReverse.Length; i++)
            {
                var currentWord = wordsToReverse[i];

                if (ContainsDelimiter(currentWord))
                {
                    CreateTuple(i, wordsToReverse, delimiters);
                }
            }
            
            Array.Reverse(wordsToReverse);
            
            if (delimiters.Count > 0)
            {
                foreach(var t in delimiters) {
                    var positionToChange = t.Item1;
                    var characterToAdd = t.Item2;
                    wordsToReverse[positionToChange] = string.Concat(wordsToReverse[positionToChange], characterToAdd);
                }
            }
           
            return string.Join(" ", wordsToReverse);
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
