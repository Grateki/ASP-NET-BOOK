using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleDeLivros.Models
{
    public class AuthorModel
    {
        public int AuthorId { get; set; }
        [Required]
        public string AuthorName { get; set; }
        [Required]
        public string AuthorLastName { get; set; }
        public string Email { get; set; }
        public DateTime Birth { get; set; }
        public virtual ICollection<BookModel> Books { get; set; }
    }
}
