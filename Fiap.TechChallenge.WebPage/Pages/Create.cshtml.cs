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
            if(!Meme.IsVideo)
                if (Meme.Upload.Length is not 0 && Meme.Upload.Headers.ContentType == "image/jpeg" ||
                    Meme.Upload.Headers.ContentType == "image/png")
                {
                    using var memoryStream = new MemoryStream();
                    await Meme.Upload.CopyToAsync(memoryStream);

                    var base64Image = Convert.ToBase64String(memoryStream.ToArray());

                    Meme.Base64ImageOrVideoLink = base64Image;
                }

            Meme.Upload = null;

            //if (!ModelState.IsValid || _memeFunctionalitiesService.Meme == null || Meme == null)
            //{
            //    return Page();
            //}
            var result = await _memeFunctionalitiesService.CreateMeme(Meme);
            //_context.Meme.Add(Meme);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
