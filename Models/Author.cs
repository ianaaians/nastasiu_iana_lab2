using System.ComponentModel.DataAnnotations;

namespace nastasiu_iana_lab2.Models
{
    public class Author
    {
        public int ID { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Author")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
