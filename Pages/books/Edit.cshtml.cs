using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using nastasiu_iana_lab2.Data;
using nastasiu_iana_lab2.Models;

namespace nastasiu_iana_lab2.Pages.books
{
    public class EditModel : PageModel
    {
        private readonly nastasiu_iana_lab2Context _context;

        public EditModel(nastasiu_iana_lab2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public book book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            book = await _context.book
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (book == null) return NotFound();

            ViewData["PublisherID"] = new SelectList(
                _context.Publisher,
                "ID",
                "PublisherName",
                book.PublisherID
            );

            ViewData["AuthorID"] = new SelectList(
                _context.Author
                        .Select(a => new { a.ID, FullName = a.FirstName + " " + a.LastName }),
                "ID",
                "FullName",
                book.AuthorID
            );

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["PublisherID"] = new SelectList(
                    _context.Publisher,
                    "ID",
                    "PublisherName",
                    book.PublisherID
                );

                ViewData["AuthorID"] = new SelectList(
                    _context.Author
                            .Select(a => new { a.ID, FullName = a.FirstName + " " + a.LastName }),
                    "ID",
                    "FullName",
                    book.AuthorID
                );

                return Page();
            }

            _context.Attach(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!bookExists(book.ID))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToPage("./Index");
        }

        private bool bookExists(int id)
        {
            return _context.book.Any(e => e.ID == id);
        }
    }
}
