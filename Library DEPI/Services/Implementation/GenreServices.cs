
namespace Library_DEPI.Services.Implementation
{
    public class GenreServices : IGenreServices
    {

        private readonly AppDBContext _context;
        public GenreServices(AppDBContext context)
        {

            _context = context;
        }
        public bool create(Genre genre)
        {
            _context.Genres.Add(genre);
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool Delete(int id)
        {
            if (!IsExist(id)) return false;
            _context.Genres.Remove(GetOne(id));
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        // for unique name genre
        public bool ExistsByName(string name, int? excludeId = null)
        {
            return _context.Genres.Any(a => a.Name == name && a.Id != excludeId);
        }

        public IEnumerable<Genre> GetAll()
        {
            return _context.Genres.AsNoTracking().ToList();
        }

        public Genre GetOne(int id)
        {
            if (!IsExist(id)) return null;
            return _context.Genres.FirstOrDefault(a => a.Id == id);
        }

        public bool IsExist(int id)
        {
            if (_context.Genres.Any(a => a.Id == id))
                return true;
            return false;
        }

        public IEnumerable<SelectListItem> SelectedItems()
        {
             return _context.Genres.AsNoTracking().Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name,
            }).ToList();
        }

        public bool Update(int id, Genre genre)
        {

            if (!IsExist(id)) return false;
            var data = _context.Genres.Find(id);

            if (data == null) return false;
            data.Name = genre.Name;
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }
    }
}
