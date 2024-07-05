using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuanLyToChucAPI.DTOs;
using QuanLyToChucAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLyToChucAPI.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<SystemUser> _userManager;

        public UserService(UserManager<SystemUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<SystemUser> GetUserDetails(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception();
            }

            var roles = await _userManager.GetRolesAsync(user);
            return user;
        }

        public async Task<bool> UpdateUser(string userId, SystemUser updateUser)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            user.FullName = updateUser.FullName;
            user.Address = updateUser.Address;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> UpdateUserRole(string userId, string newRole)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return false;
            }

            var currentRoles = await _userManager.GetRolesAsync(user);
            var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
            if (!removeResult.Succeeded)
            {
                return false;
            }

            var addResult = await _userManager.AddToRoleAsync(user, newRole);
            return addResult.Succeeded;
        }
        public async Task<List<SystemUser>> GetAllUsers()
        {
            return await _userManager.Users.ToListAsync();
        }
    }
}
