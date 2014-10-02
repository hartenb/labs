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
            if (text.Contains(" "))
            {
                string[] inputString = text.Split(Convert.ToChar(' '));
                text = inputString[1] + ' ' + inputString[0];
                return text;
            }
            return text;
        }
    }

    public class WordReverserTests
    {
        //1.	En mening med endast ett ord ska returnera ordet i sin urpsrungsform, tex: ReverseWords(”hello”) -> ”hello”
        [TestCase("hello", "hello")]
        public void ReturnWordAsItComes(string text, string expected)
        {
            var reverser = new WordReverser();

            var result = reverser.ReverseWords(text);

            Assert.AreEqual(result, expected);
        }

        //En mening med två ord skall returnera en mening med orden i omvänd ordning: ReverseWords(”hello world”) -> ”world hello”
        [TestCase("hello world", "world hello")]
        public void ReturnTwoWordsInReverseOrder(string text, string expected)
        {
            var reverser = new WordReverser();

            var result = reverser.ReverseWords(text);

            Assert.AreEqual(result, expected);
        }
    }
}
