using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proj4.data;

using proj4.Models;

namespace proj4.Controllers
{
    public class BorrowTransactionsController : Controller
    {
        private readonly LibraryContext _context ;

        public BorrowTransactionsController(LibraryContext  context)
        {
            _context = context;
        }

        // GET: BorrowTransactions
        public async Task<IActionResult> Index()
        {
            var borrowTransactions = _context.BorrowTransactions
                .Include(b => b.Book)
                .Include(b => b.Member);

            return View(await borrowTransactions.ToListAsync());
        }

        // GET: BorrowTransactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BorrowTransactions == null)
            {
                return NotFound();
            }

            var borrowTransaction = await _context.BorrowTransactions
                .Include(b => b.Book)
                .Include(b => b.Member)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (borrowTransaction == null)
            {
                return NotFound();
            }

            return View(borrowTransaction);
        }

        // GET: BorrowTransactions/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Title");
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Name");
            return View();
        }

        // POST: BorrowTransactions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookId,MemberId,BorrowDate,DaysLate,Penalty")] BorrowTransaction borrowTransaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(borrowTransaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Title", borrowTransaction.BookId);
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Name", borrowTransaction.MemberId);
            return View(borrowTransaction);
        }

        // GET: BorrowTransactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BorrowTransactions == null)
            {
                return NotFound();
            }

            var borrowTransaction = await _context.BorrowTransactions.FindAsync(id);
            if (borrowTransaction == null)
            {
                return NotFound();
            }

            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Title", borrowTransaction.BookId);
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Name", borrowTransaction.MemberId);

            return View(borrowTransaction);
        }

        // POST: BorrowTransactions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookId,MemberId,BorrowDate,DaysLate,Penalty")] BorrowTransaction borrowTransaction)
        {
            if (id != borrowTransaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(borrowTransaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowTransactionExists(borrowTransaction.Id))
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

            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Title", borrowTransaction.BookId);
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Name", borrowTransaction.MemberId);

            return View(borrowTransaction);
        }

        // GET: BorrowTransactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BorrowTransactions == null)
            {
                return NotFound();
            }

            var borrowTransaction = await _context.BorrowTransactions
                .Include(b => b.Book)
                .Include(b => b.Member)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (borrowTransaction == null)
            {
                return NotFound();
            }

            return View(borrowTransaction);
        }

        // POST: BorrowTransactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BorrowTransactions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BorrowTransactions' is null.");
            }

            var borrowTransaction = await _context.BorrowTransactions.FindAsync(id);
            if (borrowTransaction != null)
            {
                _context.BorrowTransactions.Remove(borrowTransaction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BorrowTransactionExists(int id)
        {
            return (_context.BorrowTransactions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
