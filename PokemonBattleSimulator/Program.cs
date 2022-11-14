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

            Console.WriteLine();
            battle.PrintSimulatorStatus();
            Console.WriteLine();

            Console.WriteLine("Press enter to start battle");
            _ = Console.ReadLine();

            Console.Clear();

            battle.Battle();

            battle.PrintSimulatorStatus();
            battle.GetResults();
        }
    }
}
