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
        ConsoleColor defaultForeColor = Console.ForegroundColor;

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
            Opponent = new Player("Smith");
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
            Opponent.SelectPokemon(Randomize: true);
            Opponent.PrintCurrentPokemonStatus();
            User.SelectPokemon(Randomize: false);
        }

        public void Battle()
        {
            bool userTurn = true;

            while(Opponent.CurrentPokemon.CurrentHP > 0 && User.CurrentPokemon.CurrentHP > 0)
            {
                PrintSimulatorStatus();
                Console.WriteLine();
                if(userTurn)
                {
                    Console.WriteLine($"{User.CurrentPokemon.Name} Attacks...");
                    User.CurrentPokemon.UseMove(Opponent.CurrentPokemon);
                    Console.Write($"{User.Name}'s ");
                }
                else
                {
                    Console.WriteLine($"{Opponent.CurrentPokemon.Name} Attacks...");
                    Opponent.CurrentPokemon.UseMove(User.CurrentPokemon);
                    Console.Write($"{Opponent.Name}'s ");
                }

                Thread.Sleep(500);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("HIT!!!");
                Console.ForegroundColor = defaultForeColor;
                Thread.Sleep(1000);
                Console.Clear();

                userTurn = !userTurn;
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{results.LosingPlayer.Name}'s {results.LosingPlayer.CurrentPokemon.Name} has fainted");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{results.WinningPlayer.Name}'s {results.WinningPlayer.CurrentPokemon.Name} has won!");
            Console.ForegroundColor = defaultForeColor;
        }
    }
}
