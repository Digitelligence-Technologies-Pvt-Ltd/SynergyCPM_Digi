using System.IO;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using SynergyWebServices.BLL;
using SynergyWebServices.BLL.Helpers;
using SynergyWebServices.DAL;
using SynergyWebServices.DEL;
using SynergyWebServices.IAL;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace SynergyWebServices;

public class Startup
{
	public IConfiguration Configuration { get; }

	public Startup(IConfiguration configuration)
	{
		Configuration = configuration;
	}

	public void ConfigureServices(IServiceCollection services)
	{
		services.AddControllersWithViews();
		services.Configure(delegate(CookiePolicyOptions options)
		{
			options.CheckConsentNeeded = (HttpContext context) => true;
			options.MinimumSameSitePolicy = SameSiteMode.None;
		});
     
        ServicePointManager.SecurityProtocol =  SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        services.AddSingleton((IFileProvider)new PhysicalFileProvider(Path.Combine("C:\\DMS", "")));
		services.AddMvc();
		services.AddSwaggerGen(delegate(SwaggerGenOptions c)
		{
			c.SwaggerDoc("v1", new OpenApiInfo
			{
				Title = "Synergy API Services",
				Version = "v1"
			});
		});
		string connection = "Server=localhost;Database=SRKSSynergy;Integrated Security=SSPI;TrustServerCertificate=True;";
		services.AddDbContext<SRKSSynergyContext>(delegate(DbContextOptionsBuilder options)
		{
			options.UseSqlServer(connection);
		});
        services.AddDefaultIdentity<ApplicationUser>()
         .AddRoles<IdentityRole>()
         .AddEntityFrameworkStores<SRKSSynergyContext>();

        services.AddSingleton<IPasswordHasher<ApplicationUser>, SqlPasswordHasher>();
        services.Configure<EmailEntity.SmptSettings>(Configuration.GetSection("SmtpSettings"));
		services.AddCors(delegate(CorsOptions options)
		{
			options.AddPolicy("AllowAllOrigins", delegate(CorsPolicyBuilder builder)
			{
				//builder.WithOrigins("localhost:4200", "localhost:55227");
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
				builder.AllowAnyMethod();
				//builder.AllowCredentials();

            });
		});
		IConfigurationSection appSettingsSection = Configuration.GetSection("AppSettings");
		services.Configure<AppSettings>(appSettingsSection);
		AppSettings appSettings = appSettingsSection.Get<AppSettings>();
		byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret);
		string commonEmailKey = appSettings.CommonEmail;
		string documentEmail = appSettings.DocumentEmail;
		string activateUser = appSettings.ActivateUser;
		services.AddAuthentication(delegate(AuthenticationOptions x)
		{
			x.DefaultAuthenticateScheme = "Bearer";
			x.DefaultChallengeScheme = "Bearer";
		}).AddJwtBearer(delegate(JwtBearerOptions x)
		{
			x.Authority = "https://localhost:55227";
            x.RequireHttpsMetadata = false;
			x.SaveToken = true;
			x.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(key),
				ValidateIssuer = false,
				ValidateAudience = false
			};
            x.Configuration = new OpenIdConnectConfiguration();
        });
		services.AddTransient<IBU, BUBLL>();
		services.AddTransient<ICPEngineer, CPEngineerBLL>();
		services.AddTransient<IMDBMaster, MDBMasterBLL>();
		services.AddTransient<IQuotation, QuotationBLL>();
		services.AddTransient<IVisits, VisitsBLL>();
		services.AddTransient<IVisitPurpose, VisitPurposeBLL>();
		services.AddTransient<ISM, SMBLL>();
		services.AddTransient<IReport, ReportBLL>();
		services.AddTransient<IEmail, EmailBLL>();
		services.AddTransient<IDashboard, DashboardBLL>();
		services.AddTransient<IAccount, AccountBLL>();
	}

	public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
	{
		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
		}
		else
		{
			app.UseExceptionHandler("/Home/Error");
			app.UseHsts();
		}
		app.UseHttpsRedirection();
        app.UseStaticFiles(new StaticFileOptions
        {
            // physical path for the files accessed using /StaticFiles/ token
            FileProvider = new PhysicalFileProvider(Path.Combine("C:\\DMS", "")),

            // This is the relative path from URL
           // RequestPath = "/StaticFiles"
        });
        app.UseCookiePolicy();
		app.UseCors("AllowAllOrigins");
		app.UseSwagger();
		app.UseSwaggerUI(delegate(SwaggerUIOptions c)
		{
			c.SwaggerEndpoint("/swagger/v1/swagger.json", "Synergy API V1");
			c.DefaultModelsExpandDepth(-1);
		});
        app.UseAuthentication();
        app.UseRouting();
		app.UseAuthorization();
		app.UseEndpoints(delegate(IEndpointRouteBuilder endpoints)
		{
			endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
		});
		
		loggerFactory.AddLog4Net();
		IdentityModelEventSource.ShowPII = true;
	}
}
