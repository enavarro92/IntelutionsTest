using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Intelutions.Entities.Confidencialidad;

namespace Intelutions.Data.Mapping.Confidencialidad
{
    public class PermisoMap : IEntityTypeConfiguration<Permiso>
    {
        public void Configure(EntityTypeBuilder<Permiso> builder)
        {
            builder.ToTable("Permiso")
                .HasKey(c => c.Id);
        }
    }
}
