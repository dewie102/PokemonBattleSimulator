using System.Collections.Immutable;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace PokemonBattleSimulator
{
    public class Simulator
    {
        readonly ConsoleColor defaultForeColor = Console.ForegroundColor;

        public Player User { get; private set; } = new();
        public Player Opponent { get; private set; } = new();
        private SimulatorResults results;

        private Dictionary<string, Pokemon> allPokemon = new();
        private Dictionary<string, Move> allMoves = new();

        public void Initialize()
        {
            allPokemon = Utilities.LoadJsonToDictionary<Pokemon>("Data/PokemonBaseStats.json");
            allMoves = Utilities.LoadJsonToDictionary<Move>("Data/Moves.json");

            InitPlayers();
        }

        private void InitPlayers()
        {
            User = new Player("Zack");
            InitPlayerInventory(User.PlayerInventory, new List<Pokemon>() {
                new(allPokemon["pikachu"]),
                new(allPokemon["charmander"]),
                new(allPokemon["squirtle"])
            });

            Opponent = new Player("Smith");
            InitPlayerInventory(Opponent.PlayerInventory, new List<Pokemon>() {
                new(allPokemon["pikachu"]),
                new(allPokemon["charmander"]),
                new(allPokemon["squirtle"])
            });
        }

        static private void InitPlayerInventory(Inventory playerInventory, List<Pokemon> pokemon)
        {
            foreach(Pokemon p in pokemon)
            {
                playerInventory.AddPokemonToInventory(p);
            }
        }

        public void SelectPokemon()
        {
            
            Pokemon selectedPokemon = (Pokemon)Utilities.SelectChoiceFrom(new List<ISelectable>(Opponent.PlayerInventory.GetAvailablePokemon()),
                                                                            Randomize: true);
            Opponent.SetPokemon(selectedPokemon);
            Opponent.PrintCurrentPokemonStatus();


            User.SelectPokemon(Randomize: false);
        }

        private void UserTurn()
        {
            SelectMoveToUse();
            Console.WriteLine($"{User.Name}'s {User.CurrentPokemon.Name} Attacks...");
            if(User.CurrentPokemon.UseMove(Opponent.CurrentPokemon))
                PrintMoveHitMessage();
            else
                PrintMoveMissMessage();
        }

        private void SelectMoveToUse()
        {
            Move selectedMove = allMoves[User.SelectMove(Randomize: false)];
        }

        private void EnemyTurn()
        {
            Console.WriteLine($"{Opponent.Name}'s {Opponent.CurrentPokemon.Name} Attacks...");
            if(Opponent.CurrentPokemon.UseMove(User.CurrentPokemon))
                PrintMoveHitMessage();
            else
                PrintMoveMissMessage();
        }

        public void Battle()
        {
            while(!Opponent.CurrentPokemon.IsPokemonFainted() && !User.CurrentPokemon.IsPokemonFainted())
            {
                PrintSimulatorStatus();

                UserTurn();
                EnemyTurn();

                Thread.Sleep(1500);
                Console.Clear();
            }

            // This was the solution if Results was a property
            //Results = new SimulatorResults { WinningPlayer = User, LosingPlayer = Opponent };

            results.WinningPlayer = User.CurrentPokemon.IsPokemonFainted() ? Opponent : User;
            results.LosingPlayer = results.WinningPlayer == User ? Opponent : User;
        }

        public void PrintSimulatorStatus()
        {
            User.PrintCurrentPokemonStatus();
            Opponent.PrintCurrentPokemonStatus();
            Console.WriteLine();
        }

        public void PrintResults()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{results.LosingPlayer.Name}'s {results.LosingPlayer.CurrentPokemon.Name} has fainted");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{results.WinningPlayer.Name}'s {results.WinningPlayer.CurrentPokemon.Name} has won!");
            Console.ForegroundColor = defaultForeColor;
        }

        private void PrintMoveHitMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("HIT!!!");
            Console.ForegroundColor = defaultForeColor;
        }

        private void PrintMoveMissMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MISSED!!!");
            Console.ForegroundColor = defaultForeColor;
        }
    }
}
