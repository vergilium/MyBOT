using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyBOT.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Localization;
using TelegramAPI;
using ViberAPI;

namespace MyBOT {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {

			services.Configure<TelegramAPI.BotSettings>(Configuration.GetSection(TelegramAPI.BotSettings.botOptions));
			services.AddTelebotService();

			services.Configure<ViberAPI.BotSettings>(Configuration.GetSection(ViberAPI.BotSettings.botOptions));
			services.AddViberbotService();
			
			services.AddLocalization(options => options.ResourcesPath = "Resources");
			services.Configure<RequestLocalizationOptions>(options => {
				var supportedCultures = new[]{
					new CultureInfo("ru"),
					new CultureInfo("ua"),
					new CultureInfo("en")
				};
				options.DefaultRequestCulture = new RequestCulture("en");
				options.SupportedCultures = supportedCultures;
			});
			
			services.AddBotSession();

			services.AddControllers()
				.AddNewtonsoftJson()
				.AddDataAnnotationsLocalization(options => {
					options.DataAnnotationLocalizerProvider = (type, factory) => 
						factory.Create(typeof(SharedResource));
				});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}

			app.UseRequestLocalization();
			app.UseRouting();
			//app.UseAuthorization();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "/api/{controller=Home}/{action=index}/{id?}");
			});
		}
	}
}
