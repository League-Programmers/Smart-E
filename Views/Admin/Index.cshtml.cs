using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Smart_E.Data;
using Smart_E.Models;

namespace Smart_E.Areas.Identity.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IList<Upload> Uploads { get; set; }
        public void OnGet()
        {
            Uploads = _context.Uploads.ToList();
        }

        //public async Task<IActionResult> OnPostDownloadAsync(int? id)
        //{
        //    var myDoc = await _context.Uploads.FirstOrDefault(x => x.Id == id); 
        //    if(myDoc == null)
        //    {
        //        return NotFound();
        //    }
        //    if(myDoc.Attachment == null)
        //    {
        //        return Page();
        //    }
        //    else
        //    {
        //        byte[] byteArr = myDoc.Attachment;
        //        string mimeType = "application/pdf";
        //        return new FileContentResult(byteArr, mimeType)
        //        {
        //            FileDownloadName = myDoc.FileName
        //        };
        //    }
        //}
        //public async Task<IActionResult> OnPostDeleteAsync(int? id)
        //{
        //    var myDoc = await _context.Uploads.FirstOrDefault(x => x.Id == id);
        //    if (myDoc == null)
        //    {
        //        return NotFound();
        //    }
        //    if (myDoc.Attachment == null)
        //    {
        //        return Page();
        //    }
        //    else
        //    {
        //        myDoc.Attachment = null;
        //        _context.Update(myDoc);
        //        await _context.SaveChangesAsync();
        //    }
        //    Uploads = _context.Uploads.ToList(); 
        //    return Page();
        //}
    }
}
