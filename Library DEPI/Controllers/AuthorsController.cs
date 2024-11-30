using Microsoft.AspNetCore.Authorization;

namespace Library_DEPI.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorServices _authorServices;

        public AuthorsController(IAuthorServices authorServices)
        {
            _authorServices = authorServices;
        }
        // GET: Authors
        public async Task<IActionResult> Index()
        {
            return View(_authorServices.GetAll());
        }

        // GET: Authors/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = _authorServices.GetOne(id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }
        [Authorize(Roles =$"{MyRoles.SuperAdminRole},{MyRoles.AdminRole}")]
        // GET: Authors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = $"{MyRoles.SuperAdminRole},{MyRoles.AdminRole}")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Author author)
        {
            if (_authorServices.ExistsByName(author.Name)) // تحقق إذا كان الاسم موجود
            {
                ModelState.AddModelError("Name", "This author name already exists. Please choose a different name.");
            }

            if (ModelState.IsValid)
            {
                _authorServices.create(author);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        [Authorize(Roles = $"{MyRoles.SuperAdminRole},{MyRoles.AdminRole}")]

        // GET: Authors/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = _authorServices.GetOne(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = $"{MyRoles.SuperAdminRole},{MyRoles.AdminRole}")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Author author)
        {
            if (id != author.Id)
            {
                return NotFound();
            }

            if (_authorServices.ExistsByName(author.Name, id)) // تحقق إذا كان الاسم موجود
            {
                ModelState.AddModelError("Name", "This author name already exists. Please choose a different name.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _authorServices.Update(id, author);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_authorServices.IsExist(author.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        [Authorize(Roles = $"{MyRoles.SuperAdminRole},{MyRoles.AdminRole}")]

        // GET: Authors/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = _authorServices.GetOne(id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }
        [Authorize(Roles = $"{MyRoles.SuperAdminRole},{MyRoles.AdminRole}")]

        //// POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var author = _authorServices.GetOne(id);
            if (author != null)
            {
                _authorServices.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }




    }
}
