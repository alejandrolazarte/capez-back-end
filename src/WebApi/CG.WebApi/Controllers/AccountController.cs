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
        public async Task<ActionResult<ResponseAuthentication>> Create([FromBody] SystemAccountApiModel systemAccountApiModel)
        {
            var (result, _) = await _identityService.CreateUserAsync(systemAccountApiModel.Email,
                systemAccountApiModel.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            var response = await CreateResponseAuthentication(systemAccountApiModel);
            return Ok(response);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<ResponseAuthentication>> Login([FromBody] SystemAccountApiModel systemAccountApiModel)
        {
            var result = await _identityService.Login(systemAccountApiModel.Email,
                systemAccountApiModel.Password);

            if (!result)
            {
                return BadRequest("Login incorrect");
            }

            var response = await CreateResponseAuthentication(systemAccountApiModel);
            return Ok(response);
        }

        private async Task<ResponseAuthentication> CreateResponseAuthentication(SystemAccountApiModel systemAccountApiModel)
        {
            var claims = new List<Claim>
            {
                new("email", systemAccountApiModel.Email)
            };

            claims.AddRange(await _identityService.GetClaimsAsync(systemAccountApiModel.Email));

            var key = new SymmetricSecurityKey(_jwtKey.GetBytes());
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(1);

            var token = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expiration,
                signingCredentials: credentials);

            return new ResponseAuthentication
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }

    }
}
