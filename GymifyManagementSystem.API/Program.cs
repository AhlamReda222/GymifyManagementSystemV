using GymifyManagementSystem.API.Middlewares;
using GymifyManagementSystem.BLL.Managers;
using GymifyManagementSystem.DAL.Database;
using GymifyManagementSystem.DAL.Models;
using GymifyManagementSystem.DAL.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GymifyManagementSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 1. Add services to the container
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // 2. Configure DbContext with SQL Server
            builder.Services.AddDbContext<GymifyContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs")));

            // 3. Configure Identity with ApplicationUser
            builder.Services.AddIdentity<ApplicationUser, IdentityRole<string>>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<GymifyContext>()
            .AddDefaultTokenProviders();

            // 4. Configure JWT Authentication
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });

            // 5. Authorization Middleware
            builder.Services.AddAuthorization();

            // 6. Register your Managers & Repositories
            builder.Services.AddScoped<IAdminManager, AdminManager>();
            builder.Services.AddScoped<IAdminsRepository, AdminsRepository>();

            builder.Services.AddScoped<IArticleManager, ArticleManager>();
            builder.Services.AddScoped<IArticlesRepository, ArticlesRepository>();

            builder.Services.AddScoped<INutritionistManager, NutritionistManager>();
            builder.Services.AddScoped<INutritionistRepository, NutritionistRepository>();

            builder.Services.AddScoped<IOrderManager, OrderManager>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

            builder.Services.AddScoped<IProductManager, Productmanager>();
            builder.Services.AddScoped<IProductsRepository, ProductsRepository>();

            builder.Services.AddScoped<ITrainerManager, TrainerManager>();
            builder.Services.AddScoped<ITrainerRepository, TrainerRepository>();

            builder.Services.AddScoped<IUserManager, UserManager>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            // 7. Register AuthManager with its dependencies
            builder.Services.AddScoped<IAuthManager, AuthManager>();
            builder.Services.AddScoped<RoleManager<IdentityRole<string>>>();


            var app = builder.Build();

            // 8. Middleware pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Exception handling middleware
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            // Authentication & Authorization
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}