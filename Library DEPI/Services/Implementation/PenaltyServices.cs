
namespace Library_DEPI.Services.Implementation
{
	public class PenaltyServices : IPenaltyServices
	{
		private readonly AppDBContext _context;

		public PenaltyServices(AppDBContext context)
		{
			_context = context;
		}

		public Task ApplyPenaltyAsync(int checkoutId, DateTime returnDate)
		{
			throw new NotImplementedException();
		}
		//public Task ApplyPenaltyAsync(int checkoutId, DateTime returnDate)
		//{
		//	var checkout = await _context.Checkouts.FindAsync(checkoutId);
		//	DateTime dueDate = checkout.CheckoutDate.AddDays(14); // على فرض أن مدة الإعارة 14 يومًا

		//	decimal penaltyAmount = CalculatePenalty(dueDate, returnDate, 1.0m); // نفترض أن الغرامة اليومية 1 جنيه

		//	// إنشاء سجل للإرجاع
		//	var returnRecord = new Return
		//	{
		//		CheckoutID = checkoutId,
		//		ReturnDate = returnDate,
		//		PenaltyAmount = penaltyAmount
		//	};

		//	_context.Returns.Add(returnRecord);
		//	await _context.SaveChangesAsync();

		//	// إذا كانت هناك غرامة، يتم إدخالها في جدول الغرامات
		//	if (penaltyAmount > 0)
		//	{
		//		var penalty = new Penalty
		//		{
		//			Amount = penaltyAmount,
		//			OverdueDays = (returnDate - dueDate).Days,
		//			ReturnID = returnRecord.Id
		//		};
		//		_context.Penalties.Add(penalty);
		//		await _context.SaveChangesAsync();
		//	}
		//}

		public decimal CalculatePenalty(DateTime dueDate, DateTime returnDate, decimal penaltyRatePerDay)
		{
			if (returnDate > dueDate)
			{
				int overdueDays = (returnDate - dueDate).Days;
				return overdueDays * penaltyRatePerDay;
			}
			return 0;
		}
		public async Task<IEnumerable<Penalty>> GetAllPenaltiesAsync()
		{
			return await _context.Penalties.ToListAsync();
		}

		public async Task<Penalty> GetPenaltyByIdAsync(int id)
		{
			return await _context.Penalties.FindAsync(id);
		}

		public async Task DeletePenaltyAsync(int id)
		{
			var penalty = await _context.Penalties.FindAsync(id);
			if (penalty != null)
			{
				_context.Penalties.Remove(penalty);
				await _context.SaveChangesAsync();
			}
		}

		
	}
}
