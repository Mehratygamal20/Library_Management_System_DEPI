
namespace Library_DEPI.ViewModels
{
    public class BookViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool AvailabilityStatus { get; set; }
        public DateTime PublishedDate { get; set; }
        public string? BookImagePath { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public int AuthorID { get; set; }
        //public Author Author { get; set; }
        public int GenreID { get; set; }
        //public Genre Genre { get; set; }



       
    }
}
