using System.Collections.Generic;
using System.Linq;

namespace CG.Application.Common.Models
{
    public class Result
    {
        internal Result(bool succeeded, params string[] errors)
        {
            Succeeded = succeeded;
            Errors = errors;
        }

        internal Result(bool succeeded)
        {
            Succeeded = succeeded;
            Errors = System.Array.Empty<string>();
        }

        public bool Succeeded { get; }

        public string[] Errors { get; }

        public static Result Success()
        {
            return new(true);
        }

        public static Result Failure(IEnumerable<string> errors)
        {
            return new(false, errors.ToArray());
        }
    }
}
