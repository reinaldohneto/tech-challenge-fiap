using Fiap.TechChallenge.Api.Application.Dtos;
using Fiap.TechChallenge.Api.Application.Services.Memes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Fiap.TechChallenge.WebPage.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;
        private readonly IMemeService _memeFunctionalitiesService;       

        public CreateModel(ILogger<CreateModel> logger, IMemeService memeFunctionalitiesService)
        {            
            _memeFunctionalitiesService = memeFunctionalitiesService;
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MemeInputDto Meme { get; set; } = default!;
                
        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid || _memeFunctionalitiesService.Meme == null || Meme == null)
            //{
            //    return Page();
            //}
            var result = _memeFunctionalitiesService.CreateMeme(Meme);
            //_context.Meme.Add(Meme);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
