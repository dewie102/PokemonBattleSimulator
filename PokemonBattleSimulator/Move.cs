using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokemonBattleSimulator
{
    public enum MoveType { ELECTRIC, NORMAL };

    public class Move : ISelectable
    {
        public string Name { get; private set; }
        public string Type { get; private set;  }
        public int Accuracy { get; private set; }
        public int Power { get; private set; }
        public int PP { get; private set; }

        [JsonConstructor]
        public Move(string name, string type, int accuracy, int power, int pp)
        {
            Name = name;
            Type = type;
            Accuracy = accuracy;
            Power = power;
            PP = pp;
        }

        public string GetDisplayString()
        {
            return Name;
        }
    }
}
