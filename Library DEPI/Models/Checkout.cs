namespace Library_DEPI.Models
{
    public class Checkout
    {
        public int Id { get; set; }
        public DateTime CheckoutDate { get; set; }
        public DateTime DueDate { get; set; }
        public int BookID { get; set; }
        public string UserId { get; set; }
        public string BookName { get; set; } // تأكد من وجود هذا
        public string UserEmail { get; set; } // تأكد من وجود هذا
        public virtual Book Book { get; set; }
        public virtual IdentityUser User { get; set; }
    }



}
