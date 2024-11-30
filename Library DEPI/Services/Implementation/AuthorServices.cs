namespace Library_DEPI.Services.Implementation
{
    public class AuthorServices : IAuthorServices
    {
        private readonly AppDBContext _context;
        public AuthorServices(AppDBContext context) { 

            _context = context;
        }
        public bool create(Author author)
        {
            _context.Authors.Add(author);
            if(_context.SaveChanges()>0)
                return true;
            return false;
        }

        public bool Delete(int id)
        {
            if(!IsExist(id)) return false;
            _context.Authors.Remove(GetOne(id));
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Authors.AsNoTracking().ToList();
        }

        public Author GetOne(int id)
        {
            if (!IsExist(id)) return null;
            return _context.Authors.FirstOrDefault(a=>a.Id==id);
        }
        public bool ExistsByName(string name, int? excludeId = null)
        {
            return _context.Authors.Any(a => a.Name == name && a.Id != excludeId);
        }

        public bool IsExist(int id)
        {
            if(_context.Authors.Any(a=>a.Id==id))
                return true;
            return false;
                
        }

        public IEnumerable<SelectListItem> SelectedItems()
        {
           return _context.Authors.AsNoTracking().Select(a=>new SelectListItem
           {
               Value=a.Id.ToString(),
               Text=a.Name,
           }).ToList();
        }

        public bool Update(int id, Author author)
        {
            if(!IsExist(id)) return false;
            var data =_context.Authors.Find(id);

            if(data==null) return false;
            data.Name = author.Name;
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }
    }
}
