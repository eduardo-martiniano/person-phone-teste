using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteApi.Domain.Entities;

namespace TesteApi.Infra.Mappings
{
    public class PersonPhoneMapping : IEntityTypeConfiguration<PersonPhone>
    {
        public void Configure(EntityTypeBuilder<PersonPhone> builder)
        {
            builder.ToTable("PersonPhones");

            builder.HasKey(p => p.BusinessEntityID);

            builder.Property(p => p.PhoneNumber)
                .IsRequired();

            builder.HasOne<PhoneNumberType>(p => p.PhoneNumberType)
                .WithMany(t => t.PersonPhones)
                .HasForeignKey(p => p.PhoneNumberTypeID);
        }
    }
}
