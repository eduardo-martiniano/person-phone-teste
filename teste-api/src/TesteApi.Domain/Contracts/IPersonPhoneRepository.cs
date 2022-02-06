using System.Collections.Generic;
using System.Threading.Tasks;
using TesteApi.Domain.Entities;

namespace TesteApi.Domain.Contracts
{
    public interface IPersonPhoneRepository
    {
        Task<PersonPhone> Create(PersonPhone personPhone);
        Task<PersonPhone> Get(int id);
        Task<List<PersonPhone>> Get();
        Task Update(int id, PersonPhone personPhone);
        Task Delete(int id);
        Task<List<PhoneNumberType>> GetPhoneNumberTypes();
    }
}
