using Microsoft.AspNet.Identity.EntityFramework;
using OpenCaller.Web.SQLServer.Conventions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCaller.Web.SQLServer
{
    public sealed class OpenCallerDbContext : IdentityDbContext<IdentityUser>
    {
        public OpenCallerDbContext() : base("OpenCallerConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new DateTime2Convention());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //modelBuilder
            //    .Properties()
            //    .Where(w => w.Name.Equals("Id"))
            //    .Configure(c => c.IsKey());

            base.OnModelCreating(modelBuilder);
        }
    }
}