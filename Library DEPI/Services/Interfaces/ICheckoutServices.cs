
namespace Library_DEPI.Services.Interfaces
{
    public interface ICheckoutServices
    {
        Task<IEnumerable<Checkout>> GetAllCheckoutsAsync(string userId);
        Task<Checkout> GetCheckoutByIdAsync(int id);
        Task CreateCheckoutAsync(CheckoutViewModel model);
        Task UpdateCheckoutAsync(int id, CheckoutViewModel model);
        Task DeleteCheckoutAsync(int id);
        Task<Checkout> GetActiveCheckoutForBook(int bookId);

       

    }
}
