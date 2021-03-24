using System;

namespace CG.WebApi.ApiModels
{
    public class ResponseAuthentication
    {
        public string Token { get; set; }

        public DateTime Expiration { get; set; }
    }
}
