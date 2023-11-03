using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeLivros.Models
{
    public class BookModel
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public string? Isbn { get; set; }
        public DateTime? Year { get; set; }
        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }
        public virtual AuthorModel Author { get; set; }

    }
}

