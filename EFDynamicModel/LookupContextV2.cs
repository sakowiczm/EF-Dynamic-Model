using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace EFDynamicModel
{
    public class LookupContextV2 : DbContext
    {
        public LookupContextV2(DbCompiledModel model)
            : base("cn", model)
        {

        }

        public DbSet<LookupItem> Items { get; set; }
    }
}