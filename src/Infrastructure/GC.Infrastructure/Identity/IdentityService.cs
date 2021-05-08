using System.Collections.Generic;
using System.Security.Claims;
using CG.Application.Common.Models;
using CG.Application.Services.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CG.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<SystemAccount> _userManager;
        private readonly SignInManager<SystemAccount> _signInManager;

        public IdentityService(UserManager<SystemAccount> userManager,
            SignInManager<SystemAccount> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
        {
            var user = new SystemAccount
            {
                UserName = userName,
                Email = userName
            };

            var result = await _userManager.CreateAsync(user, password);
            return (result.ToApplicationResult(), user.Id);
        }

        public async Task<bool> Login(string userName, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(userName, password, false, false);
            return result.Succeeded;
        }

        public async Task<IEnumerable<Claim>> GetClaimsAsync(string userName)
        {
            var user = await _userManager.FindByEmailAsync(userName);
            return await _userManager.GetClaimsAsync(user);
        }

        public async Task<IEnumerable<string>> GetRolesAsync(string userName)
        {
            var user = await _userManager.FindByEmailAsync(userName);
            return await _userManager.GetRolesAsync(user);
        }
    }
}
