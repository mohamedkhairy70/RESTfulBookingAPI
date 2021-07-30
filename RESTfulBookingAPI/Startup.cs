using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using RESTfulBookingAPI.interfaces;
using RESTfulBookingAPI.Models;
using System.IO;

namespace RESTfulBookingAPI
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RESTfulBookingAPI", Version = "v1" });
            });

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            services.AddScoped(typeof(IRepository<>), typeof(GUIDRepository<>));


            //Configuration ContextDb and invoke Connection string Using Sql server from  [appsetting.json] file
            services.AddDbContext<BookingContext>
                (cfg =>
                cfg.UseSqlServer(Configuration["ConnectionStrings:BookingContextDb"]));


            // Add a cros
            // Allow request to be serve
            services.AddCors(cfg =>
            {
                cfg.AddPolicy("AllowOrigin", option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });


            // Json Serializer service
            // to keep json serialize to by default
            services.AddControllersWithViews()
                    .AddNewtonsoftJson(option =>
                                option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                    .AddNewtonsoftJson(option =>
                                option.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddRazorPages();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // Add a cros
            // Allow request to be serve
            app.UseCors(option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RESTfulBookingAPI v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute
                ("Default",
                "/{controller}/{action}/{id?}",
                new { controller = "DepartmentEmployee", action = "Index" }
                 );
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "Photos")),
                RequestPath = "/Photos"

            });
        }
    }
}
