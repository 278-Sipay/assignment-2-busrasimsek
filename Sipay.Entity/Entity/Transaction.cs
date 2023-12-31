﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sipay.Core.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sipay.Entity.Entity
{
    [Table("Transaction", Schema = "dbo")]
    public class Transaction : BaseEntity
    {
        public int AccountNumber { get; set; }
        public virtual Account Account { get; set; }
        public decimal CreditAmount { get; set; }
        public decimal DebitAmount { get; set; }
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }
        public string ReferenceNumber { get; set; }
    }


    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {

            builder.Property(x => x.Id).IsRequired(true).UseIdentityColumn();
            builder.Property(x => x.CreatedDate).IsRequired(true).HasMaxLength(50);
            builder.Property(x => x.CreatedUser).IsRequired(true);
            builder.Property(x => x.TransactionDate).IsRequired(true);
            builder.Property(x => x.ReferenceNumber).IsRequired(true);
            builder.Property(x => x.AccountNumber).IsRequired(true);
            builder.Property(x => x.CreditAmount).IsRequired(true).HasPrecision(15, 4).HasDefaultValue(0);
            builder.Property(x => x.DebitAmount).IsRequired(true).HasPrecision(15, 4).HasMaxLength(0);
            builder.Property(x => x.Description).IsRequired(true).HasMaxLength(250);

        }
    }
}

