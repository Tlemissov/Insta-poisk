using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using InstaPoisk.Authorization.Roles;
using InstaPoisk.Authorization.Users;
using InstaPoisk.MultiTenancy;
using InstaPoisk.References;

namespace InstaPoisk.EntityFrameworkCore
{
    public class InstaPoiskDbContext : AbpZeroDbContext<Tenant, Role, User, InstaPoiskDbContext>
    {
        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<SubCategory> SubCategories { get; set; }

        public virtual DbSet<SubCategoryType> SubCategoryTypes { get; set; }
        
        public InstaPoiskDbContext(DbContextOptions<InstaPoiskDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SubCategoryToType>()
                .HasKey(bc => new { bc.SubCategorId, bc.TypeId });
            modelBuilder.Entity<SubCategoryToType>()
                .HasOne(bc => bc.SubCategory)
                .WithMany(b => b.SubCategoryToTypes)
                .HasForeignKey(bc => bc.SubCategorId);
            modelBuilder.Entity<SubCategoryToType>()
                .HasOne(bc => bc.Type)
                .WithMany(c => c.SubCategoryToTypes)
                .HasForeignKey(bc => bc.TypeId);
        }
    }
}
