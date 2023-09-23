using Microsoft.AspNetCore.Identity;
using OA.Domain.Entities.Interface;

namespace OA.Models.DTO
{
    public class ApplicationUser : IdentityUser, IAuditEntity<string>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
