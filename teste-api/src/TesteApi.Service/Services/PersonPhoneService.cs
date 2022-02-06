using System.Collections.Generic;
using System.Threading.Tasks;
using TesteApi.Domain.Contracts;
using TesteApi.Domain.Entities;

namespace TesteApi.Service.Services
{
    public class PersonPhoneService : IPersonPhoneService
    {
        private readonly IPersonPhoneRepository _personPhoneRepository;

        public PersonPhoneService(IPersonPhoneRepository personPhoneRepository)
        {
            _personPhoneRepository = personPhoneRepository;
        }

        public async Task<PersonPhone> Create(PersonPhone personPhone)
        {
            return await _personPhoneRepository.Create(personPhone);
        }

        public async Task Delete(int id)
        {
            await _personPhoneRepository.Delete(id);
        }

        public async Task<PersonPhone> Get(int id)
        {
            return await _personPhoneRepository.Get(id);
        }

        public async Task<List<PersonPhone>> Get()
        {
            return await _personPhoneRepository.Get();
        }

        public async Task<List<PhoneNumberType>> GetPhoneNumberTypes()
        {
            return await _personPhoneRepository.GetPhoneNumberTypes();
        }

        public async Task Update(int id, PersonPhone personPhone)
        {
            await _personPhoneRepository.Update(id, personPhone);
        }
    }
}
