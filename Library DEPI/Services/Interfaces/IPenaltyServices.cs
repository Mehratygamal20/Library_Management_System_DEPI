namespace Library_DEPI.Services.Interfaces
{
	public interface IPenaltyServices
	{
		decimal CalculatePenalty(DateTime dueDate, DateTime returnDate, decimal penaltyRatePerDay);
		Task ApplyPenaltyAsync(int checkoutId, DateTime returnDate);
		Task<IEnumerable<Penalty>> GetAllPenaltiesAsync();
		Task<Penalty> GetPenaltyByIdAsync(int id);
		Task DeletePenaltyAsync(int id);
	}
}
