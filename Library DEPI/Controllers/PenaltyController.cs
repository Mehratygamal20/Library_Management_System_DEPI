using Microsoft.AspNetCore.Authorization;


namespace Library_DEPI.Controllers
{
	public class PenaltyController : Controller
	{
		private readonly IPenaltyServices _penaltyService;

		public PenaltyController(IPenaltyServices penaltyService)
		{
			_penaltyService = penaltyService;
		}

		// GET: Penalty
		// عرض جميع الغرامات
		public async Task<IActionResult> Index()
		{
			var penalties = await _penaltyService.GetAllPenaltiesAsync();
			return View(penalties);
		}

		// GET: Penalty/Details/5
		// عرض تفاصيل غرامة محددة
		public async Task<IActionResult> Details(int id)
		{
			var penalty = await _penaltyService.GetPenaltyByIdAsync(id);
			if (penalty == null)
			{
				return NotFound();
			}
			return View(penalty);
		}

        [Authorize(Roles = $"{MyRoles.SuperAdminRole},{MyRoles.AdminRole}")]
        // GET: Penalty/Delete/5
        // حذف غرامة
        public async Task<IActionResult> Delete(int id)
		{
			var penalty = await _penaltyService.GetPenaltyByIdAsync(id);
			if (penalty == null)
			{
				return NotFound();
			}
			return View(penalty);
		}


        [Authorize(Roles = $"{MyRoles.SuperAdminRole},{MyRoles.AdminRole}")]
        // POST: Penalty/Delete/5
        // تأكيد حذف غرامة
        [HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await _penaltyService.DeletePenaltyAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
