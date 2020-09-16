using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Domain
{
    public class Book
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String ISBN { get; set; }
        public String Ano { get; set; }

        [JsonIgnore]
        public virtual Author Author { get; set; }
    }
}
