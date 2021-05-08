using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CG.Application.Common.PagedList;
using CG.Application.Company.DTOs;
using CG.Domain.Repository;
using MediatR;

namespace CG.Application.Company.Queries
{
    public class CompanyGetAllQueryHandler : IRequestHandler<CompanyGetAllQuery, PagedList<CompanyDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Domain.Entities.Company> _companyRpository;

        public CompanyGetAllQueryHandler(IMapper mapper,
            IRepository<Domain.Entities.Company> companyRpository)
        {
            _mapper = mapper;
            _companyRpository = companyRpository;
        }

        public async Task<PagedList<CompanyDto>> Handle(CompanyGetAllQuery request, CancellationToken cancellationToken)
        {
            var (results, totalItems) = await _companyRpository.GetAllPaginated(request.PageNumber, request.PageSize);
            
            var pagedListCompanyDto = new PagedList<CompanyDto>(
                _mapper.Map<IEnumerable<CompanyDto>>(results),
                totalItems);

            return pagedListCompanyDto;
        }
    }
}