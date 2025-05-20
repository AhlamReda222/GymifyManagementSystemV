// DAL/Models/ApplicationUser.cs
using Microsoft.AspNetCore.Identity;
using GymifyManagementSystem.DAL.Database;
namespace GymifyManagementSystem.DAL.Models
{
    public class ApplicationUser : IdentityUser<string> // 
    {
        public string FullName { get; set; }
    }
}
