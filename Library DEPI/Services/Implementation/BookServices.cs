namespace Library_DEPI.Services.Implementation
{
    public class BookServices : IBookServices
    {
        private readonly AppDBContext _context;

        public BookServices(AppDBContext context)
        {
            _context = context;
        }

        public bool create(Book book)
        {
            _context.Books.Add(book);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool Delete(int id)
        {
            if (!IsExist(id)) return false;
            _context.Books.Remove(GetOne(id));
            return _context.SaveChanges() > 0;
        }

        public IQueryable<Book> GetAll()
        {
            return _context.Books.Include(b => b.Author).Include(b => b.Genre);
        }



        public Book GetOne(int id)
        {
            if (!IsExist(id)) return null;
            return _context.Books.Include(b => b.Author)  
                .Include(b => b.Genre).FirstOrDefault(b => b.Id == id);
        }

        public bool BookExists(string title, int authorId, int genreId, int? excludeId = null)
        {
            return _context.Books.Any(b =>
                b.Title == title &&
                b.AuthorID == authorId &&
                b.GenreID == genreId &&
                b.Id != excludeId);
        }


        public bool IsExist(int id)
        {
            return _context.Books.Any(b => b.Id == id);
        }

        public IEnumerable<SelectListItem> SelectedItems()
        {
            return _context.Books.AsNoTracking().Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Title, // Assuming the Book class has a Title property
            }).ToList();
        }

        public bool Update(int id, Book book)
        {
            if (!IsExist(id)) return false;
            var existingBook = _context.Books.Find(id);

            if (existingBook == null) return false;

            existingBook.Title = book.Title; // Assuming the Book class has a Title property
            existingBook.Description = book.Description;
            existingBook.PublishedDate = book.PublishedDate;
            existingBook.AvailabilityStatus = book.AvailabilityStatus;
            existingBook.BookImage = book.BookImage;
            existingBook.AuthorID = book.AuthorID;
            existingBook.GenreID = book.GenreID;

            return _context.SaveChanges() > 0;
        }


      
        
    }
}
