using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCWED2_SG1_21_22_2.Repository.DbContexts;
using XCWED2_SG1_21_22_2.Repository.Interfaces;
using XCWED2_SG1_21_22_2.Repository.Repositories;

namespace XCWED2_SG1_21_22_2.Repository.Infrastructure
{
   public class RepoInitialization
    {
        public static void InitRepoServices(IServiceCollection services)
        {
            services.AddScoped<XCWED2_SG1_21_22_2DbContext>((sp) => new XCWED2_SG1_21_22_2DbContext());
            services.AddScoped<IBoardGameRepository, BoardGameRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IDesignerRepository, DesignerRepository>();
        }
    }
}
