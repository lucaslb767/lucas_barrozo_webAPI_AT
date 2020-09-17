using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Author
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public DateTime DataDeAniversario { get; set; }
        public virtual IList<Book> Books {get;set;}

    }

    public class AuthorResponse
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Email { get; set; }
        [Required]
        public DateTime DataDeAniversario { get; set; }
        public virtual IList<Book> Books { get; set; }

    }
}
