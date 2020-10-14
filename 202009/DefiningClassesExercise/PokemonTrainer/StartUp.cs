using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            string input = String.Empty;

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] tokens = input.Split().ToArray();

                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                Pokemon newPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer(trainerName, newPokemon));
                }
                else
                {
                    trainers[trainerName].Pokemons.Add(newPokemon);
                }
            }

            string command = String.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                CheckElement(trainers, command);
            }

            StringBuilder result = new StringBuilder();

            foreach (var trainer in trainers.OrderByDescending(x => x.Value.NumberOfBadges))
            {
                result.AppendLine($"{trainer.Value.Name} {trainer.Value.NumberOfBadges} {trainer.Value.Pokemons.Count}");
            }

            Console.WriteLine(result.ToString());
        }

        private static void CheckElement(Dictionary<string, Trainer> trainers, string element)
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Value.Pokemons.Any(e => e.Element == element))
                {
                    trainer.Value.NumberOfBadges++;
                }
                else
                {
                    if (trainer.Value.Pokemons.Count > 0)
                    {
                        foreach (var pokemon in trainer.Value.Pokemons)
                        {
                            pokemon.Health -= 10;

                            if (pokemon.Health <= 0)
                            {
                                trainer.Value.Pokemons.Remove(pokemon);

                                if (trainer.Value.Pokemons.Count == 0)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
