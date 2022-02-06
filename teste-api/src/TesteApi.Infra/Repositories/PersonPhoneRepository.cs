using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteApi.Domain.Contracts;
using TesteApi.Domain.Entities;

namespace TesteApi.Infra.Repositories
{
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly Context _context;

        public PersonPhoneRepository(Context context)
        {
            _context = context;
        }

        public async Task<PersonPhone> Create(PersonPhone personPhone)
        {
            await _context.PersonPhones.AddAsync(personPhone);
            await _context.SaveChangesAsync();
            return personPhone;
        }

        public async Task Delete(int id)
        {
            var personPhone = await Get(id);
            _context.Remove(personPhone);
            await _context.SaveChangesAsync();
        }

        public async Task<PersonPhone> Get(int id)
        {
            return await _context.PersonPhones
                .Include(pp => pp.PhoneNumberType)
                .Where(pp => pp.BusinessEntityID == id)
                .FirstOrDefaultAsync();
        }

        public async Task<List<PersonPhone>> Get()
        {
            return await _context.PersonPhones
                .Include(pp => pp.PhoneNumberType)
                .ToListAsync();
        }

        public async Task Update(int id, PersonPhone personPhone)
        {
            personPhone.BusinessEntityID = id;
            _context.Entry(await Get(id)).CurrentValues.SetValues(personPhone);
            await _context.SaveChangesAsync();
        }

    }
}
