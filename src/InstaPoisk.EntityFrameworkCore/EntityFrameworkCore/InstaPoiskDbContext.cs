using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using InstaPoisk.Authorization.Roles;
using InstaPoisk.Authorization.Users;
using InstaPoisk.InstaAccounts;
using InstaPoisk.MultiTenancy;
using InstaPoisk.References;

namespace InstaPoisk.EntityFrameworkCore
{
    public class InstaPoiskDbContext : AbpZeroDbContext<Tenant, Role, User, InstaPoiskDbContext>
    {
        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<SubCategory> SubCategories { get; set; }

        public virtual DbSet<SubCategoryType> SubCategoryTypes { get; set; }

        public virtual DbSet<InstaAccount> InstaAccounts { get; set; }
        
        public InstaPoiskDbContext(DbContextOptions<InstaPoiskDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SubCategoryToType>()
                .HasKey(ct => new { ct.SubCategorId, ct.TypeId });
            modelBuilder.Entity<SubCategoryToType>()
                .HasOne(ct => ct.SubCategory)
                .WithMany(c => c.SubCategoryToTypes)
                .HasForeignKey(ct => ct.SubCategorId);
            modelBuilder.Entity<SubCategoryToType>()
                .HasOne(ct => ct.Type)
                .WithMany(t => t.SubCategoryToTypes)
                .HasForeignKey(ct => ct.TypeId);

            modelBuilder.Entity<InstaAccountToSubCategory>()
                .HasKey(ac => new { ac.AccountId, ac.CategoryId });
            modelBuilder.Entity<InstaAccountToSubCategory>()
                .HasOne(ac => ac.Account)
                .WithMany(a => a.SubCategories)
                .HasForeignKey(ac => ac.AccountId);
            modelBuilder.Entity<InstaAccountToSubCategory>()
                .HasOne(ac => ac.Category)
                .WithMany(c => c.InstaAccounts)
                .HasForeignKey(ac => ac.CategoryId);
        }
    }
}
