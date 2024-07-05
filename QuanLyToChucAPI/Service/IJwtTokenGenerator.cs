using Microsoft.AspNetCore.Identity;
using QuanLyToChucAPI.Models;

namespace QuanLyToChucAPI.Service
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(SystemUser user, IEnumerable<string>? role);
    }
}
