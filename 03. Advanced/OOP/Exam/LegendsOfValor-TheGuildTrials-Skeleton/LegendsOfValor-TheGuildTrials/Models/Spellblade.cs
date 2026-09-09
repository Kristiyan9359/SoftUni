using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfValor_TheGuildTrials.Models
{
    public class Spellblade : Hero
    {
        private readonly string[] allowedGuilds = { "WarriorGuild", "SorcererGuild" };
        private const int power = 50;
        private const int mana = 60;
        private const int stamina = 60;
        public Spellblade(string name, string runeMark) : base(name, runeMark, power, mana, stamina)
        {
        }

        public override void Train()
        {
            Power += 15;
            Mana += 10;
            Stamina += 10;
        }
        public string[] AllowedGuilds => allowedGuilds;
    }
}
