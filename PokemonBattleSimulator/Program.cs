using System.Threading;

namespace PokemonBattleSimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Pokemon> pokemon = new List<Pokemon>();

            Pikachu pika = new Pikachu();
            Charmander charm = new Charmander();
            Squirtle squirt = new Squirtle();

            pokemon.Add(pika);
            pokemon.Add(charm);
            pokemon.Add(squirt);

            Player player = new Player("Zack");
            Player opponent = new Player("Jack");

            Random rnd = new Random();

            int index = rnd.Next(pokemon.Count);
            opponent.SetPokemon(pokemon[index]);

            pokemon.RemoveAt(index);

            index = rnd.Next(pokemon.Count);
            player.SetPokemon(pokemon[index]);

            Console.WriteLine($"Player: {player.Name} has {player.CurrentPokemon.Name} as their pokemon with {player.CurrentPokemon.HP} HP");
            Console.WriteLine($"Player: {opponent.Name} has {opponent.CurrentPokemon.Name} as their pokemon with {opponent.CurrentPokemon.HP} HP");
            Console.WriteLine();

            Console.WriteLine("Press enter to start battle");
            Console.ReadLine();

            while(opponent.CurrentPokemon.HP > 0)
            {
                Console.WriteLine($"{player.CurrentPokemon.Name} Attacks...");
                player.CurrentPokemon.UseAttack(opponent.CurrentPokemon);
                Console.WriteLine("HIT!!!");
                Console.WriteLine($"{opponent.CurrentPokemon.Name} now has {opponent.CurrentPokemon.HP} health");
                Console.WriteLine();
                Thread.Sleep(500);
            }

            Console.WriteLine($"{opponent.CurrentPokemon.Name} has fainted");
            Console.WriteLine($"{player.CurrentPokemon.Name} has won!");
        }
    }
}