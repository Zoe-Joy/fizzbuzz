﻿using cons = System.Console; 
using NUnit.Framework;
using FizzBuzz.Console.Constants;

namespace FizzBuzz.Console.Tests.Services
{
    /// <summary>
    /// Init tests for the <see cref="Converter"/> class
    /// </summary>
    [TestFixture]
    internal class ConverterTests
    {
        #region ConvertNumberToWord Tests

        [Test]
        [TestCase(3)]
        [TestCase(6)]
        [TestCase(9)]
        [TestCase(12)]
        public void FizzBuzz_ConvertNumberToWord_Should_Return_Fizz_For_Numbers_Divisible_By_Three(int inputNumber)
        {
            //Arrange && Act
            var result = Console.Services.Converter.ConvertNumberToWord(inputNumber);

            //Assert
            Assert.AreEqual(StringConstants.Fizz, result);
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        public void FizzBuzz_ConvertNumberToWord_Should_Return_Buzz_For_Numbers_Divisible_By_Five(int inputNumber)
        {
            //Arrange && Act
            var result = Console.Services.Converter.ConvertNumberToWord(inputNumber);

            //Assert
            Assert.AreEqual(StringConstants.Buzz, result);
        }

        [Test]
        [TestCase(15)]
        [TestCase(30)]
        [TestCase(45)]
        public void FizzBuzz_ConvertNumberToWord_Should_Return_FizzBuzz_For_Numbers_Divisible_By_Both_Three_And_Five(int inputNumber)
        {
            //Arrange && Act
            var result = Console.Services.Converter.ConvertNumberToWord(inputNumber);

            //Assert
            Assert.AreEqual(StringConstants.FizzBuzz, result);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(7)]
        [TestCase(11)]
        public void FizzBuzz_ConvertNumberToWord_Should_Return_InputNumber_For_Numbers_Not_Divisible_By_Three_Or_Five(int inputNumber)
        {
            //Arrange && Act
            var result = Console.Services.Converter.ConvertNumberToWord(inputNumber);

            //Assert
            Assert.AreEqual(inputNumber.ToString(), result);
        }

        #endregion       
    }
}
