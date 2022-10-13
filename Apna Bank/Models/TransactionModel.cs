using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apna_Bank.Models
{
    public class TransactionModel
    {
        [Key]
        public int TransactionId { get; set; }
        [MaxLength(14)]
        [Required(ErrorMessage = "This field is  required")]
        [DisplayName("Account Number")]
        [Column(TypeName = "nvarchar(15)")]
        public string? AccountNumber { get; set; }

        [Required(ErrorMessage = "This field is  required")]
        [DisplayName("Beneficiary Name")]
        [Column(TypeName = "nvarchar(100)")]
        public string? BeneficiaryName { get; set; }

        [Required(ErrorMessage = "This field is  required")]
        [DisplayName("Bank Name")]
        [Column(TypeName = "nvarchar(100)")]
        public string? BankName { get; set; }

        [MaxLength(11)]
        [Required(ErrorMessage = "This field is  required")]
        [DisplayName("Ifsc Code")]
        [Column(TypeName = "nvarchar(100)")]
        public string? IfscCode { get; set; }
        public int Amount { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }
    }
}
