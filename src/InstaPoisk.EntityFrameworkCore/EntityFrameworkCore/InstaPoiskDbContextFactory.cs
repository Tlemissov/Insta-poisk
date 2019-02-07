using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using InstaPoisk.Configuration;
using InstaPoisk.Web;

namespace InstaPoisk.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class InstaPoiskDbContextFactory : IDesignTimeDbContextFactory<InstaPoiskDbContext>
    {
        public InstaPoiskDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<InstaPoiskDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            InstaPoiskDbContextConfigurer.Configure(builder, configuration.GetConnectionString(InstaPoiskConsts.ConnectionStringName));

            return new InstaPoiskDbContext(builder.Options);
        }
    }
}
