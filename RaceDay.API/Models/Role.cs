using System.ComponentModel.DataAnnotations;

namespace RaceDay.API.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        public string RoleName { get; set; } = string.Empty;
    }
}
