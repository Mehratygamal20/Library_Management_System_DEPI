namespace Library_DEPI.ViewModel
{
    public class CheckoutViewModel
    {
        public int Id { get; set; }
        public DateTime CheckoutDate { get; set; }
        public DateTime DueDate => CheckoutDate.AddDays(14); 
        public int SelectedBookId { get; set; }
        public string SelectedUserId { get; set; }

        public List<Book> AvailableBooks { get; set; } = new List<Book>(); 
        public List<IdentityUser> AvailableUsers { get; set; } = new List<IdentityUser>();

        // يمكن حذف الخصائص غير الضرورية إذا كانت غير مستخدمة في النموذج
        // public int BookID { get; set; } 
        // public string BookName { get; set; } 
        // public string UserId { get; set; } 
        // public string UserEmail { get; set; } 
    }
}
