using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity; //inheritance of DbContext from EntityFramework
using DBSystem.ENTITIES;

namespace DBSystem.DAL
{
    internal class Context : DbContext
    {
        public Context() : base("StarTED_db")
        {

        }
        public DbSet<Country> Country { get; set; }
        public DbSet<Student> Student { get; set; }
        
    }
}
