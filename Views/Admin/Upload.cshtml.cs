using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Smart_E.Data;

namespace Smart_E.Areas.Identity.Pages
{
    public class UploadModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public UploadModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public int? myID { get; set; }
        [BindProperty]
        public IFormFile file { get; set; }
        [BindProperty]
        public int? ID { get; set; }
        public void OnGet(int? id)
        {
            myID = id;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(file != null)
            {
                if(file.Length > 0 && file.Length < 300000)
                {
                    var myDoc = _context.Uploads.FirstOrDefault(x => x.Id == ID);
                    using(var target = new MemoryStream())
                    {
                        file.CopyTo(target);
                        myDoc.Attachment = target.ToArray();    
                    }
                    _context.Uploads.Update(myDoc);
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToPage("./Index");
        }
    }
}
