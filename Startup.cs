using BookstoreMH;
using BookstoreMH.Authorization;
using BookstoreMH.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var connString = Configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<BookstoreContext>(options => options.UseSqlite(connString!));
        services.AddDefaultIdentity<ApplicationUser>(options =>
                options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<BookstoreContext>();

        services.AddScoped<BookstoreService>();
        services.AddRazorPages();

        services.AddScoped<IAuthorizationHandler, IsBookstoreAdmin>();
        services.AddAuthorizationBuilder()
            .AddPolicy("CanManageBook", p => p.AddRequirements(new IsBookstoreAdminRequirement()));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure the HTTP request pipeline.
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapControllers();
        });
    }
}