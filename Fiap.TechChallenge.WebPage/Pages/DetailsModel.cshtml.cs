using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Fiap.TechChallenge.Api.Application.Dtos;
using Fiap.TechChallenge.Api.Application.Services.Memes;
using Fiap.TechChallenge.WebPage.Services;

namespace Fiap.TechChallenge.WebPage.Pages
{
    public class DetailsModel : PageModel
    {
        public string Id { get; private set; }
        
        private readonly ILogger<IndexModel> _logger;
        private readonly IMemeService _memeFunctionalitiesService;

        public DetailsModel(ILogger<IndexModel> logger, IMemeService memeFunctionalitiesService)
        {
            _memeFunctionalitiesService = memeFunctionalitiesService;
            _logger = logger;
        }

public ICollection<MemeDto> MemeCatalog { get; set; } = new List<MemeDto>();

public IActionResult OnGet(string id)
{
    Id = id;
    MemeDto memeDto = _memeFunctionalitiesService.GetMemeById(id).Result;

    MemeCatalog = new List<MemeDto> { memeDto };

    return Page();
}


    }
}

