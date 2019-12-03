using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestHotel.Models
{
    public static class InitializeData
    {
        public static async Task CreateRolesAndAdmin(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@gmail.com";
            string password = "Yandex1";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }

        public static async Task CreateData(DatabaseContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            await CreateRolesAndAdmin(userManager, roleManager);

            if (!context.RoomTypes.Any())
            {
                await context.RoomTypes.AddRangeAsync(
                    new RoomType("Standart"),
                    new RoomType("Luxe"),
                    new RoomType("Deluxe")
                );
                await context.SaveChangesAsync();
            }

            if (!context.States.Any())
            {
                await context.States.AddRangeAsync(
                    new State("Free"),
                    new State("Busy"),
                    new State("Book"));

                await context.SaveChangesAsync();
            }

            if (!context.Rooms.Any())
            {
                var standart = await context.RoomTypes.SingleAsync(s => s.Type == "Standart");
                var luxe = await context.RoomTypes.SingleAsync(l => l.Type == "Luxe");
                var deluxe = await context.RoomTypes.SingleAsync(d => d.Type == "Deluxe");

                var freeState = await context.States.SingleAsync(f => f.Name == "Free");

                await context.Rooms.AddRangeAsync(
                    new Room("1", 2, standart.Id, freeState.Id, 200),
                    new Room("2", 2, standart.Id, freeState.Id, 200),
                    new Room("3", 3, standart.Id, freeState.Id, 400),
                    new Room("4", 3, standart.Id, freeState.Id, 400),

                    new Room("5", 2, luxe.Id, freeState.Id, 600),
                    new Room("6", 2, luxe.Id, freeState.Id, 600),
                    new Room("7", 4, luxe.Id, freeState.Id, 800),
                    new Room("8", 4, luxe.Id, freeState.Id, 800),

                    new Room("9", 2, deluxe.Id, freeState.Id, 1000),
                    new Room("10", 2, deluxe.Id, freeState.Id, 1200)
                    );
            }

            if (!context.Clietns.Any())
            {
                var user = new User { Email = "ivan@gmail.com", UserName = "ivan" };
                var userPassword = "Yandex2";
                IdentityResult result = await userManager.CreateAsync(user, userPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "user");
                    await context.Clietns.AddAsync(
                        new Client("Ivan", "Ivanov", "Ivanovich", "89111116767"));
                    
                    await context.SaveChangesAsync();
                }

                user = new User { Email = "anton@gmail.com", UserName = "anton" };
                userPassword = "Yandex3";
                result = await userManager.CreateAsync(user, userPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "user");
                    await context.Clietns.AddAsync(
                        new Client("Anton", "Antonov", "Antonovich", "89111111122"));
                    
                    await context.SaveChangesAsync();
                }
            }

        }
    }
}
