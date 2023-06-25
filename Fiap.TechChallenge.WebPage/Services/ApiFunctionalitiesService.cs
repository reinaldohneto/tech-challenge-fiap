using Fiap.TechChallenge.Api.Application.Dtos;
using Fiap.TechChallenge.Api.Application.Services.Memes;
using Newtonsoft.Json;

namespace Fiap.TechChallenge.WebPage.Services

{
    public class ApiFunctionalitiesService : IMemeService
    {
        private readonly IConfiguration _configuration;
        private readonly string? _baseUrl;
        private readonly HttpClient client = new HttpClient();

        public ApiFunctionalitiesService(IConfiguration configuration)
        {
            _configuration = configuration;
            _baseUrl = _configuration.GetValue<string>("ApiUrl");
        }

        public async Task<ICollection<MemeDto>> GetAllMemes()
        {
            var apiCall = await (await client.GetAsync(_baseUrl)).Content.ReadAsStringAsync();

            var desserializedResult = JsonConvert.DeserializeObject<List<MemeDto>>(apiCall);
            return desserializedResult;
        }

        public async Task<MemeDto> GetMemeById(string id)
        {
            var apiCall = await (await client.GetAsync(_baseUrl + "/" + id)).Content.ReadAsStringAsync();

            var desserializedResult = JsonConvert.DeserializeObject<MemeDto>(apiCall);
            return desserializedResult;
        }

        public async Task<MemeDto> CreateMeme(MemeInputDto dto)
        {
            JsonContent content = JsonContent.Create(dto);
            var result = await client.PostAsync(_baseUrl, content);

            return null;
        }

        public async Task UpdateMemeById(MemeInputUpdateDto dto)
        {
            JsonContent content = JsonContent.Create(dto);
            var result = await client.PutAsync(_baseUrl, content);
        }
        public async Task<bool> DeleteMemeById(string id)
        {
            var apiCall = await (await client.DeleteAsync(_baseUrl + "/" + id)).Content.ReadAsStringAsync();
            return bool.Parse(apiCall);
        }
    }
}
