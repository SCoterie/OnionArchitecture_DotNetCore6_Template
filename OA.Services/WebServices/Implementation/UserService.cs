using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OA.Models.DTO;
using OA.Models.ViewModel;
using OA.Services.Mappings;
using OA.Services.WebServices.Interface;

namespace OA.Services.WebServices.Implementation
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IMap<ApplicationUser> _oa_mapper;

        public UserService(UserManager<ApplicationUser> userManager, IMapper mapper, IMap<ApplicationUser> oa_mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _oa_mapper = oa_mapper;
        }

        public async Task<bool> CreateAsync(UserSignupViewModel userSignupVM)
        {
            var result = await _userManager.CreateAsync(_mapper.Map<ApplicationUser>(userSignupVM), userSignupVM.Password);
            if (result.Succeeded)
                return true;
            return false;
        }

        public async Task<bool> DeleteAsync(string? userName)
        {
            var result = await _userManager.DeleteAsync(await _userManager.FindByNameAsync(userName));
            if (result.Succeeded)
                return true;
            return false;
        }

        public async Task<IEnumerable<UserViewModel>> FindAllAsync()
        {
            var user = await _userManager.Users.ToListAsync();
            return user.Select(x => _mapper.Map<UserViewModel>(user));
        }

        public async Task<UserViewModel> FindByEmailAsync(string? email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return _mapper.Map<UserViewModel>(user);
        }

        public async Task<UserViewModel> FindByIdAsync(string? id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return _mapper.Map<UserViewModel>(user);
        }

        public async Task<UserViewModel> FindByUserNameAsync(string? userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return _mapper.Map<UserViewModel>(user);
        }

        public async Task<bool> UpdateAsync(UserUpdateViewModel userUpdateVM)
        {
            var result = await _userManager.UpdateAsync(_oa_mapper.Map(await _userManager.FindByIdAsync(userUpdateVM.Id), userUpdateVM));
            if (result.Succeeded)
                return true;
            return false;
        }
    }
}
