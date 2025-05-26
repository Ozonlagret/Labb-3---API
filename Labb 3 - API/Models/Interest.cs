namespace Labb_3___API.Models
{
    public class Interest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<PersonInterest> PersonInterests { get; set; }
        public ICollection<Link> Links { get; set; }
    }
}
