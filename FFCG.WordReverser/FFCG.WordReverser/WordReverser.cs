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
            string[] customString = text.Split(' ');
            Array.Reverse(customString);
            return string.Join(" ", customString);
        }
    }

    public class WordReverserTests
    {
        [TestCase("hello", "hello")]
        public void ReturnWordAsItComes(string text, string expected)
        {
            var reverser = new WordReverser();

            var result = reverser.ReverseWords(text);

            Assert.AreEqual(result, expected);
        }

        [TestCase("hello world", "world hello")]
        public void ReturnTwoWordsInReverseOrder(string text, string expected)
        {
            var reverser = new WordReverser();

            var result = reverser.ReverseWords(text);

            Assert.AreEqual(result, expected);
        }

        [TestCase("hello glorious world", "world glorious hello")]
        [TestCase("ready set go vrooooom", "vrooooom go set ready")]
        public void ReturnUnknownAmmountOfWordsInReverseOrder(string text, string expected)
        {
            var reverser = new WordReverser();

            var result = reverser.ReverseWords(text);

            Assert.AreEqual(result, expected);
        }
    }
}
