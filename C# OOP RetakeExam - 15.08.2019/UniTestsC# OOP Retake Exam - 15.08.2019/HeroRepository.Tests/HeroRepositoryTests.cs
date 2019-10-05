using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAddingNullHeroException()
        {
            Hero hero = null;
            HeroRepository heroes = new HeroRepository();

            Assert.Throws<ArgumentNullException>(() =>
            {
                heroes.Create(hero);
            });
        }

        [Test]
        public void TestAddingExistingHeroException()
        {
            Hero hero = new Hero("Nikolay", 25);
            HeroRepository heroes = new HeroRepository();

            heroes.Create(hero);

            Assert.Throws<InvalidOperationException>(() =>
            {
                heroes.Create(hero);
            });
        }

        [Test]
        public void TestRemovingNullOrEmptySpaceHero()
        {
            HeroRepository heroes = new HeroRepository();

            Assert.Throws<ArgumentNullException>(() =>
            {
                heroes.Remove("");
            });
        }

        [Test]
        public void TestRemovingCorrectly()
        {
            HeroRepository heroes = new HeroRepository();
            Hero hero = new Hero("Nikolay", 25);

            heroes.Create(hero);

            int expectedCount = 0;

            bool actualResult = heroes.Remove("Nikolay");
            int actualCount = heroes.Heroes.Count;


            Assert.AreEqual(expectedCount, actualCount);
            Assert.That(actualResult, Is.True);

        }

        [Test]
        public void GetHeroWithHighestLevelWorkCorrectly()
        {
            Hero niko = new Hero("Nikolay", 25);
            Hero poli = new Hero("Pavlina", 28);
            HeroRepository heroes = new HeroRepository();
            heroes.Create(niko);
            heroes.Create(poli);
            Hero expectedHero = poli;

            Hero actualHero = heroes.GetHeroWithHighestLevel();

            Assert.That(expectedHero, Is.EqualTo(actualHero));

        }

        [Test]
        public void GetHeroByNameWorkCorrectly()
        {
            Hero niko = new Hero("Nikolay", 25);
            HeroRepository heroes = new HeroRepository();
            heroes.Create(niko);
            Hero expectedHero = niko;

            Hero actualHero = heroes.GetHero("Nikolay");

            Assert.That(expectedHero, Is.EqualTo(actualHero));
        }
    }
}