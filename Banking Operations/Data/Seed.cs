using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using System.Net;

namespace Banking_Operations.Data
{
    public class Seed
    {
        public static async Task SeedUsers(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (roleManager.Roles.Count() == 0)
                {
                    if (!await roleManager.RoleExistsAsync(ClientRoles.Admin))
                        await roleManager.CreateAsync(new IdentityRole(ClientRoles.Admin));
                    if (!await roleManager.RoleExistsAsync(ClientRoles.User))
                        await roleManager.CreateAsync(new IdentityRole(ClientRoles.User));
                }
                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<Client>>();
                if (userManager.Users.Count() == 0)
                {
                    string adminUserEmail = "AdminName@gmail.com";

                    var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                    if (adminUser == null)
                    {
                        var newAdminUser = new Client()
                        {
                            UserName = "admin",
                            Email = adminUserEmail,
                            EmailConfirmed = true,
                            Passport = 0,
                            Adress = null,
                            Services = new List<BankService>
                            {
                            new BankService()
                            {
                                BankServiceName = "Денежный перевод",
                                TermOfRendering = "2022/07/14",
                                ComissionType = "Fixed Price",
                                Debt = 0,
                                BankServiceStatus = true
                            }
                        }
                    };
                        await userManager.CreateAsync(newAdminUser, "Admin12345!");
                        await userManager.AddToRoleAsync(newAdminUser, ClientRoles.Admin);
                    }

                    var context = serviceScope.ServiceProvider.GetService<ApplicationDBContext>();

                    context.Database.EnsureCreated();

                    if (!context.BankServices.Any())
                    {
                        context.BankServices.AddRange(new List<BankService>()
                    {
                        new BankService()
                        {
                            BankServiceName = "Денежный перевод",
                            TermOfRendering = "2022/07/14",
                            ComissionType = "Fixed Price",
                            Debt = 0,
                            BankServiceStatus = true
                        }
                    }); ;
                    }
                    context.SaveChanges();

                    string appUserEmail = "UserName@gmail.com";

                    var appUser = await userManager.FindByEmailAsync(appUserEmail);
                    if (appUser == null)
                    {
                        var newAppUser = new Client()
                        {
                            UserName = "userX",
                            Email = appUserEmail,
                            EmailConfirmed = true,
                            Passport = 0000111111,
                            Adress = null
                        };
                        await userManager.CreateAsync(newAppUser, "Qwerty12345!");
                        await userManager.AddToRoleAsync(newAppUser, ClientRoles.User);
                    }
                }
            }
        }
    }
}
