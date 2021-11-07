using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCWED2_HFT_2021221.Repository.DbContexts;
using XCWED2_HFT_2021221.Repository.Interfaces;
using XCWED2_HFT_2021221.Repository.Repositories;

namespace XCWED2_HFT_2021221.Repository.Infrastructure
{
   public class RepoInitialization
    {
        public static void InitRepoServices(IServiceCollection services)
        {
            services.AddScoped<XCWED2_HFT_2021221DbContext>((sp) => new XCWED2_HFT_2021221DbContext());
            services.AddScoped<IBoardGameRepository, BoardGameRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IDesignerRepository, DesignerRepository>();
        }
    }
}
