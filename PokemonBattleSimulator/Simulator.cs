using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattleSimulator
{
    public class Simulator
    {
        Pikachu pikachu1 = new();
        Pikachu pikachu2 = new();
        Charmander charmander1 = new();
        Charmander charmander2 = new();
        Squirtle squirtle1 = new();
        Squirtle squirtle2 = new();

        public Player User { get; private set; } = new();
        public Player Opponent { get; private set; } = new();
        private SimulatorResults results;

        public void Initialize()
        {
            InitPlayers();
            InitPlayerInventory(User.PlayerInventory, new List<Pokemon>() { pikachu1, charmander1, squirtle1 });
            InitPlayerInventory(Opponent.PlayerInventory, new List<Pokemon>() { pikachu2, charmander2, squirtle2 });
        }

        private void InitPlayers()
        {
            User = new Player("Zack");
            Opponent = new Player("Jack");
        }

        private void InitPlayerInventory(Inventory playerInventory, List<Pokemon> pokemon)
        {
            foreach(Pokemon p in pokemon)
            {
                playerInventory.AddPokemonToInventory(p);
            }
        }

        public void SelectPokemon()
        {
            User.SelectPokemon(true);
            Opponent.SelectPokemon(true);
        }

        public void Battle()
        {
            while(Opponent.CurrentPokemon.HP > 0)
            {
                Console.WriteLine($"{User.CurrentPokemon.Name} Attacks...");
                User.CurrentPokemon.UseAttack(Opponent.CurrentPokemon);
                Console.WriteLine("HIT!!!");
                PrintSimulatorStatus();
                Console.WriteLine();
                Thread.Sleep(1000);
            }

            // This was the solution if Results was a property
            //Results = new SimulatorResults { WinningPlayer = User, LosingPlayer = Opponent };
            results.WinningPlayer = User;
            results.LosingPlayer = Opponent;
        }

        public void PrintSimulatorStatus()
        {
            User.PrintCurrentPokemonStatus();
            Opponent.PrintCurrentPokemonStatus();
        }

        public void GetResults()
        {
            Console.WriteLine($"{results.LosingPlayer.Name}'s {results.LosingPlayer.CurrentPokemon.Name} has fainted");
            Console.WriteLine($"{results.WinningPlayer.Name}'s {results.WinningPlayer.CurrentPokemon.Name} has fainted");
        }
    }
}
