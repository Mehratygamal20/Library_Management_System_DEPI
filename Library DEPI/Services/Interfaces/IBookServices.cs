namespace Library_DEPI.Services.Interfaces
{
    public interface IBookServices
    {
        IQueryable<Book> GetAll();
        IEnumerable<SelectListItem> SelectedItems();
        Book GetOne(int id);
       
        bool BookExists(string title, int authorId, int genreId, int? excludeId = null);
        
        bool create(Book book);
        bool Update(int id, Book book);
        bool Delete(int id);
        bool IsExist(int id);
    }
}
