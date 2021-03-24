using CG.Application.Company.DTOs;
using MediatR;
using System.Collections.Generic;
using CG.Application.Common.PagedList;

namespace CG.Application.Company.Queries
{
    public class CompanyGetAllQuery : IRequest<PagedList<CompanyDto>>
    {
        public CompanyGetAllQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public int PageNumber { get; }
        public int PageSize { get; }
    }
}
