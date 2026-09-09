using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfValor_TheGuildTrials.Models
{
    public class Sorcerer : Hero
    {
        private readonly string[] allowedGuilds = { "SorcererGuild", "ShadowGuild" };
        private const int power = 40;
        private const int mana = 120;
        private const int stamina = 0;
        public Sorcerer(string name, string runeMark) : base(name, runeMark, power, mana, stamina)
        {
        }

        public override void Train()
        {
            Power += 20;
            Mana += 25;
        }
        public string[] AllowedGuilds => allowedGuilds;
    }
}
