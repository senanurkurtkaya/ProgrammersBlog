using AutoMapper;

using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.MVC.AutoMapper.Profiles;
using ProgrammersBlog.MVC.Helpers.Abstract;
using ProgrammersBlog.MVC.Helpers.Concrete;
using ProgrammersBlog.Services.AutoMapper.Profiles;
using ProgrammersBlog.Services.Extensions;
using ProgrammersBlog.Shared.Utilities.Extensions;

using System.Configuration;

namespace ProgrammersBlog.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add builder.Services to the container.
            builder.Services.AddControllersWithViews();

            var connectionString = builder.Configuration.GetConnectionString("Default");
            builder.Services.AddTransient<IImageHelper, ImageHelper>();
            builder.Services.AddSingleton(provider => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserProfile(provider.GetService<IImageHelper>()));
                cfg.AddProfile(new UserProfile(provider.GetService<IImageHelper>()));
                cfg.AddProfile(new CategoryProfile());
                cfg.AddProfile(new ArticleProfile());
                cfg.AddProfile(new ViewModelsProfile());
                cfg.AddProfile(new CommentProfile());
            }).CreateMapper());

            builder.Services.Configure<AboutUsPageInfo>(builder.Configuration.GetSection("AboutUsPageInfo"));
            builder.Services.Configure<WebsiteInfo>(builder.Configuration.GetSection("WebsiteInfo"));
            builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
            builder.Services.Configure<ArticleRightSideBarWidgetOptions>(builder.Configuration.GetSection("ArticleRightSideBarWidgetOptions"));

            builder.Services.Configure<AboutUsPageInfo>(builder.Configuration.GetSection("AboutUsPageInfo"));
            builder.Services.Configure<WebsiteInfo>(builder.Configuration.GetSection("WebsiteInfo"));
            builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
            builder.Services.Configure<ArticleRightSideBarWidgetOptions>(builder.Configuration.GetSection("ArticleRightSideBarWidgetOptions"));


            builder.Services.LoadMyServices(connectionString);
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Admin/Auth/Login");
                options.LogoutPath = new PathString("/Admin/Auth/Logout");
                options.Cookie = new CookieBuilder
                {
                    Name = "ProgrammersBlog",
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict,
                    SecurePolicy = CookieSecurePolicy.SameAsRequest // Always
                };
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = System.TimeSpan.FromDays(7);
                options.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");
            });

            builder.Services.AddMvc().AddNToastNotifyToastr();

            var app = builder.Build();

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "article",
                    pattern: "{title}/{articleId}",
                    defaults: new { controller = "Article", action = "Detail" }
                    );
                endpoints.MapDefaultControllerRoute();
            });

            app.MapRazorPages();

            app.Run();
        }
    }
}
