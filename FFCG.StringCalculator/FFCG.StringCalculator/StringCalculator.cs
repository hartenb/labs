﻿using NUnit.Framework;
using System;
using System.Linq;

namespace FFCG.StringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers == "") return 0;
            
            if (!numbers.Contains(",")) return Convert.ToInt32(numbers);
            
            var integers = numbers.Split(',').Select(int.Parse).ToArray();
            var sum = integers.Sum();
           
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
