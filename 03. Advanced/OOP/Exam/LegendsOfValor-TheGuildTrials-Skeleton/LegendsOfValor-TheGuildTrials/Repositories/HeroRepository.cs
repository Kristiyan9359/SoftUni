using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Repositories.Contratcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfValor_TheGuildTrials.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private readonly List<IHero> heroes;

        public HeroRepository()
        {
            heroes = new List<IHero>();
        }
        public void AddModel(IHero entity)
        => heroes.Add(entity);

        public IHero GetModel(string runeMarkOrGuildName)
       => heroes.FirstOrDefault(h => h.RuneMark == runeMarkOrGuildName);

        public IReadOnlyCollection<IHero> GetAll() => heroes.AsReadOnly();
    }
}
