using System;
using System.Collections.Generic;
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
}
