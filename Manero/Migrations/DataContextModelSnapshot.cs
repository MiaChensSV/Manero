﻿// <auto-generated />
using System;
using Manero.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Manero.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Manero.Models.Entities.AddressEntity", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Manero.Models.Entities.AppIdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Deleted_At")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Modified_At")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ProfileImageUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Manero.Models.Entities.CategoryEntity", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Manero.Models.Entities.CreditCardsEntity", b =>
                {
                    b.Property<int>("CardNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CVV")
                        .HasColumnType("int");

                    b.Property<string>("CreditCardName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("CardNumber");

                    b.HasIndex("UserId");

                    b.ToTable("CreditCards");
                });

            modelBuilder.Entity("Manero.Models.Entities.OrderDetailEntity", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ArticleNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Created_Date")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Deleted_Date")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("DiscountedPrice")
                        .HasColumnType("decimal(7,2)");

                    b.Property<DateTime>("Modified_Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(7,2)");

                    b.Property<string>("ProductArticleNumber")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductArticleNumber");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("Manero.Models.Entities.OrderEntity", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created_Date")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("DeliveryFee")
                        .HasColumnType("decimal(7,2)");

                    b.Property<DateTime>("Modified_Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PromocodeId")
                        .HasColumnType("int");

                    b.Property<string>("ShippingAddress")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(7,2)");

                    b.Property<string>("TrackingNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("OrderId");

                    b.HasIndex("PromocodeId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Manero.Models.Entities.OrderStatusEntity", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("StatusId");

                    b.ToTable("OrderStatus");
                });

            modelBuilder.Entity("Manero.Models.Entities.ProductCategoryEntity", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("Manero.Models.Entities.ProductColorEntity", b =>
                {
                    b.Property<int>("ColorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ColorName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ColorId");

                    b.ToTable("ProductColor");
                });

            modelBuilder.Entity("Manero.Models.Entities.ProductDetailEntity", b =>
                {
                    b.Property<string>("ArticleNumber")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("ColorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created_Date")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Deleted_Date")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("DiscountedPrice")
                        .HasColumnType("decimal(7,2)");

                    b.Property<DateTime>("Modified_Date")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(7,2)");

                    b.Property<string>("ProductDetailDescription")
                        .HasColumnType("longtext");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductImageUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("ProductTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SizeId")
                        .HasColumnType("int");

                    b.HasKey("ArticleNumber");

                    b.HasIndex("ColorId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SizeId");

                    b.ToTable("ProductDetail");
                });

            modelBuilder.Entity("Manero.Models.Entities.ProductModelEntity", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ModelNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ProductId");

                    b.ToTable("ProductModels");
                });

            modelBuilder.Entity("Manero.Models.Entities.ProductSizeEntity", b =>
                {
                    b.Property<int>("SizeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("SizeName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("SizeId");

                    b.ToTable("ProductSize");
                });

            modelBuilder.Entity("Manero.Models.Entities.ProductTagEntity", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("ProductTag");
                });

            modelBuilder.Entity("Manero.Models.Entities.ProductWishListEntity", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("WishListId")
                        .HasColumnType("int");

                    b.Property<string>("ProductDetailEntityArticleNumber")
                        .HasColumnType("varchar(255)");

                    b.HasKey("ProductId", "WishListId");

                    b.HasIndex("ProductDetailEntityArticleNumber");

                    b.HasIndex("WishListId");

                    b.ToTable("ProductWishList");
                });

            modelBuilder.Entity("Manero.Models.Entities.PromocodesEntity", b =>
                {
                    b.Property<int>("PromocodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("PromocodeDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("PromocodePercentage")
                        .HasColumnType("decimal(5,2)");

                    b.Property<string>("PromocodeTitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PromocodeId");

                    b.ToTable("Promocodes");
                });

            modelBuilder.Entity("Manero.Models.Entities.ReviewEntity", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("Rating")
                        .HasColumnType("decimal(3,2)");

                    b.Property<string>("ReviewText")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Manero.Models.Entities.TagEntity", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("TagId");

                    b.ToTable("TagEntity");
                });

            modelBuilder.Entity("Manero.Models.Entities.UserAddressEntity", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("AppIdentityUserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LocationName")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "AddressId");

                    b.HasIndex("AddressId");

                    b.HasIndex("AppIdentityUserId");

                    b.ToTable("AppUserAddress");
                });

            modelBuilder.Entity("Manero.Models.Entities.UserPromocodesEntity", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("PromocodeId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "PromocodeId");

                    b.HasIndex("PromocodeId");

                    b.ToTable("UserPromocodes");
                });

            modelBuilder.Entity("Manero.Models.Entities.WishListEntity", b =>
                {
                    b.Property<int>("WishlistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("WishlistId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("WishLists");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Manero.Models.Entities.CreditCardsEntity", b =>
                {
                    b.HasOne("Manero.Models.Entities.AppIdentityUser", "User")
                        .WithMany("CreditCards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Manero.Models.Entities.OrderDetailEntity", b =>
                {
                    b.HasOne("Manero.Models.Entities.OrderEntity", "Order")
                        .WithMany("OrderDetailItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manero.Models.Entities.ProductDetailEntity", "Product")
                        .WithMany()
                        .HasForeignKey("ProductArticleNumber");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Manero.Models.Entities.OrderEntity", b =>
                {
                    b.HasOne("Manero.Models.Entities.PromocodesEntity", "Promocode")
                        .WithMany()
                        .HasForeignKey("PromocodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manero.Models.Entities.OrderStatusEntity", "StatusName")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manero.Models.Entities.AppIdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Promocode");

                    b.Navigation("StatusName");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Manero.Models.Entities.ProductCategoryEntity", b =>
                {
                    b.HasOne("Manero.Models.Entities.CategoryEntity", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manero.Models.Entities.ProductModelEntity", "Product")
                        .WithMany("Categories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Manero.Models.Entities.ProductDetailEntity", b =>
                {
                    b.HasOne("Manero.Models.Entities.ProductColorEntity", "Color")
                        .WithMany("Products")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manero.Models.Entities.ProductModelEntity", "ProductModel")
                        .WithMany("Products")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manero.Models.Entities.ProductSizeEntity", "Size")
                        .WithMany("Products")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("ProductModel");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("Manero.Models.Entities.ProductTagEntity", b =>
                {
                    b.HasOne("Manero.Models.Entities.ProductModelEntity", "Product")
                        .WithMany("Tags")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manero.Models.Entities.TagEntity", "Tag")
                        .WithMany("Products")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Manero.Models.Entities.ProductWishListEntity", b =>
                {
                    b.HasOne("Manero.Models.Entities.ProductDetailEntity", null)
                        .WithMany("Wishlists")
                        .HasForeignKey("ProductDetailEntityArticleNumber");

                    b.HasOne("Manero.Models.Entities.ProductModelEntity", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manero.Models.Entities.WishListEntity", "WishList")
                        .WithMany("Products")
                        .HasForeignKey("WishListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("WishList");
                });

            modelBuilder.Entity("Manero.Models.Entities.ReviewEntity", b =>
                {
                    b.HasOne("Manero.Models.Entities.ProductModelEntity", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manero.Models.Entities.AppIdentityUser", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Manero.Models.Entities.UserAddressEntity", b =>
                {
                    b.HasOne("Manero.Models.Entities.AddressEntity", "Address")
                        .WithMany("Users")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manero.Models.Entities.AppIdentityUser", "AppIdentityUser")
                        .WithMany("Addresses")
                        .HasForeignKey("AppIdentityUserId");

                    b.Navigation("Address");

                    b.Navigation("AppIdentityUser");
                });

            modelBuilder.Entity("Manero.Models.Entities.UserPromocodesEntity", b =>
                {
                    b.HasOne("Manero.Models.Entities.PromocodesEntity", "Promocode")
                        .WithMany("Users")
                        .HasForeignKey("PromocodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manero.Models.Entities.AppIdentityUser", "User")
                        .WithMany("Promocodes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Promocode");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Manero.Models.Entities.WishListEntity", b =>
                {
                    b.HasOne("Manero.Models.Entities.AppIdentityUser", "User")
                        .WithOne("Wishlist")
                        .HasForeignKey("Manero.Models.Entities.WishListEntity", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Manero.Models.Entities.AppIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Manero.Models.Entities.AppIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Manero.Models.Entities.AppIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Manero.Models.Entities.AppIdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Manero.Models.Entities.AddressEntity", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Manero.Models.Entities.AppIdentityUser", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("CreditCards");

                    b.Navigation("Promocodes");

                    b.Navigation("Reviews");

                    b.Navigation("Wishlist");
                });

            modelBuilder.Entity("Manero.Models.Entities.CategoryEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Manero.Models.Entities.OrderEntity", b =>
                {
                    b.Navigation("OrderDetailItems");
                });

            modelBuilder.Entity("Manero.Models.Entities.ProductColorEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Manero.Models.Entities.ProductDetailEntity", b =>
                {
                    b.Navigation("Wishlists");
                });

            modelBuilder.Entity("Manero.Models.Entities.ProductModelEntity", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Products");

                    b.Navigation("Reviews");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("Manero.Models.Entities.ProductSizeEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Manero.Models.Entities.PromocodesEntity", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Manero.Models.Entities.TagEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Manero.Models.Entities.WishListEntity", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
