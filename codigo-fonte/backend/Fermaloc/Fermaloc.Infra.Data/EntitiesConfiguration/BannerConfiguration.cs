using Fermaloc.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fermaloc.Infra.Data;

public class BannerConfiguration : IEntityTypeConfiguration<Banner>
{
    public void Configure(EntityTypeBuilder<Banner> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(e => e.Image).HasMaxLength(25 * 1024 * 1024).HasColumnType("LONGBLOB").IsRequired();
        builder
            .HasOne(b => b.Administrator)
            .WithMany(a => a.Banners)
            .HasForeignKey(b => b.AdministratorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
