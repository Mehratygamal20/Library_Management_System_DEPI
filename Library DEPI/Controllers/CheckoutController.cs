
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Library_DEPI.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ICheckoutServices _checkoutService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IBookServices _bookService;
        private readonly AppDBContext _context;

        public CheckoutController(ICheckoutServices checkoutService, UserManager<IdentityUser> userManager, IBookServices bookService, AppDBContext context)
        {
            _checkoutService = checkoutService;
            _userManager = userManager;
            _bookService = bookService;
            _context = context;
        }

       
            public async Task<IActionResult> Index()
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (string.IsNullOrEmpty(userId))
                {
                     return Redirect("/Identity/Account/Register");
                 }

                var checkouts = await _checkoutService.GetAllCheckoutsAsync(userId);
                return View(checkouts);
            }


            public async Task<IActionResult> Details(int id)
        {
            var checkout = await _checkoutService.GetCheckoutByIdAsync(id);
            if (checkout == null)
            {
                return NotFound();
            }

            return View(checkout);
        }

        public async Task<IActionResult> Create(int selectedBookId)
        {
            var viewModel = new CheckoutViewModel
            {
                SelectedBookId = selectedBookId,
                CheckoutDate = DateTime.Now,
                AvailableBooks = await _bookService.GetAll().Where(b=>b.AvailabilityStatus).ToListAsync()
            };

            if (User.IsInRole("Admin") || User.IsInRole("Super Admin"))
            {
                viewModel.AvailableUsers = await _userManager.Users.ToListAsync();
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                viewModel.SelectedUserId = userId;
            }
            else
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                viewModel.SelectedUserId = userId;
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CheckoutViewModel model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login");
            }

                
            if (ModelState.IsValid)
            {
                await _checkoutService.CreateCheckoutAsync(model);
                return RedirectToAction(nameof(Index));
            }

            model.AvailableBooks = await _bookService.GetAll().Where(b => b.AvailabilityStatus).ToListAsync();

            if (User.IsInRole("Admin") || User.IsInRole("Super Admin"))
            {
                model.AvailableUsers = await _userManager.Users.ToListAsync();
            }

            return View(model);
        }



        [Authorize(Roles = $"{MyRoles.SuperAdminRole},{MyRoles.AdminRole}")]
        public async Task<IActionResult> Edit(int id)
        {
            var checkout = await _checkoutService.GetCheckoutByIdAsync(id);
            if (checkout == null)
            {
                return NotFound();
            }

            var viewModel = new CheckoutViewModel
            {
                Id = checkout.Id,
                CheckoutDate = checkout.CheckoutDate,
                SelectedBookId = checkout.BookID,
                SelectedUserId = checkout.UserId,
                AvailableBooks = await _bookService.GetAll().Where(b => b.AvailabilityStatus || b.Id == checkout.BookID).ToListAsync(),
            };

            if (User.IsInRole("Admin") || User.IsInRole("Super Admin"))
            {
                viewModel.AvailableUsers = await _userManager.Users.ToListAsync();
            }
            else
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                viewModel.SelectedUserId = userId;
            }

            return View(viewModel);
        }




        [Authorize(Roles = $"{MyRoles.SuperAdminRole},{MyRoles.AdminRole}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CheckoutViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _checkoutService.UpdateCheckoutAsync(id, model);
                return RedirectToAction(nameof(Index));
            }

            model.AvailableBooks = await _bookService.GetAll().Where(b => b.AvailabilityStatus || b.Id == model.SelectedBookId).ToListAsync();

            if (User.IsInRole("Admin") || User.IsInRole("Super Admin"))
            {
                model.AvailableUsers = await _userManager.Users.ToListAsync();
            }

            return View(model);
        }

        [Authorize(Roles = $"{MyRoles.SuperAdminRole},{MyRoles.AdminRole}")]
        public async Task<IActionResult> Delete(int id)
        {
            var checkout = await _checkoutService.GetCheckoutByIdAsync(id);
            if (checkout == null)
            {
                return NotFound();
            }

            return View(checkout);
        }


        [Authorize(Roles = $"{MyRoles.SuperAdminRole},{MyRoles.AdminRole}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _checkoutService.DeleteCheckoutAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
