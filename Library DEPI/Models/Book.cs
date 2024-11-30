namespace Library_DEPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool AvailabilityStatus { get; set; }
        public DateTime PublishedDate { get; set; }
        public string BookImage { get; set; }
        public int AuthorID { get; set; }
        public Author Author { get; set; }
        public int GenreID { get; set; }
        public Genre Genre { get; set; }

    }
}
