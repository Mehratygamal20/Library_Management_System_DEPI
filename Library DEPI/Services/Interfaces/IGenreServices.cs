

namespace Library_DEPI.Services.Interfaces
{
    public interface IGenreServices
    {
        IEnumerable<Genre> GetAll();
        IEnumerable<SelectListItem> SelectedItems();
        Genre GetOne(int id);
        bool ExistsByName(string name, int? excludeId = null);
        bool create(Genre genre);
        bool Update(int id, Genre genre);
        bool Delete(int id);
        bool IsExist(int id);
    }
}
