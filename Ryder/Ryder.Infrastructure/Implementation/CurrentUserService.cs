using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Ryder.Domain.Context;
using Ryder.Domain.Entities;
using Ryder.Infrastructure.Interface;
using System.Security.Claims;

namespace Ryder.Infrastructure.Implementation
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationContext _context;

        public CurrentUserService(
            IHttpContextAccessor httpContextAccessor,
            UserManager<AppUser> userManager,
            ApplicationContext context)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            UserRole = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Role);
            UserEmail = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);
            FullName = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.GivenName)
                       + " " + httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Surname);
            UserPhoneNumber = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.MobilePhone);
            _userManager = userManager;
            _context = context;
        }

        public string? UserId { get; }
        public string? UserRole { get; }
        public string? UserEmail { get; }
        public string FullName { get; }
        public string? UserPhoneNumber { get; set; }
    }
}