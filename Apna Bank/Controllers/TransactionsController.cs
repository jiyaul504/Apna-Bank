using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Apna_Bank.Models;

namespace Apna_Bank.Controllers
{
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
                return View();
            }
            var transactions = await _context.Transactioncs.FindAsync(id);
            if (transactions == null)
            {
                return NotFound();
            }
            return View(transactions);

        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionId,AccountNumber,BeneficiaryName,BankName,IfscCode,Amount")] Transactions transactions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transactions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transactions);
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Transactioncs == null)
            {
                return NotFound();
            }

            var transactions = await _context.Transactioncs.FindAsync(id);
            if (transactions == null)
            {
                return NotFound();
            }
            return View(transactions);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionId,AccountNumber,BeneficiaryName,BankName,IfscCode,Amount")] Transactions transactions)
        {
            if (id != transactions.TransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
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
                return RedirectToAction(nameof(Index));
            }
            return View(transactions);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Transactioncs == null)
            {
                return NotFound();
            }

            var transactions = await _context.Transactioncs
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transactions == null)
            {
                return NotFound();
            }

            return View(transactions);
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
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionsExists(int id)
        {
          return _context.Transactioncs.Any(e => e.TransactionId == id);
        }
    }
}
