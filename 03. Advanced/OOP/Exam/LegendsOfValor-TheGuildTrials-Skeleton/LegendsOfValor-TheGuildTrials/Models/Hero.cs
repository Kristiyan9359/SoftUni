using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfValor_TheGuildTrials.Models
{
    public abstract class Hero : IHero
    {
        private string name;
        private string runeMark;
        private string guildName;
        private int power;
        private int mana;
        private int stamina;

        public Hero(string name, string runeMark, int power, int mana, int stamina)
        {
            Name = name;
            RuneMark = runeMark;
            Power = power;
            Mana = mana;
            Stamina = stamina;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ErrorMessages.InvalidHeroName);
                }
                name = value;
            }
        }

        public string RuneMark
        {
            get { return runeMark; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ErrorMessages.InvalidHeroRuneMark);
                }
                runeMark = value;
            }
        }
        public string GuildName
        {
            get { return guildName; }
            private set { guildName = value; }
        }

        public int Power
        {
            get { return power; }
            protected set
            {
                power = value;
            }
        }

        public int Mana
        {
            get { return mana; }
            protected set
            {
                mana = value;
            }
        }

        public int Stamina
        {
            get { return stamina; }
            protected set
            {
                stamina = value;
            }
        }

        public void JoinGuild(IGuild guild)
        {
            GuildName = guild.Name;
        }

        public abstract void Train();

        public string Essence()
        {
            return $"Essence Revealed - Power [{Power}] Mana [{Mana}] Stamina [{Stamina}]";
        }
        public override string ToString()
        {
            return $"Hero: [{Name}] of the Guild '{GuildName}' - RuneMark: {RuneMark}";
        }
    }
}
