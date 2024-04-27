using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MindSwap.Application.Contracts.Persistence;
using MindSwap.Persistence.DatabaseContext;
using MindSwap.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSwap.Persistence
{

    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<MSDatabaseContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MSConnectionString"));
            });
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}