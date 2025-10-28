using System.Collections.Generic;
using nastasiu_iana_lab2.Models;

namespace nastasiu_iana_lab2.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
