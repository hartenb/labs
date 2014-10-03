using System.ComponentModel;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFCG.StringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers == "") return 0;
            
            if (!numbers.Contains(",")) return Convert.ToInt32(numbers);
            
            var ints = numbers.Split(',').Select(int.Parse).ToArray();
            var sum = ints.Sum();
           
            return sum;
        }
    }

    [TestFixture]
    public class StringCalculatorTests
    { 

        [Test]
        public void Add_WithEmptyString_Return0()
        {
            ArrangeActAssert("", 0);
        }

        [TestCase("1", 1)]
        [TestCase("2", 2)]
        public void Add_WithSingleNumber_ReturnThatNumber(string numbers, int expected)
        {
            ArrangeActAssert(numbers, expected);
        }

        [TestCase("1, 2", 3)]
        public void Add_WithMultipleNumbers_returnSum(string numbers, int expected)
        {
            ArrangeActAssert(numbers, expected);
        }

        private static void ArrangeActAssert(string numbers, int expected)
        {
            var calculator = new StringCalculator();

            var result = calculator.Add(numbers);

            Assert.AreEqual(expected, result);

        }
    }
}
