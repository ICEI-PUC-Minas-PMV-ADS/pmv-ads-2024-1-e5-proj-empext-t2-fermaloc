using Fermaloc.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fermaloc.Infra.Data;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
        builder.Property(c => c.Description).HasMaxLength(300).HasColumnType("TEXT").IsRequired();
        builder
            .HasOne(c => c.Administrator)
            .WithMany(a => a.Categories)
            .HasForeignKey(b => b.AdministratorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
