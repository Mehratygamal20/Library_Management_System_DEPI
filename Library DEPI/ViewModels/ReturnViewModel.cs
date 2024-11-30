namespace Library_DEPI.ViewModels
{
    public class ReturnViewModel
    {
        public int CheckoutId { get; set; }
        public DateTime CheckoutDate { get; set; }
        public DateTime DueDate { get; set; }
        public string BookTitle { get; set; }
        public DateTime ReturnDate { get; set; }
        public decimal PenaltyAmount { get; set; }
    }
}
