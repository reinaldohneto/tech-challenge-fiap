using Fiap.TechChallenge.Api.Application.Dtos;
using Fiap.TechChallenge.Api.Application.Services.Memes;
using Fiap.TechChallenge.WebPage.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;

namespace Fiap.TechChallenge.WebPage.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMemeService _memeFunctionalitiesService;

        private ICollection<MemeDto> _fullMemeList = new List<MemeDto>();
        [BindProperty]
        public ICollection<MemeDto> MemeCatalog { get; set; } = new List<MemeDto>();

        private string _filterName = string.Empty;
        [BindProperty]
        public string Filter
        {
            get => _filterName;
            set
            {
                _filterName = value;
                RefreshFullMemeList();

                if (!string.IsNullOrEmpty(value))
                {
                    var desiredMeme = (from meme in _fullMemeList
                                       where meme.Name.ToLower().Contains(value.ToLower())
                                       select meme).ToList();

                    MemeCatalog = desiredMeme;
                }
                else
                    MemeCatalog = _fullMemeList;
            }
        }

        public IndexModel(ILogger<IndexModel> logger, IMemeService memeFunctionalitiesService)
        {
            _memeFunctionalitiesService = memeFunctionalitiesService;
            _logger = logger;
        }

        private void RefreshFullMemeList()
        {
            _fullMemeList = _memeFunctionalitiesService.GetAllMemes().Result;
        }

        public void OnGet()
        {
            MemeCatalog.Clear();
            Filter = string.Empty;
        }

        public IActionResult OnPostInputValueChanged(string memeName)
        {
            Filter = memeName;
            return Page();
        }
    }
}