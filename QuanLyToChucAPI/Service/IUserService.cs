using Azure;
using QuanLyToChucAPI.DTOs;
using QuanLyToChucAPI.Models;
using System.Threading.Tasks;

namespace QuanLyToChucAPI.Services
{
    public interface IUserService
    {
        Task<SystemUser> GetUserDetails(string userId);
        Task<bool> UpdateUser(string userId, SystemUser updateUser);
        Task<bool> DeleteUser(string userId);
        Task<bool> UpdateUserRole(string userId, string newRole);
        Task<List<SystemUser>> GetAllUsers();
    }
}
