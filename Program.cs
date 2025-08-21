using E_CommerceAPI.Database;
using E_CommerceAPI.Models.Classes;
using E_CommerceAPI.Repository;
using E_CommerceAPI.Services.MappingProfile;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace E_CommerceAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);

            Console.WriteLine($"Environment: {builder.Environment.EnvironmentName} ");

            builder.Services.AddLogging();
            builder.Services.AddControllers();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                };
            });
            builder.Services.AddAuthorization();

            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddIdentity<User, IdentityRole<Guid>>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            builder.Services.AddRouting();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.UseStaticFiles();

            using (IServiceScope scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

                var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();

                string adminEmail = configuration["AdminUser:Email"];
                string adminPassword = configuration["AdminUser:Password"];

                if (!await roleManager.RoleExistsAsync("Admin"))
                    await roleManager.CreateAsync(new IdentityRole<Guid>("Admin"));


                if (!await roleManager.RoleExistsAsync("Customer"))
                    await roleManager.CreateAsync(new IdentityRole<Guid>("Customer"));


                var adminUser = await userManager.FindByEmailAsync(adminEmail);
                if (adminUser == null)
                {
                    User user = new User() { Email = adminEmail, UserName = adminEmail };

                    IdentityResult result = await userManager.CreateAsync(user, adminPassword);
                    if (result.Succeeded)
                        await userManager.AddToRoleAsync(user, "Admin");
                }
            }

            await app.RunAsync();

        }
    }
}


