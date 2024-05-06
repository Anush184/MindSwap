using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MindSwap.Identity.Moduls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Identity.DbContext
{
    public class MindSwapIdentityDbContext: IdentityDbContext<ApplicationUser>
    {
        public MindSwapIdentityDbContext(DbContextOptions<MindSwapIdentityDbContext> options):
            base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(MindSwapIdentityDbContext).Assembly);
        }

    }
}
