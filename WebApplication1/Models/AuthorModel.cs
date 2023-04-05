using System.Runtime.Serialization;

namespace ControleDeLivros.Models
{
    public class AuthorModel
    {
        public int AuthorId { get; set; }
        public string? AuthorName { get; set; }
        public string? AuthorLastName { get; set; }
        public string? Email { get; set; }
       public int? Birth { get; set; }


    }
}
