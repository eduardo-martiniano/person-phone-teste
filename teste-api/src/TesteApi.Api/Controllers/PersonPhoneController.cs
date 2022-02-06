using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TesteApi.Api.Models;
using TesteApi.Domain.Contracts;

namespace TesteApi.Api.Controllers
{
    [ApiController]
    [Route("api/person-phones")]
    public class PersonPhoneController : Controller
    {
        private readonly IPersonPhoneService _personPhoneService;

        public PersonPhoneController(IPersonPhoneService personPhoneService)
        {
            _personPhoneService = personPhoneService;
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _personPhoneService.Get());
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok(await _personPhoneService.Get(id));
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> Create([FromBody] CreatePersonPhoneModel model)
        {
            return Ok(await _personPhoneService.Create(model.MapTo()));
        }

        [HttpPut, Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePersonPhoneModel model)
        {
            await _personPhoneService.Update(id, model.MapTo());
            return NoContent();
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _personPhoneService.Delete(id);
            return NoContent();
        }
    }
}
