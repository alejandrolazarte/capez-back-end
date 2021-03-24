using AutoMapper;
using CG.Application.Company.DTOs;

namespace CG.Application.Common.Mappers
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Domain.Entities.Company, CompanyDto>();
        }
    }
}
