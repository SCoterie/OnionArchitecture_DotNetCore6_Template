using OA.Models.ViewModel;

namespace OA.Services.WebServices.Interface
{
    public interface IUserService
    {
        Task<bool> CreateAsync(UserSignupViewModel userSignupVM);
        Task<bool> UpdateAsync(UserUpdateViewModel userUpdateVM);
        Task<bool> DeleteAsync(string? userName);
        Task<IEnumerable<UserViewModel>> FindAllAsync();
        Task<UserViewModel> FindByIdAsync(string? id);
        Task<UserViewModel> FindByUserNameAsync(string? userName);
        Task<UserViewModel> FindByEmailAsync(string? email);
    }
}
