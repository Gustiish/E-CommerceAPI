using E_CommerceAPI.Database;
using E_CommerceAPI.Models.Classes;

namespace E_CommerceAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddLogging();
            builder.Services.AddControllers();
            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication();
            builder.Services.AddIdentityCore<User>().AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddRouting();




            var app = builder.Build();


            app.Run();
        }
    }
}


