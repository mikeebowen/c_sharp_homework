using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CookbookDB
{
    public partial class CookbookContext : DbContext
    {
        public CookbookContext()
        {
        }

        public CookbookContext(DbContextOptions<CookbookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ingredient> Ingredient { get; set; }
        public virtual DbSet<Recipe> Recipe { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=Cookbook;integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Ingredient)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ingredien__Recip__1273C1CD");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
