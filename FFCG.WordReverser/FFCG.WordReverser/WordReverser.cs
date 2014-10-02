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
            return text;
        }
    }

    public class WordReverserTests
    {
        //1.	En mening med endast ett ord ska returnera ordet i sin urpsrungsform, tex: ReverseWords(”hello”) -> ”hello”

        [TestCase("Hello", "Hello")]
        public void ReturnWordAsItComes(string text, string expected)
        {
            var reverser = new WordReverser();

            var result = reverser.ReverseWords(text);

            Assert.AreEqual(text, expected);
        }
    }
}
