using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using nastasiu_iana_lab2.Data;
using nastasiu_iana_lab2.Models;

namespace nastasiu_iana_lab2.Pages.Borrowings
{
    public class DetailsModel : PageModel
    {
        private readonly nastasiu_iana_lab2.Data.nastasiu_iana_lab2Context _context;

        public DetailsModel(nastasiu_iana_lab2.Data.nastasiu_iana_lab2Context context)
        {
            _context = context;
        }

        public Borrowing Borrowing { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Borrowing = await _context.Borrowing
      .Include(b => b.Member)
      .Include(b => b.Book)
      .AsNoTracking()
      .FirstOrDefaultAsync(m => m.ID == id);


            if (Borrowing == null)
            {
                return NotFound();
            }

            return Page();
        }

    }
}