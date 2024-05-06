using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MindSwap.Domain;
using MindSwap.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MindSwap.Persistence.DatabaseContext
{
    public class MSDatabaseContext : DbContext
    {
        public MSDatabaseContext(DbContextOptions<MSDatabaseContext> options) :base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MSDatabaseContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.DateModified = DateTime.UtcNow;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }    
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
