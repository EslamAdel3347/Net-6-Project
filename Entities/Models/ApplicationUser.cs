
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class User : IdentityUser
    {

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? FirstName { get; set; }

    }
}
