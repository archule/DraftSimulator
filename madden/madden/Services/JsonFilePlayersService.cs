using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using madden.Models;
using Microsoft.AspNetCore.Hosting;

namespace madden.Services
{
    public class JsonFilePlayersService
    {
        public JsonFilePlayersService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "Data", "players.json");

        public IEnumerable<Player> GetPlayers()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);
            return JsonSerializer.Deserialize<Player[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }

    }
}