using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyToChucAPI.DTOs;
using QuanLyToChucAPI.Models;
using QuanLyToChucAPI.Services;
using System.Threading.Tasks;

namespace QuanLyToChucAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserDetails(string userId)
        {
            var response = await _userService.GetUserDetails(userId);
            return Ok(response);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(string userId, SystemUser updateUser)
        {
            var response = await _userService.UpdateUser(userId, updateUser);
            return Ok(response);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var response = await _userService.DeleteUser(userId);
            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _userService.GetAllUsers();
            return Ok(response);
        }

        [HttpPost("{userId}/role")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> UpdateUserRole(string userId, [FromBody] RoleUpdateRequest request)
        {
            var response = await _userService.UpdateUserRole(userId, request.NewRole);
            if (!response)
            {
                return BadRequest("Failed to update user role");
            }

            return Ok("User role updated successfully");
        }
    }
}
