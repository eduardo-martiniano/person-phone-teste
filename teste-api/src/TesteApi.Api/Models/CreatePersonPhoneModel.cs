using TesteApi.Domain.Entities;

namespace TesteApi.Api.Models
{
    public class CreatePersonPhoneModel
    {
        public string PhoneNumber { get; set; }
        public int PhoneNumberTypeID { get; set; }

        public PersonPhone MapTo()
        {
            return new PersonPhone
            {
                PhoneNumber = PhoneNumber,
                PhoneNumberTypeID = PhoneNumberTypeID
            };
        }
    }
}
