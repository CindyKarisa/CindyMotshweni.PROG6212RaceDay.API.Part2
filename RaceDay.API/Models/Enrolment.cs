using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RaceDay.API.Models
{
    public class Enrolment
    {
        [Key]
        public int EnrolmentId { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User? Participant { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        public int? BibNumber { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;
        public string? PaymentReference { get; set; }
    }
}
