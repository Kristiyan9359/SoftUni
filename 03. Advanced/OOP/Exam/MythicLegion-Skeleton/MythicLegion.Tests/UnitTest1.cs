using NUnit.Framework;
using System;

namespace MythicLegion.Tests
{
    public class Tests
    {
        [Test]
        public void AddHeroShouldAddHeroSuccessfully()
        {
            var legion = new Legion();
            var hero = new Hero("Ahil", "Hector");

            legion.AddHero(hero);

            Assert.That(legion.GetLegionInfo(), Does.Contain("Ahil"));
        }

        [Test]
        public void AddHeroShouldThrowWhenHeroIsNull()
        {
            var legion = new Legion();

            var ex = Assert.Throws<ArgumentNullException>(() => legion.AddHero(null));
            Assert.That(ex.ParamName, Is.EqualTo("hero"));
        }

        [Test]
        public void AddHeroShouldThrowWhenHeroNameExists()
        {
            var legion = new Legion();
            var hero1 = new Hero("Ahil", "Hector");
            var hero2 = new Hero("Ahil", "Leonid");

            legion.AddHero(hero1);

            var ex = Assert.Throws<ArgumentException>(() => legion.AddHero(hero2));
            Assert.That(ex.Message, Does.Contain("already exists"));
        }

        [Test]
        public void RemoveHeroShouldReturnTrueWhenHeroExists()
        {
            var legion = new Legion();
            var hero = new Hero("Ahil", "Hector");
            legion.AddHero(hero);

            var result = legion.RemoveHero("Ahil");

            Assert.IsTrue(result);
            Assert.That(legion.GetLegionInfo(), Does.Not.Contain("Ahil"));
        }

        [Test]
        public void RemoveHeroShouldReturnFalseWhenHeroDoesNotExist()
        {
            var legion = new Legion();

            var result = legion.RemoveHero("NonExistent");

            Assert.IsFalse(result);
        }

        [Test]
        public void TrainHeroShouldIncreaseStatsAndSetIsTrained()
        {
            var legion = new Legion();
            var hero = new Hero("Ahil", "Hector");
            legion.AddHero(hero);

            var result = legion.TrainHero("Ahil");

            Assert.That(hero.Health, Is.EqualTo(101));
            Assert.That(hero.Power, Is.EqualTo(30));
            Assert.That(hero.IsTrained, Is.True);
            Assert.That(result, Is.EqualTo("Ahil has been trained."));
        }

        [Test]
        public void TrainHeroShouldReturnNotFoundMessageWhenHeroDoesNotExist()
        {
            var legion = new Legion();

            var result = legion.TrainHero("NonExistent");

            Assert.That(result, Is.EqualTo("Hero with name NonExistent not found."));
        }

        [Test]
        public void GetLegionInfoShouldReturnNoHeroesMessageWhenEmpty()
        {
            var legion = new Legion();

            var info = legion.GetLegionInfo();

            Assert.That(info, Is.EqualTo("No heroes in the legion."));
        }

        [Test]
        public void GetLegionInfoShouldReturnAllHeroesInfo()
        {
            var legion = new Legion();
            var hero1 = new Hero("Ahil", "Hector");
            var hero2 = new Hero("Paris", "Leonid");
            legion.AddHero(hero1);
            legion.AddHero(hero2);

            var info = legion.GetLegionInfo();

            Assert.That(info, Does.Contain(hero1.ToString()));
            Assert.That(info, Does.Contain(hero2.ToString()));
        }
    }
}