using System.Threading;
using System.Threading.Tasks;
using CG.Domain.Repository;
using MediatR;

namespace CG.Application.Company.Commands
{
    public class CompanyCreateCommandHandler : IRequestHandler<CompanyCreateCommand, long>
    {
        private readonly IRepository<Domain.Entities.Company> _companyRepository;

        public CompanyCreateCommandHandler(IRepository<Domain.Entities.Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<long> Handle(CompanyCreateCommand request, CancellationToken cancellationToken)
        {
            var company = new Domain.Entities.Company()
            {
                BusinessName = request.BusinessName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                TaxId = request.TaxId
            };

            await _companyRepository.Add(company);
            return company.Id;
        }
    }
}