using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCaller.Web.SQLServer
{
    public static class OpenCallerDbContextInitializer
    {
        public static void ConfigureInitializer()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OpenCallerDbContext, Migrations.Configuration>());
        }
    }
}
