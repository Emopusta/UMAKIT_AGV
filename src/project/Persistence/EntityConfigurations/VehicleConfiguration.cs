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
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicles").HasKey(k => k.Id);
            builder.Property(p => p.Name).HasColumnName("Name");
            builder.Property(p => p.BatteryPercentage).HasColumnName("BatteryPercentage");
            builder.Property(p => p.Velocity).HasColumnName("Velocity");
            builder.Property(p => p.StatusId).HasColumnName("StatusId");
        }
    }
}
