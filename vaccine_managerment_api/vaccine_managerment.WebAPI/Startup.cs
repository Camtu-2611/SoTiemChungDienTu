using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vaccine_managerment.core;
using vaccine_managerment.infrastructure;

namespace vaccine_managerment.WebAPI
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
            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "vaccine_managerment.WebAPI", Version = "v1" });
            });
            //Dependency Injection
            services.AddScoped(typeof(IBaseBL<>), typeof(BaseBL<>));
            services.AddScoped(typeof(IBaseDL<>), typeof(BaseDL<>));

            // Loai vacxin
            services.AddScoped<ILoaiVacxinDL, LoaiVacxinDL>();
            services.AddScoped<ILoaiVacxinBL, LoaiVacxinBL>();

            // vacxin
            services.AddScoped<IVacxinDL, VacxinDL>();
            services.AddScoped<IVacxinBL, VacxinBL>();

            // sotiem
            services.AddScoped<ISoTiemDL, SoTiemDL>();
            services.AddScoped<ISoTiemBL, SoTiemBL>();

            // ct sotiem
            services.AddScoped<ICTSoTiemDL, CTSoTiemDL>();
            services.AddScoped<ICTSoTiemBL, CTSoTiemBL>();

            // lichtiem
            services.AddScoped<ILichTiemDL, LichTiemDL>();
            services.AddScoped<ILichTiemBL, LichTiemBL>();

            // nhanvienyte
            services.AddScoped<INhanVienYTeDL, NhanVienYTeDL>();
            services.AddScoped<INhanVienYTeBL, NhanVienYTeBL>();

            // thongtindangkytiem
            services.AddScoped<IThongTinDangKyTiemDL, ThongTinDangKyTiemDL>();
            services.AddScoped<IThongTinDangKyTiemBL, ThongTinDangKyTiemBL>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "vaccine_managerment.WebAPI v1"));
            }
            // sử dụng cors
            app.UseCors(x =>
            x.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetPreflightMaxAge(TimeSpan.FromMinutes(10))
            );
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
