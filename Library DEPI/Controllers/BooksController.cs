using Library_DEPI.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Library_DEPI.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookServices _bookservices;
        private readonly IAuthorServices _authorservices;
        private readonly IGenreServices _genreservices;
        private readonly ICheckoutServices _checkoutservices;
        private readonly UserManager<IdentityUser> _usermanager;

        public BooksController(IBookServices bookservices, IAuthorServices authorservices, IGenreServices genreservices, ICheckoutServices checkoutServices, UserManager<IdentityUser> usermanager)
        {
            _bookservices = bookservices;
            _authorservices = authorservices;
            _genreservices = genreservices;
            _checkoutservices = checkoutServices;
            _usermanager = usermanager;
        }

        // GET: Books
        public async Task<IActionResult> Index(string searchString, string searchBy)
        {
            var books = _bookservices.GetAll(); 

            if (!string.IsNullOrEmpty(searchString))
            {
                switch (searchBy)
                {
                    case "Title":
                        books = books.Where(b => b.Title.Contains(searchString));
                        break;
                    case "Author":
                        books = books.Where(b => b.Author.Name.Contains(searchString));
                        break;
                    case "Genre":
                        books = books.Where(b => b.Genre.Name.Contains(searchString));
                        break;
                }
            }

            var result = await books.ToListAsync();

            return View(result);
        }


        // GET: Books/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookservices.GetOne(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [Authorize(Roles = $"{MyRoles.SuperAdminRole},{MyRoles.AdminRole}")]

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewBag.Authors = _authorservices.GetAll();
            ViewBag.Genres= _genreservices.GetAll();
            return View();
        }


        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(BookViewModel bookVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string fileName = string.Empty;
        //        if (bookVM.Image != null)
        //        {
        //            string myFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
        //            if (!Directory.Exists(myFilePath))
        //                Directory.CreateDirectory(myFilePath);
        //            fileName = Guid.NewGuid().ToString() + Path.GetExtension(bookVM.Image.FileName);
        //            string fullPath = Path.Combine(myFilePath, fileName);
        //            bookVM.Image.CopyTo(new FileStream(fullPath, FileMode.Create));
        //            bookVM.BookImagePath = fileName;
        //        }
        //        else
        //        {
        //            bookVM.BookImagePath = "default.png";
        //            //fileName = "default.png";
        //        }
        //        var book = new Book
        //        {
        //            Title =bookVM.Title,
        //            Description =bookVM.Description,
        //            AvailabilityStatus =bookVM.AvailabilityStatus,
        //            PublishedDate =bookVM.PublishedDate,
        //            AuthorID =bookVM.AuthorID,
        //            GenreID =bookVM.GenreID,
        //            BookImage= $"{bookVM.BookImagePath}",


        //            //BookImage = $"{bookVM.BookImagePath}",
        //        };
        //        if (_bookservices.create(book))
        //        {

        //            return RedirectToAction(nameof(Index));
        //        }

        //        ViewBag.Authors = _authorservices.SelectedItems();
        //        ViewBag.Genres = _genreservices.SelectedItems();
        //        return View(bookVM);


        //    }
        //    ViewBag.Authors = _authorservices.SelectedItems();
        //    ViewBag.Genres = _genreservices.SelectedItems();
        //    return View(bookVM);

        //}



        [Authorize(Roles = $"{MyRoles.SuperAdminRole},{MyRoles.AdminRole}")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookViewModel bookVM)
        {
                if (_bookservices.BookExists(bookVM.Title, bookVM.AuthorID, bookVM.GenreID))
                {
                    ModelState.AddModelError("", "This book already exists with the same details.");
                    //ViewBag.Authors = _authorservices.GetAll();
                    //ViewBag.Genres = _genreservices.GetAll();
                    //return View(bookVM);
                }
            if (ModelState.IsValid)
            {

                string fileName = "default.png"; 

                if (bookVM.Image != null)
                {
                    try
                    {
                        string myFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                        if (!Directory.Exists(myFilePath))
                            Directory.CreateDirectory(myFilePath);

                        fileName = Guid.NewGuid().ToString() + Path.GetExtension(bookVM.Image.FileName);
                        string fullPath = Path.Combine(myFilePath, fileName);
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            await bookVM.Image.CopyToAsync(stream);
                        }
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "فشل رفع الصورة. حاول مرة أخرى.");
                    }
                }

                var book = new Models.Book
                {
                    Title = bookVM.Title,
                    Description = bookVM.Description,
                    AvailabilityStatus = bookVM.AvailabilityStatus,
                    PublishedDate = bookVM.PublishedDate,
                    AuthorID = bookVM.AuthorID,
                    GenreID = bookVM.GenreID,
                    BookImage = fileName
                };


                

                if (_bookservices.create(book))
                {
                    return RedirectToAction(nameof(Index));
                }

            }

            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
            foreach (var error in errors)
            {
                Console.WriteLine(error); 
            }

            ViewBag.Authors = _authorservices.GetAll();
            ViewBag.Genres = _genreservices.GetAll();
            return View(bookVM);
        }



        [Authorize(Roles = $"{MyRoles.SuperAdminRole},{MyRoles.AdminRole}")]
           //GET : Books/Edit/5 
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookservices.GetOne(id);
            if (book == null)
            {
                return NotFound();
            }
            var bookVM = new BookViewModel
            {
                Title = book.Title,
                Description = book.Description,
                AvailabilityStatus = book.AvailabilityStatus,
                PublishedDate = book.PublishedDate,
                AuthorID = book.AuthorID,
                GenreID = book.GenreID,
                BookImagePath = book.BookImage,

                // If you want to pass the image path, consider adding it here
                // bookImagePath = book.bookImagePath // If applicable
            };
            ViewBag.Authors = _authorservices.GetAll();
            ViewBag.Genres = _genreservices.GetAll();
            return View(bookVM);
        }



        [Authorize(Roles = $"{MyRoles.SuperAdminRole},{MyRoles.AdminRole}")]

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookViewModel bookVM)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (_bookservices.BookExists(bookVM.Title, bookVM.AuthorID, bookVM.GenreID, id))
            {
                ModelState.AddModelError("", "This book already exists with the same details.");
                //ViewBag.Authors = _authorservices.GetAll();
                //ViewBag.Genres = _genreservices.GetAll();
                //return View(bookVM);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var book = _bookservices.GetOne(id);
                    if (book == null)
                    {
                        return NotFound();
                    }

                    // Check if the book is currently checked out
                    var checkout = await _checkoutservices.GetActiveCheckoutForBook(id);
                    if (checkout != null && bookVM.AvailabilityStatus)
                    {
                        // Book is checked out, display a message
                        var user = await _usermanager.FindByIdAsync(checkout.UserId);
                        ModelState.AddModelError("", $"This book is checked out by {user.UserName}.");
                        // Reset the AvailabilityStatus in the view model
                        bookVM.AvailabilityStatus = false; 
                    }

                    if (!ModelState.IsValid) 
                    {
                        ViewBag.Authors = _authorservices.GetAll();
                        ViewBag.Genres = _genreservices.GetAll();
                        return View(bookVM);
                    }

                    string fileName = string.Empty;
                    if (bookVM.Image != null)
                    {
                        string myFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                        if (!Directory.Exists(myFilePath))
                            Directory.CreateDirectory(myFilePath);
                        fileName = Guid.NewGuid().ToString() + Path.GetExtension(bookVM.Image.FileName);
                        string fullPath = Path.Combine(myFilePath, fileName);
                        await bookVM.Image.CopyToAsync(new FileStream(fullPath, FileMode.Create));
                        bookVM.BookImagePath = fileName;
                        string oldPath = Path.Combine(book.BookImage, myFilePath);
                        //File.Remove(oldPath);
                    }

                    book.Title = bookVM.Title;
                    book.Description = bookVM.Description;
                    book.AvailabilityStatus = bookVM.AvailabilityStatus;
                    book.PublishedDate = bookVM.PublishedDate;
                    book.AuthorID = bookVM.AuthorID;
                    book.GenreID = bookVM.GenreID;
                    book.BookImage = bookVM.BookImagePath;

                    if (_bookservices.Update(id, book))
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    ViewBag.Authors = _authorservices.GetAll();
                    ViewBag.Genres = _genreservices.GetAll();
                    return View(bookVM);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_bookservices.IsExist(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            ViewBag.Authors = _authorservices.GetAll();
            ViewBag.Genres = _genreservices.GetAll();
            return View(bookVM);
        }


        [Authorize(Roles = $"{MyRoles.SuperAdminRole},{MyRoles.AdminRole}")]

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookservices.GetOne(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }



        [Authorize(Roles = $"{MyRoles.SuperAdminRole},{MyRoles.AdminRole}")]

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = _bookservices.GetOne(id);
            if (book != null)
            {
                _bookservices.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return View(book);
        }



    }
}
