/*using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Library_DEPI.Services;
using Library_DEPI.ViewModels;
using Library_DEPI.Models;

namespace Library_DEPI.Controllers
{
    public class ReturnsController : Controller
    {
        private readonly IReturnServices _returnServices;
       // private readonly ICheckoutServices _checkoutServices; 

        public ReturnsController(IReturnServices returnServices, ICheckoutServices checkoutServices)
        {
            _returnServices = returnServices;
            _checkoutServices = checkoutServices;
        }

        // GET: Return/Create/{checkoutId}
        public IActionResult Create(int checkoutId)
        {
            // Fetch checkout details to display on the return view
            var checkout = _checkoutServices.GetCheckoutById(checkoutId);
            if (checkout == null)
            {
                return NotFound(); // If no such checkout record exists
            }

            var returnViewModel = new ReturnViewModel
            {
                CheckoutId = checkoutId,
                BookTitle = checkout.Book.Title,
                CheckoutDate = checkout.CheckoutDate,
                DueDate = checkout.DueDate,
                ReturnDate = DateTime.Now
            };

            // Optionally, pre-calculate the penalty and display it
            returnViewModel.PenaltyAmount = _returnServices.CalculatePenalty(checkout.DueDate, DateTime.Now);

            return View(returnViewModel);
        }

        // POST: Return/Create
        [HttpPost]
        public IActionResult Create(ReturnViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // If validation fails, return the view with the current model
            }

            try
            {
                // Create the return record
                var returnEntry = _returnServices.CreateReturn(model.CheckoutId, model.ReturnDate);

                // Redirect to the list of all returns (or some confirmation page)
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Handle any errors during the process (e.g., checkout not found)
                ModelState.AddModelError("", "Error creating return: " + ex.Message);
                return View(model);
            }
        }

        // GET: Return/Index
        public IActionResult Index()
        {
            // Fetch all returns
            var returns = _returnServices.GetAllReturns();

            // Map the returns to ReturnViewModel for the view
            var returnViewModels = returns.Select(r => new ReturnViewModel
            {
                CheckoutId = r.CheckoutId,
                BookTitle = r.Checkout.Book.Title, // Assuming navigation to Book exists
                ReturnDate = r.ReturnDate,
                PenaltyAmount = r.PenaltyAmount
            }).ToList();

            return View(returnViewModels);
        }

        // GET: Return/Details/{id}
        public IActionResult Details(int id)
        {
            var returnRecord = _returnServices.GetReturnById(id);
            if (returnRecord == null)
            {
                return NotFound();
            }

            var returnViewModel = new ReturnViewModel
            {
                CheckoutId = returnRecord.CheckoutId,
                BookTitle = returnRecord.Checkout.Book.Title,
                ReturnDate = returnRecord.ReturnDate,
                PenaltyAmount = returnRecord.PenaltyAmount,
                CheckoutDate = returnRecord.Checkout.CheckoutDate,
                DueDate = returnRecord.Checkout.DueDate
            };

            return View(returnViewModel);
        }
    }
}*/
public class ReturnsController : Controller
{
    private readonly IReturnServices _returnServices;
    public ReturnsController(IReturnServices returnServices)
    {
        _returnServices = returnServices;
    }
    public IActionResult Index()
    {

        return View(_returnServices.GetAll());
    }
    
    
    
    [HttpPost]
    public IActionResult Create(Return @return)
    {
        return View(_returnServices.GetAll());
    }
    

}

