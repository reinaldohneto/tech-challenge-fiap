using Azure;
using Fiap.TechChallenge.Api.Application.Dtos;
using Fiap.TechChallenge.Api.Application.Services.Memes;
using Fiap.TechChallenge.Api.Configurations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Options;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;

namespace Fiap.TechChallenge.WebPage.Services
{
    public class ApiFunctionalitiesService : IMemeService
    {
        private readonly IConfiguration _configuration;
        
        public ApiFunctionalitiesService(IConfiguration configuration)
        {
            _configuration = configuration;            
        }              
         
        public async Task<MemeDto> CreateMeme(MemeInputDto dto)
        {   
            JsonContent content = JsonContent.Create(dto);
            var url = _configuration.GetValue<string>("UrlConfig:ApiBase");
            
            HttpClient client = new HttpClient();
            var result = await client.PostAsync(url, content);

            return null;
        }

        public async Task<ICollection<MemeDto>> GetAllMemes()
        {
            var url = _configuration.GetValue<string>("UrlConfig:ApiBase");
            HttpClient client = new HttpClient();
            var apiCall = await client.GetAsync(url).Result.Content.ReadAsStringAsync();

            var desserializedResult = JsonConvert.DeserializeObject<List<MemeDto>>(apiCall);
            return desserializedResult;
        }        
    }
}
