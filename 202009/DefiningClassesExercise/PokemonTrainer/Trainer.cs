using System.Collections.Generic;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer(Pokemon pokemon)
        {
            Pokemons.Add(pokemon);
        }
        public Trainer(string name, Pokemon pokemon)
        {
            Name = name;
            Pokemons = new List<Pokemon>();
            Pokemons.Add(pokemon);
        }

        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemons { get; set; }
    }
}
