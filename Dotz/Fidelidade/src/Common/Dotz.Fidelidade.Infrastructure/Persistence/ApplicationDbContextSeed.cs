using Dotz.Fidelidade.Domain.Entities;
using Dotz.Fidelidade.Infrastructure.EntityQueriers;
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
            WalletEntity wallet = null;

            if (!context.Wallets.Any())
            {
                var userId = Guid.NewGuid();
                UserEntity user = new UserEntity(userId, "Augusto Gregório Helena", "User", hashService.GetHash("123456"), "augusto@gregorio.com", new DateTime(1991, 05, 25), true);
                user.AddOrUpdateAddress(Guid.NewGuid(), "12900-999", "Rua teste", 2, "Casa 2", true, userId);
                user.AddOrUpdateAddress(Guid.NewGuid(), "12900-999", "Rua teste", 45, "Casa 1", true, userId);

                await context.Users.AddAsync(user);

                wallet = new WalletEntity(userId, new List<WalletTransactionEntity>());

                wallet.AddPartnerCredit(Guid.NewGuid(), "Compra nas Casas Bahia - TV 50''", 300000);
                wallet.AddPartnerCredit(Guid.NewGuid(), "Compra na Magalu - Lavadora LG''", 20000);
                wallet.AddPartnerCredit(Guid.NewGuid(), "Compra em Posto BR - R$ 250,00", 2500);
                wallet.AddPartnerCredit(Guid.NewGuid(), "Compra em Pague Menos - R$ 500,00", 5000);
            }

            if (!context.ProductCategories.Any())
            {
                ProductEntity currentProduct;
                ProductCategoryEntity subCategory;

                var bookCategory = new ProductCategoryEntity(Guid.NewGuid(), "Livros", null);
                await context.ProductCategories.AddAsync(bookCategory);

                subCategory = new ProductCategoryEntity(Guid.NewGuid(), "Tecnologia", bookCategory.ProductCategoryId);
                await context.ProductCategories.AddAsync(subCategory);
                currentProduct = new ProductEntity(Guid.NewGuid(), "Domain Driven Design - Eric Evans 3ª Edição", 89000, Guid.NewGuid(), subCategory);
                wallet.ExchangeNewProduct(currentProduct, 1);
                await context.Products.AddAsync(currentProduct);

                subCategory = new ProductCategoryEntity(Guid.NewGuid(), "Romance", bookCategory.ProductCategoryId);
                await context.ProductCategories.AddAsync(subCategory);
                await context.Products.AddAsync(new ProductEntity(Guid.NewGuid(), "In Love", 25000, Guid.NewGuid(), subCategory));

                subCategory = new ProductCategoryEntity(Guid.NewGuid(), "Drama", bookCategory.ProductCategoryId);
                await context.ProductCategories.AddAsync(subCategory);
                currentProduct = new ProductEntity(Guid.NewGuid(), "O Fantasma da Ópera", 25000, Guid.NewGuid(), subCategory);
                await context.Products.AddAsync(currentProduct);

                subCategory = new ProductCategoryEntity(Guid.NewGuid(), "Fantasia", bookCategory.ProductCategoryId);
                await context.ProductCategories.AddAsync(subCategory);
                currentProduct = new ProductEntity(Guid.NewGuid(), "Harry Potter - O Príncipe Mestiço", 25000, Guid.NewGuid(), subCategory);
                await context.Products.AddAsync(currentProduct);

                var cdCategory = new ProductCategoryEntity(Guid.NewGuid(), "CDs", null);
                await context.ProductCategories.AddAsync(cdCategory);

                subCategory = new ProductCategoryEntity(Guid.NewGuid(), "Rock", cdCategory.ProductCategoryId);
                await context.ProductCategories.AddAsync(subCategory);
                currentProduct = new ProductEntity(Guid.NewGuid(), "Best of 00's Rock Collection", 15000, Guid.NewGuid(), subCategory);
                await context.Products.AddAsync(currentProduct);

                subCategory = new ProductCategoryEntity(Guid.NewGuid(), "Electro Swing", cdCategory.ProductCategoryId);
                await context.ProductCategories.AddAsync(subCategory);
                currentProduct = new ProductEntity(Guid.NewGuid(), "Caravan Palace - <|º_º|>", 95000, Guid.NewGuid(), subCategory);
                wallet.ExchangeNewProduct(currentProduct, 1);

                await context.Products.AddAsync(currentProduct);
            }

            if (wallet != null)
                await context.Wallets.AddAsync(wallet);

            await context.SaveChangesAsync();
        }
    }
}
