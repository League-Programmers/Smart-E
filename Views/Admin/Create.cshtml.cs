using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Smart_E.Data;
using Smart_E.Models;

namespace Smart_E.Areas.Identity.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel (ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }
        [BindProperty]
        public Upload Uploads { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Uploads.Add(Uploads);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
