using System;
using ConsoleTradifyTechnicalTask;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TradifyTechnicalTask.Tests
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void HaveIncrementalNumber_ShouldReturnTrue()
        {
            //Arrange
            String number = "1234";

            //Act
            Boolean haveIncrementalNumberResult = Program.HaveIncrementalNumber(number);

            //Assert
            Assert.IsTrue(haveIncrementalNumberResult);
        }

        [TestMethod]
        public void NotHaveIncrementalNumber_ShouldReturnFalse()
        {
            //Arrange
            String number = "1357";

            //Act
            Boolean haveIncrementalNumberResult = Program.HaveIncrementalNumber(number);

            //Assert
            Assert.IsFalse(haveIncrementalNumberResult);
        }

        [TestMethod]
        public void HaveRepeatedDigit_ShouldReturnTrue()
        {
            //Arrange
            String number = "1317";

            //Act
            Boolean haveRepeatedDigitResult = Program.HaveRepeatedDigit(number);

            //Assert
            Assert.IsTrue(haveRepeatedDigitResult);
        }

        [TestMethod]
        public void HaveRepeatedDigit_ShouldReturnFalse()
        {
            //Arrange
            String number = "1357";

            //Act
            Boolean haveRepeatedDigitResult = Program.HaveRepeatedDigit(number);

            //Assert
            Assert.IsFalse(haveRepeatedDigitResult);
        }
    }
}
