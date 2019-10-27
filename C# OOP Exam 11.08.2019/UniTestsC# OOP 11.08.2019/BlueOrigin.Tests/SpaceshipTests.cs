using System.Collections;
using System.Collections.Generic;

namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private const string astronautsName = "Nikolay";
        private const double oxygenInPercentage = 50;
        private ICollection<Astronaut> astronauts;
        private Spaceship spaceship;
       

        [Test]
        public void TestConstructorOfAustronout()
        {
            string astounutName = "Ivan";
            double oxygen = 50;
            Astronaut ivan = new Astronaut("Ivan",50);
            
            Assert.AreEqual(astounutName,ivan.Name);
            Assert.AreEqual(oxygen, ivan.OxygenInPercentage);
        }
        
        [Test]
        public void TestNameNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Spaceship spaceship = new Spaceship(String.Empty, 4);
            });
        }

       

        [Test]
        public void TestInvalidCapacity()
        {
            Assert.Throws<ArgumentException>((() =>
            {
                Spaceship spaceship = new Spaceship("Nasa", -1);
            }));
        }
        
        [Test]
        public void AddingStronautsThatExist()
        {
            this.astronauts = new List<Astronaut>();
            Astronaut ivan = new Astronaut("Ivan", 40);
            spaceship = new Spaceship("Nasa", 6);

            spaceship.Add(ivan);

            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    spaceship.Add(ivan);
                });
        }
        
        [Test]
        public void RemovingAstounts()
        {
            this.astronauts = new List<Astronaut>();
            Astronaut ivan = new Astronaut("Ivan", 40);
            spaceship = new Spaceship("Nasa", 6);
            spaceship.Add(ivan);

            int expectedCount = 0;
            spaceship.Remove("Ivan");
            int actualCount = spaceship.Count;



            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void SpaceShipIsFull()
        {
            this.astronauts = new List<Astronaut>();
            Astronaut ivan = new Astronaut("Ivan", 40);
            spaceship = new Spaceship("Nasa", 1);

            spaceship.Add(ivan);

            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    spaceship.Add(ivan);
                });
        }
        [Test]
        public void CapacityAndNameCheck()
        {
            this.astronauts = new List<Astronaut>();
            Astronaut ivan = new Astronaut("Ivan", 40);
            spaceship = new Spaceship("Nasa", 1);
            int expectedCapacity = 1;
            string expectedName = "Nasa";

            spaceship.Add(ivan);
            int actualCapacity = spaceship.Count;

            Assert.That(expectedCapacity,Is.EqualTo(spaceship.Capacity));
            Assert.That(expectedName, Is.EqualTo(spaceship.Name));
        }

    }
}