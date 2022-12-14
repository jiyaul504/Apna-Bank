using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Apna_Bank.Models;
using Microsoft.AspNetCore.Authorization;

namespace Apna_Bank.Controllers
{
    [Authorize]
    public class TransactionsController : Controller
    {
        private readonly TransactionDBContext _context;

        public TransactionsController(TransactionDBContext context)
        {
            _context = context;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
              return View(await _context.Transactioncs.ToListAsync());
        }

        // GET: Transactions/Details/5
       

        // GET: Transactions/Create
        public async Task <IActionResult> AddOrEdit(int id=0)
        {
            if(id == 0)
            {
                return View(new TransactionModel());
            }
            var transactions = await _context.Transactioncs.FindAsync(id);
            if (transactions == null)
            {
                return NotFound();
            }
            return View(transactions);

        }
        // POST: Transactions/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("TransactionId,AccountNumber,BeneficiaryName,BankName,IfscCode,Amount,Date")] TransactionModel transactions)
        {
           
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    transactions.Date=DateTime.Now;
                    _context.Add(transactions);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        _context.Update(transactions);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TransactionsExists(transactions.TransactionId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                
                }
                return Json(new {isValid=true, Html= Helper.RenderRazorViewToString(this,"_ViewAll",_context.Transactioncs.ToList())} );
            }
            return Json(new { isValid = false, Html = Helper.RenderRazorViewToString(this,"AddOrEdit",transactions)});
        }

     

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Transactioncs == null)
            {
                return Problem("Entity set 'TransactionDBContext.Transactioncs'  is null.");
            }
            var transactions = await _context.Transactioncs.FindAsync(id);
            if (transactions != null)
            {
                _context.Transactioncs.Remove(transactions);
            }
            
            await _context.SaveChangesAsync();
            return Json(new { Html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Transactioncs.ToList()) });
        }

        private bool TransactionsExists(int id)
        {
          return _context.Transactioncs.Any(e => e.TransactionId == id);
        }
    }
}
