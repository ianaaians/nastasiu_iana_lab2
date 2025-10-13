using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nastasiu_iana_lab2.Data;
using nastasiu_iana_lab2.Models;

namespace nastasiu_iana_lab2.Pages.books
{
    public class DetailsModel : PageModel
    {
        private readonly nastasiu_iana_lab2.Data.nastasiu_iana_lab2Context _context;

        public DetailsModel(nastasiu_iana_lab2.Data.nastasiu_iana_lab2Context context)
        {
            _context = context;
        }

        public book book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.book.FirstOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                book = book;
            }
            return Page();
        }
    }
}
