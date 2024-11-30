namespace Library_DEPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            // add connection 
            builder.Services.AddDbContext<AppDBContext>(option => option.UseSqlServer(
                builder.Configuration.GetConnectionString("Con")
              ));

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDBContext>();

            builder.Services.AddTransient<IAuthorServices, AuthorServices>();
            builder.Services.AddTransient<IGenreServices, GenreServices>();
            builder.Services.AddTransient<IPenaltyServices, PenaltyServices>();
            builder.Services.AddTransient<IBookServices, BookServices>();
            builder.Services.AddTransient<ICheckoutServices, CheckoutServices>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.

                //HTTP Strict Transport Security (HSTS) , man in the middle 
                app.UseHsts();
            }


            // http -> https 
            app.UseHttpsRedirection();

            // static files css, js, images
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Routing Pattern
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.UseEndpoints(endpoints => endpoints.MapRazorPages());

            app.Run();
        }
    }
}
