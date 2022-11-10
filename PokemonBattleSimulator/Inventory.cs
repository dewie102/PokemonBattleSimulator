﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattleSimulator
{
    public class Inventory
    {
        // Maybe put a cap on the total number of pokemon available
        public HashSet<Pokemon> AllPokemon { get; private set; }

        public Inventory()
        {
            AllPokemon = new HashSet<Pokemon>();
        }

        public void AddPokemonToInventory(Pokemon pokemon)
        {
            AllPokemon.Add(pokemon);
        }

        public void PrintInventory()
        {
            foreach(Pokemon pokemon in AllPokemon)
            {
                Console.WriteLine(pokemon.Name);            
            }
        }

        public List<Pokemon> GetAvailablePokemon()
        {
            List<Pokemon> availablePokemon = new List<Pokemon>();
            foreach(Pokemon pokemon in AllPokemon)
            {
                if(pokemon.CurrentState == PokemonState.AVAILABLE)
                    availablePokemon.Add(pokemon);
            }

            return availablePokemon;
        }
    }
}
