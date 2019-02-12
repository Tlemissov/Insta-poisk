using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace InstaPoisk.EntityFrameworkCore
{
    public static class InstaPoiskDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<InstaPoiskDbContext> builder, string connectionString)
        {
            builder.UseLazyLoadingProxies();
            builder.UseNpgsql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<InstaPoiskDbContext> builder, DbConnection connection)
        {
            builder.UseNpgsql(connection);
        }
    }
}
