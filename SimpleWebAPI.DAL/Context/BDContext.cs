using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SimpleWebAPI.Entities;

namespace SimpleWebAPI.DAL.Context
{
    class BDContext : DbContext
    {

        public DbSet<Values> Unidade { get; set; }

        public BDContext()
        : base("MyConnection")
        {
            var a = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
