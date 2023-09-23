using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace OA.Models.DTO
{
    public class ApplicationRole : IdentityRole
    {
        [NotMapped]
        public int? NoofUsers { get; set; }
    }
}
