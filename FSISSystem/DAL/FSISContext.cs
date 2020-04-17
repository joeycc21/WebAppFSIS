using System.Data.Entity;
using FSISSystem.ENTITIES;

namespace FSISSystem.DAL
{
    internal class FSISContext: DbContext
    {
        public FSISContext() : base("FSIS_db")
        {

        }
        public DbSet<Team> Teams { get; set; }

    }
}
