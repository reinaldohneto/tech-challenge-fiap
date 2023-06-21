using Azure;
using Fiap.TechChallenge.Api.Application.Dtos;
using Fiap.TechChallenge.Api.Application.Services.Memes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace Fiap.TechChallenge.WebPage.Services
{
    public class ApiFunctionalitiesService : IMemeService
    {
        [HttpPost]
        public async Task<MemeDto> CreateMeme(MemeInputDto dto)
        {
            
            JsonContent content = JsonContent.Create(dto);
            var url = "https://localhost:7129/v1/meme/";
            
            HttpClient client = new HttpClient();
            var result = await client.PostAsync(url, content);

            return new MemeDto { };
        }

        public async Task<ICollection<MemeDto>> GetAllMemes()
        {
            HttpClient client = new HttpClient();
            var apiCall = await client.GetAsync("https://localhost:7129/v1/meme").Result.Content.ReadAsStringAsync();

            var desserializedResult = JsonConvert.DeserializeObject<List<MemeDto>>(apiCall);
            return desserializedResult;
        }        
    }
}
