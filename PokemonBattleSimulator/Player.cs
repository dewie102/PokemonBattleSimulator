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
        public Pokemon CurrentPokemon { get; private set; } = new();
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
            //CurrentPokemon = pokemon;
        }

        public void SelectPokemon(bool Randomize = true)
        {
            List<Pokemon> availablePokemon = PlayerInventory.GetAvailablePokemon();
            if(Randomize)
            {
                int index = Program.Rand.Next(availablePokemon.Count);
                CurrentPokemon = availablePokemon[index];
            }
            else
            {
                Console.WriteLine("Choosing your own Pokemon is not an available feature");
                SelectPokemon(true);
            }
        }

        public void PrintCurrentPokemonStatus()
        {
            Console.WriteLine($"Player: {Name}");
            CurrentPokemon.PrintStatus();
            Console.WriteLine();
        }
    }
}
