using Fiap.TechChallenge.Api.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Fiap.TechChallenge.WebPage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public ICollection<MemeDto> MemeCatalog { get; set; } = new List<MemeDto>();

        public void OnGet()
        {
            HttpClient client = new HttpClient();
            var result = client.GetAsync("https://localhost:7129/v1/meme").Result.Content.ReadAsStringAsync().Result;

            MemeCatalog = JsonConvert.DeserializeObject<ICollection<MemeDto>>(result);
        }
    }
}
