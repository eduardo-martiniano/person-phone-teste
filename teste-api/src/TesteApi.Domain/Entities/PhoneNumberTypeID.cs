using System.Collections.Generic;

namespace TesteApi.Domain.Entities
{
    public class PhoneNumberType
    {
        public int PhoneNumberTypeID { get; set; }
        public string Name { get; set; }
        public List<PersonPhone> PersonPhones { get; set; }

    }
}
