using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCWED2_HFT_2021221.Logic.Interfaces;
using XCWED2_HFT_2021221.Logic.Services;
using XCWED2_HFT_2021221.Repository.Infrastructure;

namespace XCWED2_HFT_2021221.Logic.Infrastructure
{
   public class BLInitialization
    {
        public static void InitBlServices(IServiceCollection services)
        {
            RepoInitialization.InitRepoServices(services);

            services.AddScoped<IBoardGameLogic, BoardGameLogic>();
            services.AddScoped<IPublisherLogic, PublisherLogic>();
            services.AddScoped<IDesignerLogic, DesignerLogic>(); 
        }
    }
}
