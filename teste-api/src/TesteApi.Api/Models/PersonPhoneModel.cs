using TesteApi.Domain.Entities;

namespace TesteApi.Api.Models
{
    public class PersonPhoneModel
    {
        public int BusinessEntityID { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneNumberTypeID { get; set; }
        public string PhoneNumberTypeName { get; set; }
        
        public PersonPhoneModel(PersonPhone personPhone)
        {
            BusinessEntityID = personPhone.BusinessEntityID;
            PhoneNumber = personPhone.PhoneNumber;
            PhoneNumberTypeID = personPhone.PhoneNumberType.PhoneNumberTypeID;
            PhoneNumberTypeName = personPhone.PhoneNumberType.Name;
        }
    }
}
