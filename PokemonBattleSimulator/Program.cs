using System.Threading;

namespace PokemonBattleSimulator
{
    internal class Program
    {
        static public Random Rand { get; private set; } = new();
        static void Main(string[] args)
        {
            Simulator battle = new Simulator();

            battle.Initialize();
            battle.SelectPokemon();

            battle.User.PrintCurrentPokemonStatus();
            battle.Opponent.PrintCurrentPokemonStatus();
            Console.WriteLine();

            Console.WriteLine("Press enter to start battle");
            _ = Console.ReadLine();

            battle.Battle();

            battle.GetResults();
        }
    }
}