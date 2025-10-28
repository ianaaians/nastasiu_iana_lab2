//using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nastasiu_iana_lab2.Data;
using nastasiu_iana_lab2.Models;

namespace nastasiu_iana_lab2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly nastasiu_iana_lab2Context _context;

        public IndexModel(nastasiu_iana_lab2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; } = new List<Book>();
        public BookData BookD { get; set; }
        public int BookID { get; set; }
        public int CategoryID { get; set; }

        public string TitleSort { get; set; }
        public string AuthorSort { get; set; }
        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {
            BookD = new BookData();

            TitleSort = sortOrder == "title_asc" ? "title_desc" : "title_asc";
            AuthorSort = sortOrder == "author_asc" ? "author_desc" : "author_asc";

            CurrentFilter = searchString;

            BookD.Books = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .Include(b => b.BookCategories).ThenInclude(bc => bc.Category)
                .AsNoTracking()
                .ToListAsync();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                var s = searchString.Trim();
                BookD.Books = BookD.Books.Where(b =>
                    (b.Title?.Contains(s, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (b.Author?.FirstName?.Contains(s, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (b.Author?.LastName?.Contains(s, StringComparison.OrdinalIgnoreCase) ?? false) ||
                    (b.Author?.FullName?.Contains(s, StringComparison.OrdinalIgnoreCase) ?? false));
            }

            if (id != null)
            {
                BookID = id.Value;
                var bsel = BookD.Books.FirstOrDefault(b => b.ID == id.Value);
                if (bsel != null)
                    BookD.Categories = bsel.BookCategories.Select(bc => bc.Category);
            }

            if (!string.IsNullOrEmpty(sortOrder))
            {
                BookD.Books = sortOrder switch
                {
                    "title_asc" => BookD.Books.OrderBy(s => s.Title),
                    "title_desc" => BookD.Books.OrderByDescending(s => s.Title),
                    "author_asc" => BookD.Books.OrderBy(s => s.Author?.FullName),
                    "author_desc" => BookD.Books.OrderByDescending(s => s.Author?.FullName),
                    _ => BookD.Books
                };
            }

            Book = BookD.Books.ToList();
        }
    }
}
