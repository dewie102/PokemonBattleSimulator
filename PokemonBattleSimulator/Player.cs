using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattleSimulator
{
    public class Player
    {
        public string Name { get; private set; }
        public Pokemon CurrentPokemon { get; private set; }
        public Inventory PlayerInventory { get; private set; }

        public Player()
        {
            Name = string.Empty;
            PlayerInventory = new();
        }

        public Player(string name)
        {
            Name = name;
            PlayerInventory = new();
            //CurrentPokemon = null;
        }

        public Player(string name, Pokemon pokemon)
        {
            Name = name;
            PlayerInventory = new();
            CurrentPokemon = pokemon;
        }

        public void SetPokemon(Pokemon pokemon)
        {
            if(pokemon != null && PlayerInventory.IsPokemonAvailable(pokemon))
            {
                CurrentPokemon = pokemon;
            }
            else
                Console.WriteLine("Error, pokemon not avilable or is null");
        }

        public void PrintCurrentPokemonStatus()
        {
            Console.WriteLine($"Player: {Name}");
            CurrentPokemon.PrintStatus();
            Console.WriteLine();
        }
    }
}
