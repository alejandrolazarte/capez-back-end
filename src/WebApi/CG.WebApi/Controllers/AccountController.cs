using CG.Application.Common.Helpers;
using CG.Application.Common.Models;
using CG.Application.Services.Interfaces;
using CG.WebApi.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CG.WebApi.Controllers
{

    [Route("api/accounts")]
    public class AccountController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly JwtKey _jwtKey;

        public AccountController(IIdentityService identityService,
            IOptions<JwtKey> options)
        {
            _identityService = identityService;
            _jwtKey = options.Value;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<SystemAccountApiModel>> Create([FromBody] SystemAccountCredentials systemAccountCredentials)
        {
            var (result, _) = await _identityService.CreateUserAsync(systemAccountCredentials.Email,
                systemAccountCredentials.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var response = await CreateAuthenticationResponse(systemAccountCredentials);
            return Ok(response);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<SystemAccountApiModel>> Login([FromBody] SystemAccountCredentials systemAccountCredentials)
        {
            var result = await _identityService.Login(systemAccountCredentials.Email,
                systemAccountCredentials.Password);

            if (!result)
            {
                return BadRequest("Login incorrecto");
            }

            var response = await CreateAuthenticationResponse(systemAccountCredentials);
            return Ok(response);
        }

        private async Task<SystemAccountApiModel> CreateAuthenticationResponse(SystemAccountCredentials systemAccountCredentials)
        {
            var claims = new List<Claim>
            {
                new("email", systemAccountCredentials.Email)
            };

            claims.AddRange(await _identityService.GetClaimsAsync(systemAccountCredentials.Email));
            var roles = await _identityService.GetRolesAsync(systemAccountCredentials.Email);


            var key = new SymmetricSecurityKey(_jwtKey.GetBytes());
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(1);

            var token = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expiration,
                signingCredentials: credentials);

            return new SystemAccountApiModel
            {
                Roles = roles,
                Email = systemAccountCredentials.Email,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }

    }
}
