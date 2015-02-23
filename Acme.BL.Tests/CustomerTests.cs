using AcmeBL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acme.BL.Tests
{
    using AcmeBL;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    // ONE TEST CASE ONLY PER TEST
    // 1. Valid input tests
    // 2. Invalid input tests
    [TestClass]
    public class CustomerTests
    {
        #region Public Methods and Operators

        [TestMethod]
        public void CalculatePercentOfGoalsStepsTestValid()
        {
            // Arrange
            var customer = new Customer();

            // Define inputs
            string goalSteps = "5000";
            string actualSteps = "2000";
            decimal expcected = 40M;

            // Act
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            // Assert - verifies
            Assert.AreEqual(expcected, actual);
        }

        [TestMethod]
        public void CalculatePercentOfGoalsStepsTestValidActualIsZero()
        {
            // Arrange
            var customer = new Customer();

            // Define inputs
            string goalSteps = "5000";
            string actualSteps = "0";
            decimal expcected = 0M;

            // Act
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            // Assert - verifies
            Assert.AreEqual(expcected, actual);
        }

        [TestMethod]
        public void CalculatePercentOfGoalsStepsTestValidAndSame()
        {
            // Arrange
            var customer = new Customer();

            // Define inputs
            string goalSteps = "5000";
            string actualSteps = "5000";
            decimal expcected = 100M;

            // Act
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            // Assert - verifies
            Assert.AreEqual(expcected, actual);
        }

        // INVALID INPUT TESTS
        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void CalculatePercentOfGoalsStepsTestTestGoalIsNull()
        {
            // Arrange
            var customer = new Customer();

            // Define inputs
            string goalSteps = "5000";
            string actualSteps = "5000";

            // Act
            var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);

            // Assert - verifies
            // No need to assert - argument exception
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void CalculatePercentOfGoalsStepsTestTestGoalIsNotNumeric()
        {
            // Arrange
            var customer = new Customer();

            // Define inputs
            string goalSteps = "one";
            string actualSteps = "5000";

            // Act
            try
            {
                var actual = customer.CalculatePercentOfGoalSteps(goalSteps, actualSteps);
            }
            catch(System.Exception ex)
            {
                Assert.AreEqual("Goal must be numeric", ex.Message);
            }

            // Assert - verifies
            // No need to assert - argument exception
        }

        #endregion
    }
}