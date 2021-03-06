// <auto-generated />
using System;
using Dotz.Fidelidade.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dotz.Fidelidade.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("Dotz.Fidelidade.Domain.Entities.PartnerCreditEntity", b =>
                {
                    b.Property<Guid>("PartnerCreditId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Creator")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Modifier")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("PartnerId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("WalletTransactionId")
                        .HasColumnType("char(36)");

                    b.HasKey("PartnerCreditId");

                    b.HasIndex("WalletTransactionId");

                    b.ToTable("PartnerCredits");
                });

            modelBuilder.Entity("Dotz.Fidelidade.Domain.Entities.ProductCategoryEntity", b =>
                {
                    b.Property<Guid>("ProductCategoryId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Creator")
                        .HasColumnType("longtext");

                    b.Property<string>("Modifier")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<Guid?>("ParentCategoryId")
                        .HasColumnType("char(36)");

                    b.HasKey("ProductCategoryId");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("Dotz.Fidelidade.Domain.Entities.ProductEntity", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Creator")
                        .HasColumnType("longtext");

                    b.Property<string>("Modifier")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("PartnerId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Price")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Dotz.Fidelidade.Domain.Entities.ProductExchangeEntity", b =>
                {
                    b.Property<Guid>("ProductExchangeId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Creator")
                        .HasColumnType("longtext");

                    b.Property<string>("Modifier")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Price")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Quantity")
                        .HasPrecision(5)
                        .HasColumnType("int");

                    b.Property<Guid?>("WalletTransactionId")
                        .HasColumnType("char(36)");

                    b.HasKey("ProductExchangeId");

                    b.HasIndex("ProductId");

                    b.HasIndex("WalletTransactionId");

                    b.ToTable("ProductExchanges");
                });

            modelBuilder.Entity("Dotz.Fidelidade.Domain.Entities.ProductOrderEntity", b =>
                {
                    b.Property<Guid>("ProductOrderId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Creator")
                        .HasColumnType("longtext");

                    b.Property<string>("DeliveryStatus")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Modifier")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("ProductExchangeId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("ProductOrderId");

                    b.HasIndex("ProductExchangeId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("ProductOrders");
                });

            modelBuilder.Entity("Dotz.Fidelidade.Domain.Entities.UserAddressEntity", b =>
                {
                    b.Property<Guid?>("AddressId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Complement")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Creator")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsMain")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Modifier")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("Number")
                        .HasColumnType("int");

                    b.Property<string>("PostalCode")
                        .HasColumnType("longtext");

                    b.Property<Guid?>("UserId")
                        .IsRequired()
                        .HasColumnType("char(36)");

                    b.HasKey("AddressId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAddresses");
                });

            modelBuilder.Entity("Dotz.Fidelidade.Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid?>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Creator")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Modifier")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid?>("WalletId")
                        .HasColumnType("char(36)");

                    b.HasKey("UserId");

                    b.HasIndex("WalletId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Dotz.Fidelidade.Domain.Entities.WalletEntity", b =>
                {
                    b.Property<Guid>("WalletId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Creator")
                        .HasColumnType("longtext");

                    b.Property<string>("Modifier")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("WalletId");

                    b.ToTable("Wallets");
                });

            modelBuilder.Entity("Dotz.Fidelidade.Domain.Entities.WalletTransactionEntity", b =>
                {
                    b.Property<Guid>("WalletTransactionId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Creator")
                        .HasColumnType("longtext");

                    b.Property<string>("Modifier")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("TotalAmount")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10,0)");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<Guid>("WalletId")
                        .HasColumnType("char(36)");

                    b.HasKey("WalletTransactionId");

                    b.HasIndex("WalletId");

                    b.ToTable("WalletTransactions");
                });

            modelBuilder.Entity("Dotz.Fidelidade.Domain.Entities.PartnerCreditEntity", b =>
                {
                    b.HasOne("Dotz.Fidelidade.Domain.Entities.WalletTransactionEntity", null)
                        .WithOne("PartnerCreditEntity")
                        .HasForeignKey("Dotz.Fidelidade.Domain.Entities.PartnerCreditEntity", "PartnerCreditId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dotz.Fidelidade.Domain.Entities.WalletTransactionEntity", "WalletTransaction")
                        .WithMany()
                        .HasForeignKey("WalletTransactionId");

                    b.Navigation("WalletTransaction");
                });

            modelBuilder.Entity("Dotz.Fidelidade.Domain.Entities.ProductCategoryEntity", b =>
                {
                    b.HasOne("Dotz.Fidelidade.Domain.Entities.ProductCategoryEntity", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("Dotz.Fidelidade.Domain.Entities.ProductEntity", b =>
                {
                    b.HasOne("Dotz.Fidelidade.Domain.Entities.ProductCategoryEntity", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Dotz.Fidelidade.Domain.Entities.ProductExchangeEntity", b =>
                {
                    b.HasOne("Dotz.Fidelidade.Domain.Entities.WalletTransactionEntity", null)
                        .WithOne("ProductExchange")
                        .HasForeignKey("Dotz.Fidelidade.Domain.Entities.ProductExchangeEntity", "ProductExchangeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dotz.Fidelidade.Domain.Entities.ProductEntity", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dotz.Fidelidade.Domain.Entities.WalletTransactionEntity", "WalletTransaction")
                        .WithMany()
                        .HasForeignKey("WalletTransactionId");

                    b.Navigation("Product");

                    b.Navigation("WalletTransaction");
                });

            modelBuilder.Entity("Dotz.Fidelidade.Domain.Entities.ProductOrderEntity", b =>
                {
                    b.HasOne("Dotz.Fidelidade.Domain.Entities.ProductExchangeEntity", "ProductExchange")
                        .WithMany()
                        .HasForeignKey("ProductExchangeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dotz.Fidelidade.Domain.Entities.ProductEntity", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dotz.Fidelidade.Domain.Entities.UserEntity", "User")
                        .WithMany("ProductOrders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ProductExchange");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dotz.Fidelidade.Domain.Entities.UserAddressEntity", b =>
                {
                    b.HasOne("Dotz.Fidelidade.Domain.Entities.UserEntity", "User")
                        .WithMany("UserAddresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dotz.Fidelidade.Domain.Entities.UserEntity", b =>
                {
                    b.HasOne("Dotz.Fidelidade.Domain.Entities.WalletEntity", "Wallet")
                        .WithMany()
                        .HasForeignKey("WalletId");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("Dotz.Fidelidade.Domain.Entities.WalletEntity", b =>
                {
                    b.HasOne("Dotz.Fidelidade.Domain.Entities.UserEntity", "User")
                        .WithOne()
                        .HasForeignKey("Dotz.Fidelidade.Domain.Entities.WalletEntity", "WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dotz.Fidelidade.Domain.Entities.WalletTransactionEntity", b =>
                {
                    b.HasOne("Dotz.Fidelidade.Domain.Entities.WalletEntity", "Wallet")
                        .WithMany("WalletTransactions")
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("Dotz.Fidelidade.Domain.Entities.ProductCategoryEntity", b =>
                {
                    b.Navigation("ChildCategories");
                });

            modelBuilder.Entity("Dotz.Fidelidade.Domain.Entities.UserEntity", b =>
                {
                    b.Navigation("ProductOrders");

                    b.Navigation("UserAddresses");
                });

            modelBuilder.Entity("Dotz.Fidelidade.Domain.Entities.WalletEntity", b =>
                {
                    b.Navigation("WalletTransactions");
                });

            modelBuilder.Entity("Dotz.Fidelidade.Domain.Entities.WalletTransactionEntity", b =>
                {
                    b.Navigation("PartnerCreditEntity");

                    b.Navigation("ProductExchange");
                });
#pragma warning restore 612, 618
        }
    }
}
