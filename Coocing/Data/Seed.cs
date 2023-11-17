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
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string UserMail = "mymail@email.com";

                var adminUser = await userManager.FindByEmailAsync(UserMail);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser()
                    {
                        UserName = "Yurii",
                        Email = "123@email.com",
                    };
                    await userManager.CreateAsync(newAdminUser, "A1123@email.com");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                //FirstUser
                string firstUserMail = "321@email.com";

                var newfirstUser = new AppUser()
                {
                    UserName = "Oleg",
                    Email = "@email.com",
                };

                var firstUser = await userManager.FindByEmailAsync(firstUserMail);
                if (firstUser == null)
                {
 
                    await userManager.CreateAsync(newfirstUser, "A1123@email.com");
                    await userManager.AddToRoleAsync(newfirstUser, UserRoles.User);
                }

                //SecondUser
                string secondUserMail = "qwe@email.com";

                var newSecondUser = new AppUser()
                {
                    UserName = "Olya",
                    Email = "qwe@email.com",
                };

                var secondUser = await userManager.FindByEmailAsync(secondUserMail);
                if (secondUser == null)
                {
                    await userManager.CreateAsync(newSecondUser, "A1123@email.com");
                    await userManager.AddToRoleAsync(newSecondUser, UserRoles.Admin);
                }

                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.CourseRecipes.Any())
                {
                    context.CourseRecipes.AddRange(new List<CourseRecipes>()
                    {

                        new CourseRecipes
                        {
                            Course = new Course{ 
                                Name = "Українська кухня",
                                DateTime = new DateTime(1, 1, 1, 1, 30,0),
                                Description ="Підчас курсу ви навчителя готувати страви української кухні",  
                                UserCourses = new List<UserCourses>()
                                {
                                    new UserCourses
                                    {
                                        AppUser = newfirstUser,
                                    }
                                }
                            },
                            Recipes = new Recipes
                            {
                                Name = "Борщ",
                                Description = "Рецепт смачного борщу",
                                ImageUrl = "https://images.immediate.co.uk/production/volatile/sites/30/2021/03/borscht-recipe-ab000dc.jpg?quality=90&resize=556,505",
                                Coments = new List<Coments>()
                                {
                                    new Coments
                                    {
                                        AppUser= newfirstUser,
                                        Description = "Дуже смачна, дякую."
                                    },
                                    new Coments
                                    {
                                        AppUser= newSecondUser,
                                        Description = "Нвгодувала всю ролдину."
                                    }
                                }
                            },
                        },

                        new CourseRecipes
                        {
                            Course = new Course{
                                Name = "Як приготувати смачні вареники",
                                DateTime = new DateTime(1, 1, 1, 1, 30,0),
                                Description ="Р результаті вийдуть дуже смачні вареники",
                                UserCourses = new List<UserCourses>()
                                {
                                    new UserCourses
                                    {
                                        AppUser = newSecondUser,
                                    }
                                }
                            },
                            Recipes = new Recipes
                            {
                                Name = "Вареники",
                                Description = "Рецепт вареників\n ",
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
                                        AppUser= newSecondUser,
                                        Description = "Нвгодувала всю ролдину."
                                    }
                                }
                            },
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
