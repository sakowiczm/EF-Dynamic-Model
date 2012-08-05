using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;

namespace EFDynamicModel
{
    [DbModelBuilderVersion(DbModelBuilderVersion.V4_1)]
    public class LookupModel : DbModelBuilder
    {
        public LookupModel()
        {
            Configurations.Add(new EntityTypeConfiguration<LookupItem>());

            Entity<LookupItem>().Property(c => c.Id).HasColumnName("id");
            Entity<LookupItem>().Property(c => c.Code).HasColumnName("code");
            Entity<LookupItem>().Property(c => c.Description).HasColumnName("description");
            Entity<LookupItem>().HasKey(c => c.Id);                
        }

        public DbCompiledModel Compile(string tableName)
        {
            Entity<LookupItem>().ToTable(tableName);

            return Build(new DbProviderInfo("System.Data.SqlClient", "2008")).Compile();
        }
    }
}