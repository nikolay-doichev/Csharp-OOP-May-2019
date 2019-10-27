using System;
using NUnit.Framework;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void AddRaiderShouldAddSuccesfully()
        {
            //Arrange
            RaceEntry raceEntry = new RaceEntry();
            UnitMotorcycle unitMotorcycle = new UnitMotorcycle("Kawasaki", 60, 500);
            UnitRider rider = new UnitRider("Ivan", unitMotorcycle);

            //Act
            string resultMessage = raceEntry.AddRider(rider);

            //Assert
            string expectedMessage = $"Rider Ivan added in race.";

            Assert.AreEqual(expectedMessage, resultMessage);
            Assert.AreEqual(raceEntry.Counter, 1);
        }

        [Test]
        public void AddRaiderShouldThrowInvalidOperationExpetionIfNull()
        {
            //Arrange
            RaceEntry raceEntry = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() =>
                raceEntry.AddRider(null), "Rider cannot be null.");
        }

        [Test]
        public void AddRaiderShouldThrowInvalidOperationExpetionIfRaiderExist()
        {
            RaceEntry raceEntry = new RaceEntry();
            UnitMotorcycle unitMotorcycle = new UnitMotorcycle("Kawasaki", 60, 500);
            UnitRider rider = new UnitRider("Ivan", unitMotorcycle);

            //Act
            string resultMessage = raceEntry.AddRider(rider);

            Assert.Throws<InvalidOperationException>(() =>
                raceEntry.AddRider(rider), "Rider Ivan added in race.");
        }

        [Test]
        public void CalculateAverageHorsePower_Should_ReturnsAvaregaHorsePowerOfAllRiders()
        {
            RaceEntry raceEntry = new RaceEntry();

            UnitMotorcycle unitMotorcycle1 = new UnitMotorcycle("Kawasaki", 60, 500);
            UnitRider rider1 = new UnitRider("Ivan", unitMotorcycle1);

            UnitMotorcycle unitMotorcycle2 = new UnitMotorcycle("Honda", 24, 500);
            UnitRider rider2 = new UnitRider("Peter", unitMotorcycle2);

            UnitMotorcycle unitMotorcycle3 = new UnitMotorcycle("Yamaha", 78, 500);
            UnitRider rider3 = new UnitRider("Sam", unitMotorcycle3);

            raceEntry.AddRider(rider1);
            raceEntry.AddRider(rider2);
            raceEntry.AddRider(rider3);

            var result = raceEntry.CalculateAverageHorsePower();
            var expectedResult = 54;

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void CalculateAverageHorsePower_Should_ReturnsinvalidOperationExpception()
        {
            RaceEntry raceEntry = new RaceEntry();

            UnitMotorcycle unitMotorcycle1 = new UnitMotorcycle("Kawasaki", 60, 500);
            UnitRider rider1 = new UnitRider("Ivan", unitMotorcycle1);

            raceEntry.AddRider(rider1);

            Assert.Throws<InvalidOperationException>(() =>
                raceEntry.CalculateAverageHorsePower(), "The race cannot start with less than 2 participants.");
        }
    }
}