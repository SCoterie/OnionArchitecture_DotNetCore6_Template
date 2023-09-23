using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OA.Models.DTO;
using OA.Services.Mappings;
using OA.Services.WebServices.Interface;

namespace OA.Services.WebServices.Implementation
{
    public class RoleServices : IRoleService
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IMap<ApplicationRole> _oa_mapper;

        public RoleServices(RoleManager<ApplicationRole> roleManager, IMapper mapper, IMap<ApplicationRole> oa_mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _oa_mapper = oa_mapper;
        }

        public async Task<bool> CreateAsync(string? roleName)
        {
            var result = await _roleManager.CreateAsync(_mapper.Map<ApplicationRole>(roleName));
            if (result.Succeeded)
                return true;
            return false;
        }

        public async Task<bool> DeleteAsync(string? id)
        {
            var result = await _roleManager.DeleteAsync(await _roleManager.FindByIdAsync(id));
            if (result.Succeeded)
                return true;
            return false;
        }

        public async Task<IEnumerable<ApplicationRole>> FindAllAsync()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<ApplicationRole> FindByNameAsync(string? roleName)
        {
            return await _roleManager.FindByNameAsync(roleName);
        }

        public async Task<bool> UpdateAsync(string? roleName, string? id)
        {
            var result = await _roleManager.UpdateAsync(_oa_mapper.Map(await _roleManager.FindByIdAsync(id), "Name", roleName!));
            if (result.Succeeded)
                return true;
            return false;
        }

        public async Task<ApplicationRole> FindByIdAsync(string? id)
        {
            return await _roleManager.FindByIdAsync(id);
        }
    }
}
