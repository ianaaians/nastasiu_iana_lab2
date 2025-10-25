using System.Collections.Generic;
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
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            BookD=new BookData();
            BookD.Books = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .Include(b => b.BookCategories)
                    .ThenInclude(bc => bc.Category)
                .AsNoTracking()
                .OrderBy(b=> b.Title)
                .ToListAsync();

            Book = (IList<Book>)BookD.Books;

            if (id != null)
                {
                BookID = id.Value;
                Book Book = BookD.Books
                    .Where(b => b.ID == id.Value).Single();
                BookD.Categories = Book.BookCategories.Select(bc => bc.Category);
            }
        }
    }
}
