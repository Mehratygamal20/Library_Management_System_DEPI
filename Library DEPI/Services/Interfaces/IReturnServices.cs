namespace Library_DEPI.Services.Interfaces
{
    public interface IReturnServices
    {
        IEnumerable<Return> GetAll();
        Return GetOne(int id);
        bool Create(Return  data);
        bool Update(int id, Return data);
        bool Delete(int id);
        bool ISExist(int id);
    }
    /*{
        Return CreateReturn(int CheckoutId, DateTime ReturnDate);
        decimal CalculatePenalty(DateTime dueDate, DateTime ReturnDate);
        Return GetReturnById(int ReturnId);
        IEnumerable<Return> GetAllReturns();
    }*/
}
