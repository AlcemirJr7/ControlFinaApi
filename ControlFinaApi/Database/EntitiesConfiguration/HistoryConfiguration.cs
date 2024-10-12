using ControlFinaApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlFinaApi.Database.EntitiesConfiguration
{
    public class HistoryConfiguration : IEntityTypeConfiguration<History>
    {
        public void Configure(EntityTypeBuilder<History> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(h => h.Description)
                   .IsRequired()
                   .HasColumnType("varchar")
                   .HasMaxLength(200);

            builder.Property(h => h.Type)
                   .IsRequired();

            
        }
    }
}
