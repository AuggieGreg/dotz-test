using Dotz.Fidelidade.Domain.Entities;
using Dotz.Fidelidade.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotz.Fidelidade.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedBasicFunctionality(ApplicationDbContext context, PasswordHashService hashService)
        {
            if (!context.Users.Any())
            {
                var userId = Guid.NewGuid();
                UserEntity user = new UserEntity(userId, "Augusto Gregório Helena", "User", hashService.GetHash("123456"), "augusto@gregorio.com", new DateTime(1991, 05, 25), true);
                user.AddOrUpdateAddress(Guid.NewGuid(), "12900-999", "Rua teste", 2, "Casa 2", true, userId);
                user.AddOrUpdateAddress(Guid.NewGuid(), "12900-999", "Rua teste", 45, "Casa 1", true, userId);

                await context.Users.AddAsync(user);
            }

            if (!context.ProductCategories.Any())
            {
                var bookCategoryId = Guid.NewGuid();
                await context.ProductCategories.AddAsync(new ProductCategoryEntity(bookCategoryId, "Livros", null));
                Guid subCategory = Guid.NewGuid();
                await context.ProductCategories.AddAsync(new ProductCategoryEntity(subCategory, "Tecnologia", bookCategoryId));
                await context.Products.AddAsync(new ProductEntity(Guid.NewGuid(), "Domain Driven Design - Eric Evans 3ª Edição", 89000, subCategory, Guid.NewGuid(), null));

                subCategory = Guid.NewGuid();
                await context.ProductCategories.AddAsync(new ProductCategoryEntity(subCategory, "Romance", bookCategoryId));
                await context.Products.AddAsync(new ProductEntity(Guid.NewGuid(), "In Love", 25000, subCategory, Guid.NewGuid(), null));

                subCategory = Guid.NewGuid();
                await context.ProductCategories.AddAsync(new ProductCategoryEntity(subCategory, "Drama", bookCategoryId));
                await context.Products.AddAsync(new ProductEntity(Guid.NewGuid(), "O Fantasma da Ópera", 25000, subCategory, Guid.NewGuid(), null));


                subCategory = Guid.NewGuid();
                await context.ProductCategories.AddAsync(new ProductCategoryEntity(subCategory, "Fantasia", bookCategoryId));
                await context.Products.AddAsync(new ProductEntity(Guid.NewGuid(), "Harry Potter - O Príncipe Mestiço", 25000, subCategory, Guid.NewGuid(), null));

                var cdCategoryId = Guid.NewGuid();
                await context.ProductCategories.AddAsync(new ProductCategoryEntity(cdCategoryId, "CDs", null));

                subCategory = Guid.NewGuid();
                await context.ProductCategories.AddAsync(new ProductCategoryEntity(subCategory, "Rock", cdCategoryId));
                await context.Products.AddAsync(new ProductEntity(Guid.NewGuid(), "Best of 00's Rock Collection", 15000, subCategory, Guid.NewGuid(), null));

                subCategory = Guid.NewGuid();
                await context.ProductCategories.AddAsync(new ProductCategoryEntity(subCategory, "Electro Swing", cdCategoryId));
                await context.Products.AddAsync(new ProductEntity(Guid.NewGuid(), "Caravan Palace - <|º_º|>", 95000, subCategory, Guid.NewGuid(), null));
            }

            await context.SaveChangesAsync();
        }
    }
}
