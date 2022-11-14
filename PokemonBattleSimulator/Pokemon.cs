using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattleSimulator
{
    public enum PokemonState { AVAILABLE, FAINTED }

    public class Pokemon
    {
        public string Name { get; private set; }
        public int StartingHP { get; private set; }
        public int CurrentHP { get; private set; }
        public int Attack { get; private set; }
        public PokemonState CurrentState { get; private set; } = PokemonState.AVAILABLE;

        public Pokemon()
        {
            Name = string.Empty;
            StartingHP = 0;
            CurrentHP = 0;
            Attack = 0;
            CurrentState = PokemonState.FAINTED;
        }

        public Pokemon(string name, int hp, int attack)
        {
            Name = name;
            StartingHP = hp;
            CurrentHP = StartingHP;
            Attack = attack;
        }

        public void UseAttack(Pokemon other)
        {
            other.CurrentHP -= Attack;
        }

        public void ChangeAvailabilityStateTo(PokemonState state)
        {
            CurrentState = state;
        }

        public void PrintStatus()
        {
            Console.WriteLine($"\tName: {Name}");
            Console.WriteLine($"\tHP: {CurrentHP}");
            Console.WriteLine($"\tAttack: {Attack}");
            Console.WriteLine($"\tState: {CurrentState}");
        }

        public string GetStatusInline()
        {
            return $"Name: {Name}, HP: {CurrentHP}, Attack: {Attack}";
        }
    }
}
