using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace KTaseva.Models
{
    public class User : IdentityUser
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string LastName { get; set; }
    }
}
