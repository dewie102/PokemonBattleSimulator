using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattleSimulator
{
    public class Pokemon
    {
        public string Name { get; private set; }
        public int HP { get; private set; }
        public int Attack { get; private set; }

        public Pokemon(string name, int hp, int attack)
        {
            Name = name;
            HP = hp;
            Attack = attack;
        }

        public void UseAttack(Pokemon other)
        {
            other.HP -= Attack;
        }
    }
}
