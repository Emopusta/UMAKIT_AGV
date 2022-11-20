using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class StreamImageConfiguration : IEntityTypeConfiguration<StreamImage>
    {
        public void Configure(EntityTypeBuilder<StreamImage> builder)
        {
            builder.ToTable("StreamImages").HasKey(k => k.Id);
            builder.Property(p => p.VehicleId).HasColumnName("VehicleId");
            builder.Property(p => p.Path).HasColumnName("Path");
        }
    }
}
