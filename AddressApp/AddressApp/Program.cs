using Microsoft.EntityFrameworkCore;
using AddressApp.EFRepository;
using SimpleInjector;
using SimpleInjector.Lifestyles;


namespace AddressApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			builder.Services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")));

			//Simple Injector
			var container = new Container();

			container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();

			container.RegisterPackages(new[] { typeof(Registrations).Assembly });

			builder.Services.AddSimpleInjector(container, options =>
			{
				options.AddAspNetCore()
				.AddControllerActivation()
				.AddViewComponentActivation();
			});

			var app = builder.Build();
			app.Services.UseSimpleInjector(container);

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Contacts}/{action=Index}/{id?}");

			app.Run();
		}
	}
}