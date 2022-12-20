﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PokemonBattleSimulator
{
    public enum PokemonState { AVAILABLE, FAINTED }


    // Not sure how to abstract this class properly
    // or how to not create a new file/ class for each pokemon
    //[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public class Pokemon
    {
        public string Name { get; private set; }
        public int BaseHP { get; private set; }
        public int CurrentHP { get; private set; }
        public int BaseAttack { get; private set; }
        public int BaseDefense { get; private set; }
        public PokemonState CurrentState { get; private set; } = PokemonState.AVAILABLE;
        public List<string> Moves { get; private set; }


        [JsonConstructor]
        public Pokemon(string name, int baseHP, int baseAttack, int baseDefense, List<string> moves)
        {
            Name = name;
            BaseHP = baseHP;
            CurrentHP = baseHP;
            BaseAttack = baseAttack;
            BaseDefense = baseDefense;
            Moves = moves;
        }

        public Pokemon(Pokemon pokemon)
        {
            Name = pokemon.Name;
            BaseHP = pokemon.BaseHP;
            CurrentHP = BaseHP;
            BaseAttack = pokemon.BaseAttack;
            BaseDefense = pokemon.BaseDefense;
            Moves = pokemon.Moves;
        }

        // Is this correct? Should I be using the other pokemon to call a private Method on itself?
        public bool UseMove(Pokemon other)
        {
            return other.ReceiveAttack(BaseAttack);
        }

        public bool ReceiveAttack(int attack)
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
