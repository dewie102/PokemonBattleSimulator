using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBattleSimulator
{
    public class Player
    {
        public string Name { get; private set; }
        public Pokemon CurrentPokemon { get; private set; } = new();
        public Inventory PlayerInventory { get; private set; }

        public Player()
        {
            Name = string.Empty;
            PlayerInventory = new();
        }

        public Player(string name)
        {
            Name = name;
            PlayerInventory = new();
            //CurrentPokemon = null;
        }

        public Player(string name, Pokemon pokemon)
        {
            Name = name;
            PlayerInventory = new();
            //CurrentPokemon = pokemon;
        }

        public void SelectPokemon(bool Randomize = true)
        {
            List<Pokemon> availablePokemon = PlayerInventory.GetAvailablePokemon();
            if(Randomize)
            {
                int index = Program.Rand.Next(availablePokemon.Count);
                CurrentPokemon = availablePokemon[index];
            }
            else
            {
                DisplayPokemonChoiceMenu(availablePokemon);
                int choice = GetMenuChoice(availablePokemon.Count);
                CurrentPokemon = availablePokemon[choice];
            }
        }

        private void DisplayPokemonChoiceMenu(List<Pokemon> availablePokemon)
        {
            for(int i = 0; i < availablePokemon.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availablePokemon[i].GetStatusInline()}");
            }
        }

        private int GetMenuChoice(int numberOfOptions)
        {
            string? rawChoice = null;
            bool validChoice = false;
            int choice = -1;

            do
            {
                rawChoice = Console.ReadLine();
                if(!int.TryParse(rawChoice, out choice))
                {
                    Console.WriteLine("Please enter a valid number for your choice");
                    validChoice = false;
                    continue;
                }

                if(choice > numberOfOptions)
                {
                    Console.WriteLine("Please enter a valid number for your choice");
                    validChoice = false;
                    continue;
                }

                validChoice = true;

            } while(rawChoice == null || !validChoice);

            return choice - 1;
        }

        public void PrintCurrentPokemonStatus()
        {
            Console.WriteLine($"Player: {Name}");
            CurrentPokemon.PrintStatus();
            Console.WriteLine();
        }
    }
}
