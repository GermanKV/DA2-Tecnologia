using BusinessLogic;
using BusinessLogicInterface;
using DataAccess;
using DataAccessInterface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SessionInterface;

namespace Factory
{
    public class ServiceFactory
    {
        private readonly IServiceCollection services;

        public ServiceFactory(IServiceCollection services)
        {
            this.services = services;
        }

        public void AddCustomServices()
        {
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieLogic, MovieLogic>();
            services.AddScoped<ISessionLogic, SessionLogic>();
            services.AddScoped<IImporterLogic, ImporterLogic>();
        }

        public void AddDbContextService()
        {
            services.AddDbContext<DbContext, VidlyContext>(); 
        }
    }
}