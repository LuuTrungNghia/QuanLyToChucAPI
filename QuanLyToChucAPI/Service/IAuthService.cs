using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Identity;
using QuanLyToChucAPI.DTOs;
using QuanLyToChucAPI.Models;

namespace QuanLyToChucAPI.Services
{
    public interface IAuthService
    {
        Task<SystemUser> RegisterSystemUser(SystemRegisterUserDTO user);
        Task<LoginResponseDTO> LoginSystemUser(SystemSignInUserDTO credentials);
    }
}
