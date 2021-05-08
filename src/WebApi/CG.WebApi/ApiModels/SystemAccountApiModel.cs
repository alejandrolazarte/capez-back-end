using System;
using System.Collections.Generic;

namespace CG.WebApi.ApiModels
{
    public class SystemAccountApiModel
    {
        public string Email { get; set; }

        public IEnumerable<string> Roles { get; set; }

        public string Token { get; set; }

        public DateTime Expiration { get; set; }
    }
}
