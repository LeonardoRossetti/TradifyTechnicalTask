using System;
using System.Collections.Generic;
using ConsoleTradifyTechnicalTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TradifyTechnicalTask.Tests
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void GetUniquePinList_ShouldReturn1000()
        {
            //Arrange
            PinGenerator pinGenerator = new PinGenerator();

            //Act
            List<Int32> uniquePinListResult = PinGenerator.GetUniquePinList();

            //Assert
            Assert.AreEqual(1000, uniquePinListResult.Count);
        }

        [TestMethod]
        public void HaveIncrementalNumber_ShouldReturnTrue()
        {
            //Arrange
            PinGenerator pinGenerator = new PinGenerator(1000, 9999);
            String number = "1234";

            //Act
            Boolean haveIncrementalNumberResult = PinGenerator.HasIncrementalDigits(number);

            //Assert
            Assert.IsTrue(haveIncrementalNumberResult);
        }

        [TestMethod]
        public void NotHaveIncrementalNumber_ShouldReturnFalse()
        {
            //Arrange
            PinGenerator pinGenerator = new PinGenerator(1000, 9999);
            String number = "1357";

            //Act
            Boolean haveIncrementalNumberResult = PinGenerator.HasIncrementalDigits(number);

            //Assert
            Assert.IsFalse(haveIncrementalNumberResult);
        }

        [TestMethod]
        public void HaveRepeatedDigit_ShouldReturnTrue()
        {
            //Arrange
            PinGenerator pinGenerator = new PinGenerator(1000, 9999);
            String number = "1317";

            //Act
            Boolean haveRepeatedDigitResult = PinGenerator.HasRepeatedDigits(number);

            //Assert
            Assert.IsTrue(haveRepeatedDigitResult);
        }

        [TestMethod]
        public void HaveRepeatedDigit_ShouldReturnFalse()
        {
            //Arrange
            PinGenerator pinGenerator = new PinGenerator();
            String number = "1357";

            //Act
            Boolean haveRepeatedDigitResult = PinGenerator.HasRepeatedDigits(number);

            //Assert
            Assert.IsFalse(haveRepeatedDigitResult);
        }
    }
}
