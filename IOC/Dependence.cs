using BLL.Implementation;
using BLL.Interfaces;
using DAL.Implementation;
using DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IOC
{
    public static class Dependence
    {
        public static void InjectDependency(this IServiceCollection services, IConfiguration Configuration)
        {
            //services.AddDbContext<BarberiaContext>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("CadenaSql"));
            //});

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddSingleton<IUsuarioService, UsuarioService>();

        }
    }
}
