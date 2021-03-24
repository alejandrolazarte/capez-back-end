using CG.Application.Company.Commands;
using CG.Application.Company.DTOs;
using CG.Application.Company.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CG.Application.Common.PagedList;

namespace CG.WebApi.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompanyController : BaseController
    {
        public CompanyController(IMediator mediator)
            : base(mediator)
        {
        }

        [HttpGet]
        [Route("{pageNumber}/{pageSize}")]
        public async Task<PagedList<CompanyDto>> GetAll(int pageNumber, int pageSize) 
        {
            return await Mediator.Send(new CompanyGetAllQuery(pageNumber, pageSize));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<long>> Create(CompanyCreateCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<ActionResult<long>> Update(long id, [FromBody] CompanyCreateCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
