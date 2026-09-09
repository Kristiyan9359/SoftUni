
namespace _09.PokemonTrainer;

public class Program
{

    static void Main()
    {
        List<Trainer> trainers = new List<Trainer>();

        string command;

        while ((command = Console.ReadLine()) != "Tournament")
        {
            string[] data = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string trainerName = data[0];
            string pokemonName = data[1];
            string pokemonElement = data[2];
            int pokemonHealth = int.Parse(data[3]);

            if (!trainers.Any(t => t.Name == trainerName))
            {
                trainers.Add(new Trainer(trainerName));
            }

            Trainer currentTrainer = trainers.First(t => t.Name == trainerName);

            currentTrainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
        }


        while ((command = Console.ReadLine()) != "End")
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Pokemons.Any(p => p.Element == command))
                {
                    trainer.Badges++;
                }
                else
                {
                    foreach (var pokemon in trainer.Pokemons)
                    {
                        pokemon.Health -= 10;
                    }
                    trainer.Pokemons.RemoveAll(p => p.Health <= 0);
                }
            }
        }

        foreach (var trainer in trainers.OrderByDescending(t => t.Badges))
        {
            Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
        }

    }
}
