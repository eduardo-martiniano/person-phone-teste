namespace TesteApi.Domain.Entities
{
    public class PersonPhone
    {
        public int BusinessEntityID { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneNumberTypeID { get; set; }
        public PhoneNumberType PhoneNumberType { get; set; }
    }
}
