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
    }
}
