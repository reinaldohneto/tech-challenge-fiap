using Fiap.TechChallenge.Api.Application.Dtos;
using Fiap.TechChallenge.Api.Application.Services.Memes;
using Fiap.TechChallenge.WebPage.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Fiap.TechChallenge.WebPage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMemeService _memeFunctionalitiesService;

        public IndexModel(ILogger<IndexModel> logger, IMemeService memeFunctionalitiesService)
        {
            _memeFunctionalitiesService = memeFunctionalitiesService;
            _logger = logger;
        }

        public ICollection<MemeDto> MemeCatalog { get; set; } = new List<MemeDto>();

        public void OnGet()
        {
            MemeCatalog.Clear();
            MemeCatalog = _memeFunctionalitiesService.GetAllMemes().Result;
        }
    }
}
