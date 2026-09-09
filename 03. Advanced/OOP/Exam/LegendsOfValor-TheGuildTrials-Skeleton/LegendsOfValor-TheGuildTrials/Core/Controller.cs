using LegendsOfValor_TheGuildTrials.Core.Contracts;
using LegendsOfValor_TheGuildTrials.Models;
using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Repositories;
using LegendsOfValor_TheGuildTrials.Repositories.Contratcs;
using LegendsOfValor_TheGuildTrials.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfValor_TheGuildTrials.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IHero> heroes;
        private readonly IRepository<IGuild> guilds;
        public Controller()
        {
            heroes = new HeroRepository();
            guilds = new GuildRepository();
        }
        public string AddHero(string heroTypeName, string heroName, string runeMark)
        {
            if (heroes.GetModel(runeMark) != null)
                return string.Format(OutputMessages.HeroAlreadyExists, runeMark);

            IHero hero;
            switch (heroTypeName)
            {
                case "Warrior":
                    hero = new Warrior(heroName, runeMark);
                    break;
                case "Sorcerer":
                    hero = new Sorcerer(heroName, runeMark);
                    break;
                case "Spellblade":
                    hero = new Spellblade(heroName, runeMark);
                    break;
                default:
                    return string.Format(OutputMessages.InvalidHeroType, heroTypeName);
            }

            heroes.AddModel(hero);

            return string.Format(OutputMessages.HeroAdded, heroTypeName, heroName, runeMark);
        }

        public string CreateGuild(string guildName)
        {
            if (guilds.GetModel(guildName) != null)
            {
                return string.Format(OutputMessages.GuildAlreadyExists, guildName);
            }

            var guild = new Guild(guildName);

            guilds.AddModel(guild);

            return string.Format(OutputMessages.GuildCreated, guildName);
        }

        public string RecruitHero(string runeMark, string guildName)
        {
            var hero = heroes.GetModel(runeMark);
            if (hero == null)
                return string.Format(OutputMessages.HeroNotFound, runeMark);

            var guild = guilds.GetModel(guildName);

            if (guild == null)
                return string.Format(OutputMessages.GuildNotFound, guildName);

            if (!string.IsNullOrEmpty(hero.GuildName))
                return string.Format(OutputMessages.HeroAlreadyInGuild, hero.Name);

            if (guild.IsFallen)
                return string.Format(OutputMessages.GuildIsFallen, guildName);

            if (guild.Wealth < 500)
                return string.Format(OutputMessages.GuildCannotAffordRecruitment, guildName);

            string heroTypeName = hero switch
            {
                Warrior => "Warrior",
                Sorcerer => "Sorcerer",
                Spellblade => "Spellblade",
                _ => throw new InvalidOperationException()
            };

            var allowedGuilds = hero switch
            {
                Warrior w => w.AllowedGuilds,
                Sorcerer s => s.AllowedGuilds,
                Spellblade s => s.AllowedGuilds,
                _ => throw new InvalidOperationException()
            };

            if (!allowedGuilds.Contains(guildName))
                return string.Format(OutputMessages.HeroTypeNotCompatible, heroTypeName, guildName);

            hero.JoinGuild(guild);
            guild.RecruitHero(hero);
            return string.Format(OutputMessages.HeroRecruited, hero.Name, guildName);
        }

        public string TrainingDay(string guildName)
        {
            var guild = guilds.GetModel(guildName);
            if (guild == null)
                return string.Format(OutputMessages.GuildNotFound, guildName);

            if (guild.IsFallen)
                return string.Format(OutputMessages.GuildTrainingDayIsFallen, guildName);

            int totalTrainingCost = guild.Legion.Count * 200;
            if (guild.Wealth < totalTrainingCost)
                return string.Format(OutputMessages.TrainingDayFailed, guildName);

            var heroesToTrain = guild.Legion
                .Select(runeMark => heroes.GetModel(runeMark))
                .Where(h => h != null)
                .ToList();

            guild.TrainLegion(heroesToTrain);
            return string.Format(OutputMessages.TrainingDayStarted, guildName, heroesToTrain.Count, totalTrainingCost);
        }
        public string StartWar(string attackerGuildName, string defenderGuildName)
        {
            var attacker = guilds.GetModel(attackerGuildName);
            var defender = guilds.GetModel(defenderGuildName);

            if (attacker == null || defender == null)
                return OutputMessages.OneOfTheGuildsDoesNotExist;

            if (attacker.IsFallen || defender.IsFallen)
                return OutputMessages.OneOfTheGuildsIsFallen;

            int attackerStrength = attacker.Legion
                .Select(runeMark => heroes.GetModel(runeMark))
                .Where(h => h != null)
                .Sum(h => (int)h.Power + h.Mana + h.Stamina);

            int defenderStrength = defender.Legion
                .Select(runeMark => heroes.GetModel(runeMark))
                .Where(h => h != null)
                .Sum(h => (int)h.Power + h.Mana + h.Stamina);

            if (attackerStrength > defenderStrength)
            {
                int goldToClaim = defender.Wealth;
                attacker.WinWar(goldToClaim);
                defender.LoseWar();

                return string.Format(OutputMessages.WarWon, attackerGuildName, defenderGuildName, goldToClaim);
            }
            else
            {
                int goldToClaim = attacker.Wealth;
                defender.WinWar(goldToClaim);
                attacker.LoseWar();

                return string.Format(OutputMessages.WarLost, defenderGuildName, goldToClaim, attackerGuildName);
            }

        }

        public string ValorState()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Valor State:");

            var sortedGuilds = guilds.GetAll().OrderByDescending(g => g.Wealth);
            foreach (var guild in sortedGuilds)
            {
                sb.AppendLine($"{guild.Name} (Wealth: {guild.Wealth})");
                var guildHeroes = guild.Legion
                    .Select(runeMark => heroes.GetModel(runeMark))
                    .Where(h => h != null)
                    .OrderBy(h => h.Name);

                foreach (var hero in guildHeroes)
                {
                    sb.AppendLine($"-{hero.ToString()}");
                    sb.AppendLine($"--{hero.Essence()}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
