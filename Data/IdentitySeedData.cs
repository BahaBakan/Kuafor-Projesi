using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KuaforProjesi.Data
{
    public static class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "sau";

        public static async Task IdentityTestUser(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<IdentityContext>();

            // Veritabanını migrate et
            if (context.Database.GetPendingMigrations().Any())
            {
                await context.Database.MigrateAsync();
            }

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Admin rolünü oluştur
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            // Admin kullanıcısını oluştur ve Admin rolüne ata
            var user = await userManager.FindByNameAsync(adminUser);
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = adminUser,
                    Email = "b221210050@sakarya.edu.tr"
                };

                var result = await userManager.CreateAsync(user, adminPassword);
                if (!result.Succeeded)
                {
                    throw new Exception("Admin kullanıcı oluşturulamadı: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }

            if (!await userManager.IsInRoleAsync(user, "Admin"))
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
