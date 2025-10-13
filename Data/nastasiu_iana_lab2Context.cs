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

        public DbSet<nastasiu_iana_lab2.Models.book> book { get; set; } = default!;
        public DbSet<nastasiu_iana_lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<nastasiu_iana_lab2.Models.Author> Author { get; set; } = default!;
    }
}
