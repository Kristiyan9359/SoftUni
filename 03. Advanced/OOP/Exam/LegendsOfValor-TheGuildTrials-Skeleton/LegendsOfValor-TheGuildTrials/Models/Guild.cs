using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfValor_TheGuildTrials.Models
{
    public class Guild : IGuild
    {
        private string name;
        private int wealth;
        private List<string> legion;
        private bool isFallen;

        public Guild(string name)
        {
            Name = name;
            wealth = 5000;
            legion = new List<string>();
            isFallen = false;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (value != "WarriorGuild" && value != "SorcererGuild" && value != "ShadowGuild")
                    throw new ArgumentException(ErrorMessages.InvalidGuildName);
                name = value;
            }
        }

        public int Wealth
        {
            get { return wealth; }
            private set
            {
                if (value < 0)
                {
                    wealth = 0;
                }
                wealth = value;
            }
        }

        public IReadOnlyCollection<string> Legion => legion.AsReadOnly();

        public bool IsFallen
        {
            get { return isFallen; }
            private set { isFallen = value; }
        }

        public void RecruitHero(IHero hero)
        {
            legion.Add(hero.RuneMark);
            Wealth -= 500;
        }
        public void TrainLegion(ICollection<IHero> heroesToTrain)
        {
            Wealth -= 200 * heroesToTrain.Count;
            foreach (var hero in heroesToTrain)
            {
                hero.Train();
            }
        }
        public void WinWar(int goldAmount)
        {
            Wealth += goldAmount;
        }
        public void LoseWar()
        {
            isFallen = true;
            Wealth = 0;
        }
    }
}
