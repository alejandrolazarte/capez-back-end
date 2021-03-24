using MediatR;

namespace CG.Application.Company.Commands
{
    public class CompanyCreateCommand : IRequest<long>
    {
        public string BusinessName { get; set; }
        public string Email { get; set; }
        public string TaxId { get; set; }
        public string PhoneNumber { get; set; }

    }
}
