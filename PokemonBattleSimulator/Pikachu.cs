using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattleSimulator
{
    public class Pikachu : Pokemon
    {
        public Pikachu() : base("Pikachu", 100, 15)
        {
        }

        public Pikachu(string name, int hp) : base(name, hp, 15)
        {
        }
    }
}
