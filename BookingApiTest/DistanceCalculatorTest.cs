using BookingApi.Helper;
using NSubstitute;
using NUnit.Framework;

namespace BookingApiTest
{
    /// <summary>
    /// Unit tests for the <see cref="DistanceCalculator"/> class.
    /// </summary>
    public class DistanceCalculatorTest
    {
        private readonly IDistanceCalculator _distanceCalculator;

        public DistanceCalculatorTest() 
        {
            _distanceCalculator = new DistanceCalculator();
        }

        [Test]
        [TestCase(59.34411099999999, 59.3251172, 18.049118499999963, 18.0710935, 2.4522915771639235)]
        [TestCase(59.34411099999999, 0, 18.049118499999963, 0, 6783.032080126296)]
        [TestCase(44.8178131, 59.3251172, 20.4568974, 18.0710935, 1621.097485999554)]
        public void CalculateDistance(double lat1, double lat2, double lon1, double lon2, double expectedResult)
        {
            // Arrange
            // Act
            var result = _distanceCalculator.CalculateDistance(lat1, lat2, lon1, lon2);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}