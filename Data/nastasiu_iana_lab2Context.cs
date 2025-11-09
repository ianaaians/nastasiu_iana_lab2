using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using nastasiu_iana_lab2.Models;

namespace nastasiu_iana_lab2.Data
{
    public class nastasiu_iana_lab2Context : DbContext
    {
        public nastasiu_iana_lab2Context (DbContextOptions<nastasiu_iana_lab2Context> options)
            : base(options)
        {
        }

        public DbSet<nastasiu_iana_lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<nastasiu_iana_lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<nastasiu_iana_lab2.Models.Author> Author { get; set; } = default!;
        public DbSet<nastasiu_iana_lab2.Models.Category> Category { get; set; } = default!;
        public DbSet<nastasiu_iana_lab2.Models.Member> Member { get; set; } = default!;
        public DbSet<nastasiu_iana_lab2.Models.Borrowing> Borrowing { get; set; } = default!;
    }
}
