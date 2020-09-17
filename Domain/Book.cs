using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;

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

    public class BookResponse
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String ISBN { get; set; }
        [Required]
        public string Ano { get; set; }

        public virtual Author Author { get; set; }
    }
}
