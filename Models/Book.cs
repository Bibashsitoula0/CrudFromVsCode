using System.ComponentModel.DataAnnotations;

namespace dotnet.Models
{
    public class Book
    {
        public int BookId { get; set; }
     
        public string BookName { get; set; }

        public int Code { get; set; }
    }
}
