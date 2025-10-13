using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nastasiu_iana_lab2.Data;
using nastasiu_iana_lab2.Models;

namespace nastasiu_iana_lab2.Pages.books
{
    public class IndexModel : PageModel
    {
        private readonly nastasiu_iana_lab2Context _context;

        public IndexModel(nastasiu_iana_lab2Context context)
        {
            _context = context;
        }

        public IList<book> book { get; set; } = new List<book>();

        public async Task OnGetAsync()
        {
            book = await _context.book
                .Include(b => b.Publisher)
                .Include(b => b.Author) 
                .ToListAsync();
        }
    }
}
