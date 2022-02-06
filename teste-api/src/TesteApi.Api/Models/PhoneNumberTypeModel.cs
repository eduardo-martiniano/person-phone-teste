using TesteApi.Domain.Entities;

namespace TesteApi.Api.Models
{
    public class PhoneNumberTypeModel
    {
        public int PhoneNumberTypeID { get; set; }
        public string Name { get; set; }

        public PhoneNumberTypeModel(PhoneNumberType type)
        {
            PhoneNumberTypeID = type.PhoneNumberTypeID;
            Name = type.Name;
        }
    }
}
