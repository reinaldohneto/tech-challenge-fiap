using Fiap.TechChallenge.Api.Application.Dtos;
using Fiap.TechChallenge.Api.Application.Services.Memes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace Fiap.TechChallenge.WebPage.Pages
{
    public class MemeDetailsModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMemeService _memeFunctionalitiesService;
        private readonly IMemoryCache _memoryCache;
        private string _id;

        [BindProperty]
        public MemeDto SelectedMeme { get; set; } = default!;

        public MemeDetailsModel(ILogger<IndexModel> logger, IMemeService memeFunctionalitiesService, IMemoryCache memoryCache)
        {
            _memeFunctionalitiesService = memeFunctionalitiesService;
            _logger = logger;

            _memoryCache = memoryCache;
        }

        public async Task OnGet(string id)
        {
            _id = id;
            SelectedMeme = await _memeFunctionalitiesService.GetMemeById(_id);

            _memoryCache.Set("Meme", SelectedMeme);
        }

        public IActionResult OnPostReturn()
        {
            return Redirect("./Index");
        }

        public async Task<IActionResult> OnPostAsync(string name, string description)
        {
            var memeCache = _memoryCache.Get("Meme") as MemeDto;
            MemeInputUpdateDto meme = new MemeInputUpdateDto()
            {
                Id = memeCache.Id,
                Name = name,
                Link = memeCache.Link,
                Description = description,
                IsVideo = memeCache.IsVideo
            };

            await _memeFunctionalitiesService.UpdateMemeById(meme);
            return Redirect("./Index");
        }

        public async Task<IActionResult> OnPostDelete()
        {
            var meme = _memoryCache.Get("Meme") as MemeDto;

            await _memeFunctionalitiesService.DeleteMemeById(meme.Id.ToString());
            return Redirect("./Index");
        }
    }
}