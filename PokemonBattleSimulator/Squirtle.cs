using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattleSimulator
{
    public class Squirtle : Pokemon
    {
        public Squirtle() : base("Squirtle", 100, 10, 5)
        {
        }

        public Squirtle(string name, int hp) : base(name, hp, 10, 5)
        {
        }
    }
}
