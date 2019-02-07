using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using InstaPoisk.Authorization.Roles;
using InstaPoisk.Authorization.Users;
using InstaPoisk.MultiTenancy;

namespace InstaPoisk.EntityFrameworkCore
{
    public class InstaPoiskDbContext : AbpZeroDbContext<Tenant, Role, User, InstaPoiskDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public InstaPoiskDbContext(DbContextOptions<InstaPoiskDbContext> options)
            : base(options)
        {
        }
    }
}
