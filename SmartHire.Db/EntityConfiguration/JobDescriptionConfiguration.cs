using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHire.Db.Entities;

namespace SmartHire.Db.EntityConfiguration
{
    public class JobDescriptionConfiguration : IEntityTypeConfiguration<JobDescription>
    {
        public void Configure(EntityTypeBuilder<JobDescription> builder)
        {
            builder.HasKey(x => x.RequisitionId);
        }
    }
}
