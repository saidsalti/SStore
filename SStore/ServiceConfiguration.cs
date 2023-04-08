using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MudBlazor.Services;
using SStore.Data;
using SStore.Helpers;
using SStore.Model.Data;
using SStore.Services;

namespace SStore
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AppServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDistributedMemoryCache();
            services.AddHttpContextAccessor();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddMudServices();
            services.AddTransient<ICounterServicecs, CounterServicecs>();
            services.AddTransient<IAppUserService, AppUserService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IAppSnackbarService, AppSnackbarService>();
            services.AddTransient<IAppStorgeService, AppStorgeService>();
            services.AddTransient<IImageHelper, ImageHelper>();
           // services.AddScoped<IGlobalDataService, GlobalDataService>();
            services.AddAuthentication();
            
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("StoreConnection"));
            });
            // Mud Blazor Options 
            services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomLeft;

                config.SnackbarConfiguration.PreventDuplicates = false;
                config.SnackbarConfiguration.NewestOnTop = false;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.VisibleStateDuration = 10000;
                config.SnackbarConfiguration.HideTransitionDuration = 500;
                config.SnackbarConfiguration.ShowTransitionDuration = 500;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
            });

            return services;
        }
    }
}
