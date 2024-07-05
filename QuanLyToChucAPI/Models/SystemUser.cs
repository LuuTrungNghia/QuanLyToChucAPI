using Microsoft.AspNetCore.Identity;

namespace QuanLyToChucAPI.Models
{
    public class SystemUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }
    }
}
