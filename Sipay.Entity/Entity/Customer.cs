using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sipay.Core.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sipay.Entity.Entity
{
    [Table("Customer", Schema = "dbo")]
    public class Customer : BaseEntity
    {
        public int CustomerNumber { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }

        public virtual List<Account> Accounts { get; set; }
    }



    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(x => x.CustomerNumber).IsRequired(true).ValueGeneratedNever();
            builder.HasIndex(x => x.CustomerNumber).IsUnique(true);
            builder.HasKey(x => x.CustomerNumber);

            builder.Property(x => x.CreatedUser).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.CreatedDate).IsRequired(true);

            builder.Property(x => x.FirstName).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.IsActive).IsRequired(true).HasDefaultValue(true);
            builder.Property(x => x.Address).IsRequired(true).HasMaxLength(350);

            builder.HasIndex(x => x.CustomerNumber).IsUnique(true);

            builder.HasMany(x => x.Accounts)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerNumber)
                .IsRequired(true);
        }
    }
}