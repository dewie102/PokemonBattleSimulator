﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattleSimulator
{
    public enum PokemonState { AVAILABLE, FAINTED }


    // Not sure how to abstract this class properly
    // or how to not create a new file/ class for each pokemon
    public class Pokemon
    {
        public string Name { get; private set; }
        public int StartingHP { get; private set; }
        public int CurrentHP { get; private set; }
        public int BaseAttack { get; private set; }
        public int BaseDefense { get; private set; }
        public PokemonState CurrentState { get; private set; } = PokemonState.AVAILABLE;

        public Pokemon()
        {
            Name = string.Empty;
            StartingHP = 0;
            CurrentHP = 0;
            BaseAttack = 0;
            BaseDefense = 0;
            CurrentState = PokemonState.FAINTED;
        }

        public Pokemon(string name, int hp, int attack, int defense)
        {
            Name = name;
            StartingHP = hp;
            CurrentHP = StartingHP;
            BaseAttack = attack;
            BaseDefense = defense;
        }

        // Is this correct? Should I be using the other pokemon to call a private Method on itself?
        public bool UseMove(Pokemon other)
        {
            return other.Attack(BaseAttack);
        }

        private bool Attack(int attack)
        {
            bool hit = false;

            if(Program.Rand.Next(10) <= 8) // 10% chance to not attack or 90% chance to attack
            {
                int attackAmount = CalculateAttack(attack);
                CurrentHP -= attackAmount;
                hit = attackAmount > 0 ? true : false;
            }

            if(CurrentHP <= 0)
            {
                CurrentState = PokemonState.FAINTED;
                CurrentHP = 0;
            }

            return hit;
        }

        public int CalculateAttack(int attack)
        {
            return BaseDefense > attack ? 0 : attack - BaseDefense;
        }

        public void ChangeAvailabilityStateTo(PokemonState state)
        {
            CurrentState = state;
        }

        public void PrintStatus()
        {
            Console.WriteLine($"\tName: {Name}");
            Console.WriteLine($"\tHP: {CurrentHP}");
            Console.WriteLine($"\tAttack: {BaseAttack}");
            Console.WriteLine($"\tDefense: {BaseDefense}");
            Console.WriteLine($"\tState: {CurrentState}");
        }

        public string GetStatusInline()
        {
            return $"Name: {Name}, HP: {CurrentHP}, Attack: {BaseAttack}, Defense: {BaseDefense}";
        }
    }
}
