using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestAppJulia.Services.StationService;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TestAppJulia.Services.PassageService;
using TestAppJulia.Services.TrainService;
using TestAppJulia.Services.UserService;

namespace TestAppJulia
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddDbContext<DatabaseContext>(
                options =>
                    options.UseNpgsql(Configuration["Data:DatabaseConnection:ConnectionString"],
                        o => o.MigrationsAssembly("TestAppJulia")));


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddScoped<StationService>();
            services.AddScoped<PassageService>();
            services.AddScoped<TrainService>();
            services.AddScoped<UserService>();

            services.AddMvc();
        }

        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
