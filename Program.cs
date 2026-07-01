using ECommerceSystemBl;
using ECommerceSystemBl.Components;
using ECommerceSystemBl.Repositories;
using ECommerceSystemBl.Services;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using Microsoft.AspNetCore.Components.Authorization;

namespace ECommerceSystemBl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddMudServices();


            builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddScoped<ProductRepository>();
            builder.Services.AddScoped<CategoryRepository>();
            builder.Services.AddScoped<UserRepository>();
            builder.Services.AddScoped<OrderRepository>();
            builder.Services.AddScoped<ReviewRepository>();
            builder.Services.AddScoped<OrderProductsRepository>();

            builder.Services.AddScoped<ProductService>();
            builder.Services.AddSingleton<CartService>();
            builder.Services.AddScoped<CategoryService>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<OrderService>();
            builder.Services.AddScoped<ReviewService>();
            builder.Services.AddScoped<OrderProductsService>();

            builder.Services.AddScoped<PasswordService>();
            builder.Services.AddScoped<JwtService>();
            builder.Services.AddScoped<EmailService>();
            builder.Services.AddAuthorizationCore();

            builder.Services.AddScoped<CustomAuthenticationStateProvider>();

            builder.Services.AddScoped<AuthenticationStateProvider>(sp =>
                sp.GetRequiredService<CustomAuthenticationStateProvider>());


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
