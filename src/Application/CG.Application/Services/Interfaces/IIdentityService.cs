using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CG.Application.Common.Models;

namespace CG.Application.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);
        
        Task<IEnumerable<Claim>> GetClaimsAsync(string userName);
        
        Task<bool> Login(string userName, string password);
    }
}
