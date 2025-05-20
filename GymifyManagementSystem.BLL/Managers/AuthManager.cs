using GymifyManagementSystem.BLL.Dtos.AuthDto;
using GymifyManagementSystem.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GymifyManagementSystem.BLL.Managers
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole<string>> _roleManager; // ✅ صح بناءً على الـ ApplicationUser
        private readonly IConfiguration _configuration;

        public AuthManager(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole<string>> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<string> Register(RegisterDto dto)
        {
            var existingUser = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUser != null)
                throw new ArgumentException("Email is already registered");

            var user = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(), // ✅ أضف السطر ده

                UserName = dto.Email,
                Email = dto.Email,
                FullName = dto.FullName
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
                throw new ApplicationException(string.Join(", ", result.Errors.Select(e => e.Description)));

            return "User registered successfully";
        }

        public async Task<AuthResponseDto> Login(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
                throw new UnauthorizedAccessException("Invalid credentials");

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
            if (!result.Succeeded)
                throw new UnauthorizedAccessException("Invalid credentials");

            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("FullName", user.FullName)
            };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key not configured")));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(12),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            return new AuthResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Email = user.Email,
                FullName = user.FullName,
                Roles = roles.ToList()
            };
        }

        public async Task<List<UserReadDto>> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return users.Select(u => new UserReadDto
            {
                Id = u.Id,
                Email = u.Email,
                FullName = u.FullName
            }).ToList();
        }

        public async Task<string> CreateRole(RoleAddDto dto)
        {
            if (await _roleManager.RoleExistsAsync(dto.RoleName))
                throw new ArgumentException("Role already exists");

            var result = await _roleManager.CreateAsync(new IdentityRole(dto.RoleName));

            if (!result.Succeeded)
                throw new ApplicationException(string.Join(", ", result.Errors.Select(e => e.Description)));

            return "Role created successfully";
        }

        public async Task<string> AssignRoleToUser(AssignRoleDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId);
            if (user == null)
                throw new KeyNotFoundException("User not found");

            if (!await _roleManager.RoleExistsAsync(dto.RoleName))
                throw new KeyNotFoundException("Role does not exist");

            if (await _userManager.IsInRoleAsync(user, dto.RoleName))
                throw new ArgumentException("User already has this role");

            var result = await _userManager.AddToRoleAsync(user, dto.RoleName);

            if (!result.Succeeded)
                throw new ApplicationException(string.Join(", ", result.Errors.Select(e => e.Description)));

            return "Role assigned successfully";
        }

        public async Task<List<RoleReadDto>> GetAllRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return roles.Select(r => new RoleReadDto
            {
                Id = r.Id,
                RoleName = r.Name
            }).ToList();
        }
    }
}