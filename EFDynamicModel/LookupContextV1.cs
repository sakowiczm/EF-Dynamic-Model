using System.Data.Entity;

namespace EFDynamicModel
{
    public class LookupContextV1 : DbContext
    {
        private readonly string _tableName;

        public LookupContextV1(string tableName)
            : base("cn")
        {
            _tableName = tableName;
        }

        public DbSet<LookupItem> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LookupItem>().Property(c => c.Id).HasColumnName("id");
            modelBuilder.Entity<LookupItem>().Property(c => c.Code).HasColumnName("code");
            modelBuilder.Entity<LookupItem>().Property(c => c.Description).HasColumnName("description");
            modelBuilder.Entity<LookupItem>().HasKey(c => c.Id);

            modelBuilder.Entity<LookupItem>().ToTable(_tableName);
        }
    }
}