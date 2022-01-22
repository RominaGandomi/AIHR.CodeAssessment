using Workload.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Workload.Data
{
    public class CourcesDbContext : DbContext
    {

        public CourcesDbContext(DbContextOptions<CourcesDbContext> options) : base(options)
        {

        }

        public DbSet<Cource> Cource { get; set; }
        public DbSet<WorkLoadHistory> WorkLoadHistory { get; set; }
        public DbSet<WorkLoadHistoryCource> WorkLoadHistoryCources { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Cource>(ConfigureCource);
            builder.Entity<WorkLoadHistory>(ConfigureWorkLoadHistory);
            builder.Entity<WorkLoadHistoryCource>(ConfigureWorkLoadHistoryCources);
        }
        public void ConfigureCource(EntityTypeBuilder<Cource> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Duration).IsRequired();

        }
        public void ConfigureWorkLoadHistory(EntityTypeBuilder<WorkLoadHistory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();
            builder.Property(x => x.WorkLoad).IsRequired();
        }
        public void ConfigureWorkLoadHistoryCources(EntityTypeBuilder<WorkLoadHistoryCource> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Cource);
            builder.HasOne(x => x.WorkLoadHistory);
        }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
