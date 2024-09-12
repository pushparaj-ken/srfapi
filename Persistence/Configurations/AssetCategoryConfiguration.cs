using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations;

public class AssetCategoryConfiguration : IEntityTypeConfiguration<AssetCategory>
{
    public void Configure(EntityTypeBuilder<AssetCategory> builder)
    {
        builder.HasData(
                new AssetCategory
                {
                    Id = 1,
                    OrgId = 1,
                    Name = "1",
                    CreatedBy = "1",
                    CreatedOn = DateTime.Now,
                    ModifiedBy = "1",
                    ModifiedOn = DateTime.Now,
                });

        builder.Property(q => q.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}
