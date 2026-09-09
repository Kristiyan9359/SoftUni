using LegendsOfValor_TheGuildTrials.Models.Contracts;
using LegendsOfValor_TheGuildTrials.Repositories.Contratcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendsOfValor_TheGuildTrials.Repositories
{
    public class GuildRepository : IRepository<IGuild>
    {
        private readonly List<IGuild> guilds;

        public GuildRepository()
        {
            guilds = new List<IGuild>();
        }
        public void AddModel(IGuild entity)
        => guilds.Add(entity);

        public IGuild GetModel(string runeMarkOrGuildName)
        => guilds.FirstOrDefault(g => g.Name == runeMarkOrGuildName);

        public IReadOnlyCollection<IGuild> GetAll() => guilds.AsReadOnly();

    }
}
