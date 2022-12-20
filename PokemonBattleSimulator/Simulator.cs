using System.Collections.Immutable;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace PokemonBattleSimulator
{
    public class Simulator
    {
        ConsoleColor defaultForeColor = Console.ForegroundColor;

        public Player User { get; private set; } = new();
        public Player Opponent { get; private set; } = new();
        private SimulatorResults results;

        private Dictionary<string, Pokemon> allPokemon = new();

        public void Initialize()
        {
            LoadAllPokemon("PokemonBaseStats.json");

            Pokemon pikachu1 = new(allPokemon["pikachu"]);
            Pokemon pikachu2 = new(allPokemon["pikachu"]);
            Pokemon charmander1 = new(allPokemon["charmander"]);
            Pokemon charmander2 = new(allPokemon["charmander"]);
            Pokemon squirtle1 = new(allPokemon["squirtle"]);
            Pokemon squirtle2 = new(allPokemon["squirtle"]);

            InitPlayers();
            InitPlayerInventory(User.PlayerInventory, new List<Pokemon>() { pikachu1, charmander1, squirtle1 });
            InitPlayerInventory(Opponent.PlayerInventory, new List<Pokemon>() { pikachu2, charmander2, squirtle2 });
        }

        private void LoadAllPokemon(string filename)
        {
            string jsonString = File.ReadAllText(filename);
            
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;
            options.PropertyNamingPolicy= JsonNamingPolicy.CamelCase;

            allPokemon = JsonSerializer.Deserialize<Dictionary<string, Pokemon>>(jsonString, options)!;
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
                bool didMoveSucceed = false;
                PrintSimulatorStatus();
                Console.WriteLine();
                if(userTurn)
                {
                    Console.WriteLine($"{User.Name}'s {User.CurrentPokemon.Name} Attacks...");
                    didMoveSucceed = User.CurrentPokemon.UseMove(Opponent.CurrentPokemon);
                }
                else
                {
                    Console.WriteLine($"{Opponent.Name}'s {Opponent.CurrentPokemon.Name} Attacks...");
                    didMoveSucceed = Opponent.CurrentPokemon.UseMove(User.CurrentPokemon);
                }

                Thread.Sleep(500);

                if(didMoveSucceed)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("HIT!!!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("MISSED!!!");
                }

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
