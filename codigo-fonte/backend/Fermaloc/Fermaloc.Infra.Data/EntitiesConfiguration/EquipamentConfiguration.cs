using Fermaloc.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fermaloc.Infra.Data;

public class EquipamentConfiguration : IEntityTypeConfiguration<Equipament>
{
    public void Configure(EntityTypeBuilder<Equipament> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).HasMaxLength(150).IsRequired();
        builder.Property(e => e.Description).HasMaxLength(1000).HasColumnType("TEXT").IsRequired();
        builder.Property(e => e.Image).HasMaxLength(5 * 1024 * 1024).HasColumnType("LONGBLOB").IsRequired();
        builder.Property(e => e.NumberOfClicks).HasColumnType("BIGINT").IsRequired();
        builder
            .HasOne(e => e.Administrator)
            .WithMany(a => a.Equipaments)
            .HasForeignKey(e => e.AdministratorId)
            .OnDelete(DeleteBehavior.Cascade);
        builder
            .HasOne(e => e.Category)
            .WithMany(c => c.Equipaments)
            .HasForeignKey(e => e.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
