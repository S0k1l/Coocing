using Coocing.Models;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace Coocing.Data
{
    public class Seed
    {
        public static async Task SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                //var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                //if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                //    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                //if (!await roleManager.RoleExistsAsync(UserRoles.User))
                //    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string UserMail = "mymail@email.com";

                //var adminUser = await userManager.FindByEmailAsync(UserMail);
                //if (adminUser == null)
                //{
                //    var newAdminUser = new AppUser()
                //    {
                //        UserName = "Yurii",
                //        Email = "123@email.com",
                //    };
                //    await userManager.CreateAsync(newAdminUser, "A1123@email.com");
                //    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                //}


                //FirstUser
                string firstUserMail = "zxc@email.com";
                var firstUser = await userManager.FindByEmailAsync(firstUserMail);
                var newfirstUser = new AppUser()
                {
                    UserName = "Yurii",
                    Email = "zxc@email.com",
                };
                if (firstUser == null)
                {
                    await userManager.CreateAsync(newfirstUser, "A1123@email.com");
                    await userManager.AddToRoleAsync(newfirstUser, UserRoles.User);
                }


                string secondUserMail = "asd@email.com";
                var secondUser = await userManager.FindByEmailAsync(secondUserMail);
                var newsecondUser = new AppUser()
                {
                    UserName = "Yurii",
                    Email = "asd@email.com",
                };
                if (secondUser == null)
                {
                    await userManager.CreateAsync(newsecondUser, "A1123@email.com");
                    await userManager.AddToRoleAsync(newsecondUser, UserRoles.User);
                }

                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                //context.Database.EnsureCreated();

                if (context.CourseRecipes.Any())
                {
                    context.CourseRecipes.Add(

                        new CourseRecipes
                        {
                            Course = new Course {
                                Name = "Як приготувати смачні вареники",
                                DateTime = new DateTime(1, 1, 1, 1, 15, 0),
                                Description = "Р результаті вийдуть дуже смачні вареники",
                                UserCourses = new List<UserCourses>()
                                {
                                    new UserCourses
                                    {
                                        AppUser = newsecondUser,
                                    }
                                }
                            },
                            Recipes = new Recipes
                            {
                                Name = "Вареники",
                                Description = "Рецепт вареників",
                                ImageUrl = "https://cdn1.ozonusercontent.com/s3/club-storage/images/article_image_1632x1000/68/f5417e4f-70d5-4c8e-891c-591448bc5cfa.jpeg",
                                Coments = new List<Coments>()
                                {
                                    new Coments
                                    {
                                        AppUser= newfirstUser,
                                        Description = "Дуже смачна, дякую."
                                    },
                                    new Coments
                                    {
                                        AppUser= newsecondUser,
                                        Description = "Нвгодувала всю ролдину."
                                    }
                                }
                            }

                        });
                    context.Recipes.Add(new Recipes
                    {
                        Name = "Холодець",
                        Description = "Рецепт драглів\n ",
                        ImageUrl = "https://ukr.media/static/ba/aimg/4/0/1/401712_1.jpg",
                        Coments = new List<Coments>()
                                {
                                    new Coments
                                    {
                                        AppUser= newfirstUser,
                                        Description = "Супер!!!"
                                    },
                                }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
