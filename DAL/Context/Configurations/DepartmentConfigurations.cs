using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context.Configurations;

internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.Property( d=> d.Id).UseIdentityColumn(10,10);
        builder.Property( d=> d.Name).IsRequired(true).HasMaxLength(10).HasColumnType("varChar");
        builder.Property(d => d.Description).IsRequired(true).HasMaxLength(50).HasColumnType("Varchar");
        builder.Property(d => d.Code).IsRequired(true).HasMaxLength(50).HasColumnType("Varchar");
        builder.Property(x => x.CreatedOn).HasDefaultValueSql("GETDATE()");
    }
}
