using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfValor_TheGuildTrials.Models
{
    public class Warrior : Hero
    {
        private readonly string[] allowedGuilds = { "WarriorGuild", "ShadowGuild" };
        private const int power = 60;
        private const int mana = 0;
        private const int stamina = 100;
        public Warrior(string name, string runeMark) : base(name, runeMark, power, mana, stamina)
        {
        }

        public override void Train()
        {
            Power += 30;
            Stamina += 10;
        }
        public string[] AllowedGuilds => allowedGuilds;
    }
}
