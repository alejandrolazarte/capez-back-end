using System;

namespace CG.WebApi.ApiModels
{
    public class AuthenticationResponse
    {
        public string Email { get; set; }

        public string Token { get; set; }

        public DateTime Expiration { get; set; }
    }
}
