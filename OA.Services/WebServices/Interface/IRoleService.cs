using OA.Models.DTO;

namespace OA.Services.WebServices.Interface
{
    public interface IRoleService
    {
        Task<bool> CreateAsync(string? roleName);
        Task<bool> DeleteAsync(string? id);
        Task<bool> UpdateAsync(string? roleName, string? id);
        Task<IEnumerable<ApplicationRole>> FindAllAsync();
        Task<ApplicationRole> FindByNameAsync(string? roleName);
        Task<ApplicationRole> FindByIdAsync(string? id);
    }
}
