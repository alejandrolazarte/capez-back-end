using CG.Application.Common.Models;
using System.Text;

namespace CG.Application.Common.Helpers
{
    public static class JwtKeyExtencions
    {
        public static byte[] GetBytes(this JwtKey jwtKey)
        {
            return Encoding.UTF8.GetBytes(jwtKey.Key);
        }
    }
}
