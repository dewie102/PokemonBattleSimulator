using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattleSimulator
{
    public class Charmander : Pokemon
    {
        public Charmander() : base("Charmander", 100, 10)
        {
        }

        public Charmander(string name, int hp) : base(name, hp, 10)
        {
        }
    }
}
