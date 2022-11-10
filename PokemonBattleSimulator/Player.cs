using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattleSimulator
{
    public class Player
    {
        public string Name { get; private set; }
        //public Pokemon? CurrentPokemon { get; private set; }
        public Inventory PlayerInventory { get; private set; }

        public Player(string name)
        {
            Name = name;
            PlayerInventory = new Inventory();
            //CurrentPokemon = null;
        }

        public Player(string name, Pokemon pokemon)
        {
            Name = name;
            PlayerInventory = new Inventory();
            //CurrentPokemon = pokemon;
        }
    }
}
