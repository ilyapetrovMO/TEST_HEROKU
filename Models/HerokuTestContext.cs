using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HerokuTest.Models
{
    public partial class HerokuTestContext : DbContext
    {
        public HerokuTestContext()
        {
        }

        public HerokuTestContext(DbContextOptions<HerokuTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contracts> Contracts { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contracts>(entity =>
            {
                entity.HasKey(e => e.ContractId);

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_DATE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.SecondName).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
