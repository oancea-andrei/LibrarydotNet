using LibraryManagement.Core.Services;
using LibraryManagement.Database.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.Core.Extensions
{
    public static class ServicesExtension
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<AuthorService, AuthorService>();
            services.AddScoped<AuthorRepository, AuthorRepository>();

            services.AddScoped<BookService, BookService>();
            services.AddScoped<BookRepository, BookRepository>();

            services.AddScoped<AuthenticationService, AuthenticationService>();

            services.AddScoped<RoleService, RoleService>();
            services.AddScoped<RoleRepository, RoleRepository>();

            services.AddScoped<UserService, UserService>();
            services.AddScoped<UserRepository, UserRepository>();
        }

    }
}
