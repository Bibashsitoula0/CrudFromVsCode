namespace dotnet.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }
         public DateTime DateTime { get; set; }

        public List<Book> Books { get; set; }

        public List<Teacher> Teachers { get; set; }
    }
}
