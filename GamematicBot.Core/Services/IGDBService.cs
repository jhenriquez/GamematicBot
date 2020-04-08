using System;
using System.Net.Http;
using System.Threading.Tasks;
using GamematicBot.Core.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace GamematicBot.Core.Services {
    public class IGDBService : IIGDBService
    {
        private readonly HttpClient http;
        public IGDBService(HttpClient client, IOptions<GamematicBotSettings> settings)
        {
            http = client;
            client.BaseAddress = new Uri(settings.Value.IGDBBaseAddress);
            client.DefaultRequestHeaders.Add("user-key", settings.Value.IGDBToken);
        }

        public async Task<Game[]> SearchGamesByText(string term)
        {
            var content = new StringContent($"search \"{term}\"; fields *;");
            var response = await http.PostAsync("/games", content);
            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Game[]>(responseContent);
        } 
    }
}