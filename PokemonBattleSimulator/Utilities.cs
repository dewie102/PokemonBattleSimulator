using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PokemonBattleSimulator
{
    public static class Utilities
    {
        public static Dictionary<string, T> LoadJsonToDictionary<T>(string filename)
        {
            string jsonString = File.ReadAllText(filename);

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;
            options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

            return JsonSerializer.Deserialize<Dictionary<string, T>>(jsonString, options)!;
        }

        public static ISelectable SelectChoiceFrom(List<ISelectable> Choices, bool Randomize = true)
        {
            if(Randomize)
            {
                int index = Program.Rand.Next(Choices.Count);
                return Choices[index];
            }
            else
            {
                DisplayChoiceMenu(Choices);
                int choice = GetMenuChoice(Choices.Count);
                return Choices[choice];
            }
        }

        private static void DisplayChoiceMenu(List<ISelectable> Choices)
        {
            for(int index = 0; index < Choices.Count; index++)
                Console.WriteLine($"{index + 1}. {Choices[index].GetDisplayString()}");
        }

        private static int GetMenuChoice(int numberOfOptions)
        {
            string? rawChoice;
            bool validChoice;
            int choice;

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
    }
}
