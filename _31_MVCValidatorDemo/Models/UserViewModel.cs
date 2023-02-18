using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _31_MVCValidatorDemo.Models
{
    [Table("T_User")]
    public class UserViewModel
    {
        [Key]
        [EmailAddress]
        public string UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }
}
