using CG.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CG.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class PersonPhoneNumberController : ControllerBase
    {
        private readonly IMigratePersonPhoneNumberService _migratePersonPhoneNumberService;

        public PersonPhoneNumberController(IMigratePersonPhoneNumberService migratePersonPhoneNumberService)
        {
            _migratePersonPhoneNumberService = migratePersonPhoneNumberService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> MigrateClients()
        {
            try
            {
                await _migratePersonPhoneNumberService.Migrate();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
