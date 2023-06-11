using Fiap.TechChallenge.Api.Application.Dtos;
using Fiap.TechChallenge.Api.Application.Services.Memes;
using Newtonsoft.Json;

namespace Fiap.TechChallenge.WebPage.Services
{
    public class ApiFunctionalitiesService : IMemeService
    {
        public Task<MemeDto> CreateMeme(MemeInputDto dto)
        {
            throw new NotImplementedException();
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
