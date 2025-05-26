namespace Labb_3___API.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        public ICollection<PersonInterest> PersonInterests { get; set; }
        public ICollection<Link> Links { get; set; }
    }
}
