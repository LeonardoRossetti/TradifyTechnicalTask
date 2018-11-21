using System;
using System.Collections.Generic;
using ConsoleTradifyTechnicalTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TradifyTechnicalTask.Tests
{
    [TestClass]
    public class PinGeneratorTest
    {
        [TestMethod]
        public void GetUniquePinList_Return1000()
        {
            //Arrange
            PinGenerator pinGenerator = new PinGenerator();

            //Act
            List<Int32> pinResult = pinGenerator.GeneratePins(1000, 4);

            //Assert
            Assert.AreEqual(1000, pinResult.Count);

            foreach (Int32 pin in pinResult)
            {
                Assert.IsTrue(pin < 9999, "Pin should be less than 9999.");
            }
        }

        [TestMethod]
        public void HasIncrementalPin_ReturnTrue()
        {
            //Arrange
            PinGenerator pinGenerator = new PinGenerator();

            //Act
            Boolean hasIncrementalPinsResult = pinGenerator.HasIncrementalDigits("1234");

            //Assert
            Assert.IsTrue(hasIncrementalPinsResult);
        }

        [TestMethod]
        public void NotHasIncrementalPin_ReturnFalse()
        {
            //Arrange
            PinGenerator pinGenerator = new PinGenerator();

            //Act
            Boolean haveIncrementalPinResult = pinGenerator.HasIncrementalDigits("1357");

            //Assert
            Assert.IsFalse(haveIncrementalPinResult);
        }

        [TestMethod]
        public void HaveRepeatedDigit_ReturnTrue()
        {
            //Arrange
            PinGenerator pinGenerator = new PinGenerator();

            //Act
            Boolean haveRepeatedDigitResult = pinGenerator.HasRepeatedDigits("1317");

            //Assert
            Assert.IsTrue(haveRepeatedDigitResult);
        }

        [TestMethod]
        public void HaveRepeatedDigit_ReturnFalse()
        {
            //Arrange
            PinGenerator pinGenerator = new PinGenerator();
            
            //Act
            Boolean haveRepeatedDigitResult = pinGenerator.HasRepeatedDigits("1357");

            //Assert
            Assert.IsFalse(haveRepeatedDigitResult);
        }

        [TestMethod()]
        public void WhenParametersAreZero_ArgumentException()
        {
            //Arrange
            PinGenerator pinGenerator = new PinGenerator();

            //Act

            //Assert
            CustomAssert.Throws<ArgumentException>(() => pinGenerator.GeneratePins(0, 1));
            CustomAssert.Throws<ArgumentException>(() => pinGenerator.GeneratePins(1, 0));
        }

        [TestMethod()]
        public void WhenQuantityExcedsMaximumPossibilitiesAvailable_Exception()
        {
            //Arrange
            PinGenerator pinGenerator = new PinGenerator();

            //Act

            //Assert
            CustomAssert.Throws<Exception>(() => pinGenerator.GeneratePins(100, 2));
        }
    }
}
