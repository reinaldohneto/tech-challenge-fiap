using Fiap.TechChallenge.Api.Application.Dtos;
using Fiap.TechChallenge.Api.Application.Services.Memes;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Fiap.TechChallenge.WebPage.Services
{
    public class ApiFunctionalitiesService : IMemeService
    {
        private readonly IConfiguration _configuration;
        private readonly string? _baseUrl; 

        public ApiFunctionalitiesService(IConfiguration configuration)
        {
            _configuration = configuration;
            _baseUrl = _configuration.GetValue<string>("ApiUrl");
        }

        [HttpPost]
        public async Task<MemeDto> CreateMeme(MemeInputDto dto)
        {
            
            JsonContent content = JsonContent.Create(dto);
            
            HttpClient client = new HttpClient();
            var result = await client.PostAsync(_baseUrl, content);

            return new MemeDto { };
        }

        public async Task<ICollection<MemeDto>> GetAllMemes()
        {
            HttpClient client = new HttpClient();
            var apiCall = await (await client.GetAsync(_baseUrl)).Content.ReadAsStringAsync();

            var desserializedResult = JsonConvert.DeserializeObject<List<MemeDto>>(apiCall);
            return desserializedResult;
        }        
    }
}
