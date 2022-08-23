using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Smart_E.Data;
using Smart_E.Models;

namespace Smart_E.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransactionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public FileResult Export()
        {
            DataTable dt = new DataTable("Donations");
            dt.Columns.AddRange(new DataColumn[6]
            {
                new DataColumn("AccountNumber"),
                new DataColumn("BeneficiaryName"),
                new DataColumn("BankName"),
                new DataColumn("CVV"),
                new DataColumn("Amount"),
                new DataColumn("Date")
            });

            var transaction = from t in _context.Transactions.ToList() select t;
            foreach (var t in transaction)
            {
                dt.Rows.Add(t.AccountNumber, t.BeneficiaryName, t.BankName, t.CVV, t.Amount,t.Date);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream ms = new MemoryStream())
                {
                    wb.SaveAs(ms);
                    return File(ms.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml", "Transactions.xlsx");
                }
            }
        }

        //search transaction
        [HttpGet]
        public async Task<IActionResult> Index(string search)
        {
            ViewData["Details"] = search;

            var query = from t in _context.Transactions select t;
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(s => s.BeneficiaryName.Contains(search));
            }
            return View(await query.AsNoTracking().ToListAsync());
        }

        // GET: Transaction
        public async Task<IActionResult> Index()
        {
              return _context.Transactions != null ? 
                          View(await _context.Transactions.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Transactions'  is null.");
        }

        // GET: Transaction/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return NotFound();
            }

            var transactionsModel = await _context.Transactions
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transactionsModel == null)
            {
                return NotFound();
            }

            return View(transactionsModel);
        }

        // GET: Transaction/AddOrEdit
        // GET: Transaction/AddOrEdit/5
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            if(id == 0)
            return View(new TransactionsModel());
            else
            {
                var transactionsModel = await _context.Transactions.FindAsync(id);
                if (transactionsModel == null)
                {
                    return NotFound();
                }
                return View(transactionsModel);
            }
        }

        // POST: Transaction/AddOrEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("TransactionId,AccountNumber,BeneficiaryName,BankName,CVV,Amount,Date")] TransactionsModel transactionsModel)
        {

            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    transactionsModel.Date = DateTime.Now;
                    _context.Add(transactionsModel);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(transactionsModel);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TransactionsModelExists(transactionsModel.TransactionId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }          
                return Json(new {isValid=true,html=Helper.RenderRazorViewToString(this,"_ViewAll",_context.Transactions.ToList())});
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", transactionsModel)});
        }


        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Transactions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Transactions'  is null.");
            }
            var transactionsModel = await _context.Transactions.FindAsync(id);
            if (transactionsModel != null)
            {
                _context.Transactions.Remove(transactionsModel);
            }
            
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Transactions.ToList()) });
        }

        private bool TransactionsModelExists(int id)
        {
          return (_context.Transactions?.Any(e => e.TransactionId == id)).GetValueOrDefault();
        }
    }
}
