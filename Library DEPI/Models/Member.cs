namespace Library_DEPI.Models
{
    public class Member:IdentityUser
    {
        //public string PhoneNumber { get; set; }
        //public DateTime RegistrationDate { get; set; } = DateTime.Now;

        public DateTime? RegistrationDate { get; set; }= DateTime.Now;
    }
}
