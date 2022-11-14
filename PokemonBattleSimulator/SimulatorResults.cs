using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattleSimulator
{
    public struct SimulatorResults
    {
        public Player WinningPlayer { get; set; }
        public Player LosingPlayer { get; set; }

        public SimulatorResults(Player winner, Player loser)
        {
            WinningPlayer = winner;
            LosingPlayer = loser;
        }
    }
}
