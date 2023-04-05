namespace ControleDeLivros.Models
{
    public class BookModel
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public string? Isbn { get; set; }
       public int? Year { get; set; }


      public int? AuthorId { get; set; }
      public virtual AuthorModel? Author { get; set; }
       
    }
}
