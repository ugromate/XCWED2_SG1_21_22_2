using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCWED2_SG1_21_22_2.Logic.Interfaces;
using XCWED2_SG1_21_22_2.Logic.Services;
using XCWED2_SG1_21_22_2.Repository.Infrastructure;

namespace XCWED2_SG1_21_22_2.Logic.Infrastructure
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
