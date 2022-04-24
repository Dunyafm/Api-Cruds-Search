using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DomainLayer.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(m => m.FullName).IsRequired().HasMaxLength(200);
            builder.Property(m => m.Age).IsRequired();
            builder.Property(m => m.Address).IsRequired(false).HasMaxLength(300);
            builder.Property(m => m.CreatedDate).HasDefaultValue(DateTime.Now);
            builder.Property(m => m.SoftDelete).HasDefaultValue(false);
            builder.HasQueryFilter(m => !m.SoftDelete);
        }
    }
}
