
namespace Library_DEPI.Services
{
    public class CheckoutServices : ICheckoutServices
    {
        private readonly AppDBContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CheckoutServices(AppDBContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IEnumerable<Checkout>> GetAllCheckoutsAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");
            bool isSuperAdmin = await _userManager.IsInRoleAsync(user, "Super Admin");

            return await _context.Checkouts
                .Include(c => c.Book)
                .Include(c => c.User)
                .Where(c => c.UserId == userId || isAdmin || isSuperAdmin)
                .ToListAsync();
        }


        public async Task<Checkout> GetCheckoutByIdAsync(int id)
        {
            return await _context.Checkouts
                .Include(c => c.Book)
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task CreateCheckoutAsync(CheckoutViewModel model)
        {
            var book = await _context.Books.FindAsync(model.SelectedBookId);
            var user = await _userManager.FindByIdAsync(model.SelectedUserId);
            if (book != null && user != null)
            {
                var checkout = new Checkout
                {
                    CheckoutDate = model.CheckoutDate,
                    DueDate = model.CheckoutDate.AddDays(14),
                    BookID = book.Id,
                    BookName = book.Title,
                    UserId = user.Id,
                    UserEmail = user.Email,
                    Book = book,
                    User = user
                };

                book.AvailabilityStatus = false;
                _context.Update(book);
                _context.Add(checkout);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateCheckoutAsync(int id, CheckoutViewModel model)
        {
            var checkout = await GetCheckoutByIdAsync(id);
            if (checkout != null)
            {
                var oldBook = await _context.Books.FindAsync(checkout.BookID);
                var newBook = await _context.Books.FindAsync(model.SelectedBookId);
                var user = await _userManager.FindByIdAsync(model.SelectedUserId);

                if (newBook != null && user != null)
                {
                    checkout.CheckoutDate = model.CheckoutDate;
                    checkout.DueDate = model.CheckoutDate.AddDays(14);
                    checkout.BookID = newBook.Id;
                    checkout.BookName = newBook.Title;
                    checkout.UserId = user.Id;
                    checkout.UserEmail = user.Email;
                    checkout.Book = newBook;
                    checkout.User = user;

                    if (oldBook != null)
                    {
                        oldBook.AvailabilityStatus = true;
                        _context.Update(oldBook);
                    }

                    newBook.AvailabilityStatus = false;
                    _context.Update(newBook);
                    _context.Update(checkout);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task DeleteCheckoutAsync(int id)
        {
            var checkout = await _context.Checkouts.FindAsync(id);
            if (checkout != null)
            {
                var book = await _context.Books.FindAsync(checkout.BookID);
                if (book != null)
                {
                    book.AvailabilityStatus = true;
                    _context.Update(book);
                }

                _context.Checkouts.Remove(checkout);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Checkout> GetActiveCheckoutForBook(int bookId)
        {
            return await _context.Checkouts
                .Where(c => c.BookID == bookId && c.DueDate != null)
                .FirstOrDefaultAsync();
        }
    }
}
