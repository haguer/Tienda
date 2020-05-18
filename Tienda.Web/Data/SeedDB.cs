

namespace Tienda.Web.Data
{
    using Entities;
    using Helpers;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    public class SeedDB
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private readonly Random random;

        public SeedDB(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public IUserHelper UserHelper { get; }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userHelper.GetUserByEmailAsync("haguer78@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Henry",
                    LastName = "Guerrero",
                    Email = "haguer78@gmail.com",
                    UserName = "haguer78@gmail.com",
                    PhoneNumber = "3167111278"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }


            if (!this.context.Products.Any())
            {
                this.AddProduct("Choclitos", user);
                this.AddProduct("Cerveza Poker", user);
                this.AddProduct("Tostacos", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(1000),
                IsAvailabe = true,
                Stock = this.random.Next(100),
                User = user
            });
        }
    }

}
