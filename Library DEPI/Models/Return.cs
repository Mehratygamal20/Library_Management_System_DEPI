//using System.ComponentModel.DataAnnotations;

//namespace Library_DEPI.Models
//{
//    public class Return
//    {
//        public int Id { get; set; }
//        public DateTime ReturnDate { get; set; } = DateTime.Now;
//        public decimal PenaltyAmount { get; set; }
//        public int CheckoutID { get; set; }
//        public Checkout Checkout { get; set; }
//    }
//}










using System.ComponentModel.DataAnnotations;

namespace Library_DEPI.Models
{
    [Table("Return", Schema = "dbo")]
    public class Return
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Return ID")]
        public int Id { get; set; }


        [ForeignKey("Checkout")]
        [Required]
        public int CheckoutId { get; set; } // Foreign key to Checkout


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Return Date")]


        public DateTime ReturnDate { get; set; }


        [Required]
        [Precision(18, 2)]
        [Display(Name = "Penalty Amount")]
        public decimal PenaltyAmount { get; set; }

        // Navigation property
        public virtual Checkout Checkout { get; set; }
    }
}
