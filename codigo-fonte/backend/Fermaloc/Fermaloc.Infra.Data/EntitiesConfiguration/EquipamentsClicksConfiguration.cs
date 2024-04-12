using Fermaloc.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fermaloc.Infra.Data;

public class EquipamentsClicksConfiguration
{

        public void Configure(EntityTypeBuilder<EquipamentsClicks> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Date).HasColumnType("DATE").IsRequired();
        builder.Property(c => c.NumberOfClicks).HasColumnType("INT").IsRequired();
        builder
            .HasOne(e => e.Equipament)
            .WithMany(e => e.EquipamentsClicks)
            .HasForeignKey(e => e.EquipamentId)
            .OnDelete(DeleteBehavior.Cascade);
    }

}
