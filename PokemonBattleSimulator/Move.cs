using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattleSimulator
{
    public enum MoveType { ELECTRIC, NORMAL };

    public class Move
    {
        string Name { get; set; }
        /*MoveType Type { get; set;  }
        int Accuracy { get; set; }
        int Power { get; set; }
        int PP { get; set; }*/
    }
}
