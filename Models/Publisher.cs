using System.ComponentModel.DataAnnotations;

namespace nastasiu_iana_lab2.Models
{
    public class Publisher
    {
        public int ID { get; set; }
        [Display(Name ="Name")]
        public string PublisherName { get; set; }
        public ICollection<book>? books { get; set; }
    }
}
