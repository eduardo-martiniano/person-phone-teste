using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
            var personPhones = await _personPhoneService.Get();
            return Ok(personPhones.Select(pp => new PersonPhoneModel(pp)));
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var personPhone = await _personPhoneService.Get(id);
            return Ok(new PersonPhoneModel(personPhone));
        }

        [HttpGet, Route("types")]
        public async Task<IActionResult> GetPhoneNumberTypes()
        {
            var types = await _personPhoneService.GetPhoneNumberTypes();
            return Ok(types.Select(t => new PhoneNumberTypeModel(t)));
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> Create([FromBody] CreatePersonPhoneModel model)
        {
            var personPhone = await _personPhoneService.Create(model.MapTo());
            return CreatedAtAction(nameof(Get), new { id = personPhone.BusinessEntityID }, personPhone);
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
