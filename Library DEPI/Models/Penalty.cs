namespace Library_DEPI.Models
{
    public class Penalty
    {
        public int Id { get; set; }
        public int OverdueDays { get; set; }
        public decimal Amount { get; set; }
        public int ReturnID { get; set; }
        public Return Return {  get; set; }
    }
}
