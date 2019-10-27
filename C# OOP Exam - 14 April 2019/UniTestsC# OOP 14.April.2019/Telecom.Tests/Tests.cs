using System;
using System.Runtime.CompilerServices;

namespace Telecom.Tests
{
    using NUnit.Framework;

    public class Tests
    {
        private const string make = "Samsung";
        private const string model = "S10+";

        private Phone phone;

        [SetUp]
        public void SetUp()
        {
            this.phone = new Phone(make,model);
        }


        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            Assert.AreEqual(make, phone.Make);
            Assert.AreEqual(model, phone.Model);
        }

        [Test]
        public void TestWtihLikeEmptyMake()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Phone phone = new Phone(string.Empty, model);
            });
        }

        [Test]
        public void TestWithLikeEmptyModel()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Phone phone = new Phone(make, String.Empty);
            });
        }

        [Test]
        public void InitialCountShouldBeZero()
        {
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, phone.Count);
        }

        [Test]
        public void TestIfAddWorksCorrectly()
        {
            int expectedCount = 2;
            this.phone.AddContact("Pesho", "+359898975484");
            this.phone.AddContact("Gosho", "+359823375484");

            Assert.AreEqual(expectedCount, phone.Count);
        }

        [Test]
        public void TestAddingExistingPerson()
        {
            this.phone.AddContact("Pesho", "+359898975484");

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.phone.AddContact("Pesho", "+359898975484");
            });
        }

        [Test]
        public void AddShouldCallableNumber()
        {
            string name = "Pesho";
            string number = "+359898975484";
            string expectedOutput = $"Calling {name} - {number}...";
            this.phone.AddContact(name, number);

            string actualOutput = this.phone.Call(name);

            Assert.AreEqual(expectedOutput,actualOutput);
        }

        [Test]
        public void TestingCallingNonExistingPerson()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.phone.Call("Pesho");
            });
        }
    }
}