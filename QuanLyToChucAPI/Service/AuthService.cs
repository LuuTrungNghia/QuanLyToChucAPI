using Azure;
using Microsoft.AspNetCore.Identity;
using QuanLyToChucAPI.DTOs;
using QuanLyToChucAPI.Models;
using QuanLyToChucAPI.Services;

namespace QuanLyToChucAPI.Service
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<SystemUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(UserManager<SystemUser> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<LoginResponseDTO> LoginSystemUser(SystemSignInUserDTO credentials)
        {
            try
            {
                var userFind = await _userManager.FindByEmailAsync(credentials.Email);
                if (userFind is null) {
                    return null;
                }
                var checkPass = await _userManager.CheckPasswordAsync(userFind, credentials.Password);
                if (checkPass)
                {
                    var userDto = new UserDto
                    {
                        Id = userFind.Id,
                        Email = userFind.Email,
                        UserName = userFind.UserName,
                        FullName = userFind.FullName,
                    };
                    var roles = (await _userManager.GetRolesAsync(userFind)) ?? [];
                    string token = _jwtTokenGenerator.GenerateToken(userFind, roles);

                    return new LoginResponseDTO
                    {
                        Token = token,
                        User = userDto,
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<SystemUser> RegisterSystemUser(SystemRegisterUserDTO user)
        {
            try
            {
                var userFind = await _userManager.FindByEmailAsync(user.Email);
                if (userFind != null) {

                    return null;
                
                }
                SystemUser userModel = new SystemUser();
                userModel.UserName = user.Email;
                userModel.Email = user.Email;
                userModel.Address = user.Address;
                userModel.FullName = user.FullName;

                var userCreate = await _userManager.CreateAsync(userModel, user.Password);
                if (userCreate.Succeeded)
                {
                    return userModel;
                }
                return null;
            }
            catch (Exception ex) {
                throw new Exception();
                    
            }
        }
    }
}
