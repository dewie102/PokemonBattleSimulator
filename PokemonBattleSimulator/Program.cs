using System.Threading;

namespace PokemonBattleSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pikachu pikachu1 = new Pikachu();
            Pikachu pikachu2 = new Pikachu();
            Charmander charmander1 = new Charmander();
            Charmander charmander2 = new Charmander();
            Squirtle squirtle1 = new Squirtle();
            Squirtle squirtle2 = new Squirtle();

            Player player = new Player("Zack");
            Player opponent = new Player("Jack");

            player.PlayerInventory.AddPokemonToInventory(pikachu1);
            player.PlayerInventory.AddPokemonToInventory(charmander1);
            player.PlayerInventory.AddPokemonToInventory(squirtle1);

            opponent.PlayerInventory.AddPokemonToInventory(pikachu2);
            opponent.PlayerInventory.AddPokemonToInventory(charmander2);
            opponent.PlayerInventory.AddPokemonToInventory(squirtle2);

            Random rnd = new Random();

            int index = rnd.Next(opponent.PlayerInventory.GetAvailablePokemon().Count);
            Pokemon opponentCurrentPokemon = opponent.PlayerInventory.GetAvailablePokemon()[index];

            index = rnd.Next(player.PlayerInventory.GetAvailablePokemon().Count); ;
            Pokemon playerCurrentPokemon = player.PlayerInventory.GetAvailablePokemon()[index];

            Console.WriteLine($"Player: {player.Name} has {playerCurrentPokemon.Name} as their pokemon with {playerCurrentPokemon.HP} HP");
            Console.WriteLine($"Player: {opponent.Name} has {opponentCurrentPokemon.Name} as their pokemon with {opponentCurrentPokemon.HP} HP");
            Console.WriteLine();

            Console.WriteLine("Press enter to start battle");
            _ = Console.ReadLine();

            while(opponentCurrentPokemon.HP > 0)
            {
                Console.WriteLine($"{playerCurrentPokemon.Name} Attacks...");
                playerCurrentPokemon.UseAttack(opponentCurrentPokemon);
                Console.WriteLine("HIT!!!");
                Console.WriteLine($"{opponentCurrentPokemon.Name} now has {opponentCurrentPokemon.HP} health");
                Console.WriteLine();
                Thread.Sleep(1000);
            }

            Console.WriteLine($"{opponent.Name}'s {opponentCurrentPokemon.Name} has fainted");
            Console.WriteLine($"{player.Name}'s {playerCurrentPokemon.Name} has won!");
        }
    }
}