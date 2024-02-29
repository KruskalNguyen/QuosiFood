﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ShopiiContext))]
    [Migration("20240229032408_nullFieldFO2")]
    partial class nullFieldFO2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Domain.Entity.CustomerAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IdUser")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("CustomerAddress");
                });

            modelBuilder.Entity("Domain.Entity.Delivery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Commission")
                        .HasColumnType("int");

                    b.Property<string>("DeliveryStatus")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("IdDeliveryStatus")
                        .HasColumnType("int");

                    b.Property<int>("IdShiper")
                        .HasColumnType("int");

                    b.Property<double>("KilometFromCustomer")
                        .HasColumnType("float");

                    b.Property<double>("KilometFromShop")
                        .HasColumnType("float");

                    b.Property<double>("LatAtTheStart")
                        .HasColumnType("float");

                    b.Property<double>("LatCustomer")
                        .HasColumnType("float");

                    b.Property<double>("LatFoodShop")
                        .HasColumnType("float");

                    b.Property<double>("LengAtStart")
                        .HasColumnType("float");

                    b.Property<double>("LengCustomer")
                        .HasColumnType("float");

                    b.Property<double>("LengFoodShop")
                        .HasColumnType("float");

                    b.Property<double>("TotalKilomet")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdShiper");

                    b.ToTable("Delivery");
                });

            modelBuilder.Entity("Domain.Entity.Food", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("DiscountAmount")
                        .HasColumnType("float");

                    b.Property<int>("IdCategory")
                        .HasColumnType("int");

                    b.Property<int>("IdFoodShop")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumSold")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<bool>("Publish")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("IdCategory");

                    b.HasIndex("IdFoodShop");

                    b.ToTable("Food");
                });

            modelBuilder.Entity("Domain.Entity.FoodBranchItem", b =>
                {
                    b.Property<int>("IdBranch")
                        .HasColumnType("int");

                    b.Property<int>("IdFood")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("IdBranch", "IdFood");

                    b.HasIndex("IdFood");

                    b.ToTable("FoodBranchItem");
                });

            modelBuilder.Entity("Domain.Entity.FoodOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CancelReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerAddress")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FoodShopAddress")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("IdDelivery")
                        .HasColumnType("int");

                    b.Property<int>("IdFoodShopBranch")
                        .HasColumnType("int");

                    b.Property<string>("IdUser")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TotalAmount")
                        .HasColumnType("int");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdDelivery")
                        .IsUnique()
                        .HasFilter("[IdDelivery] IS NOT NULL");

                    b.HasIndex("IdFoodShopBranch");

                    b.HasIndex("IdUser");

                    b.ToTable("FoodOrder");
                });

            modelBuilder.Entity("Domain.Entity.FoodShop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Avatar")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Banner")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdUser")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IsActive")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int?>("NumBranch")
                        .HasColumnType("int");

                    b.Property<int?>("NumFood")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("FoodShop");
                });

            modelBuilder.Entity("Domain.Entity.FoodShopBranch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Desription")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IdFoodShop")
                        .HasColumnType("int");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ThumbNail")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("IdFoodShop");

                    b.ToTable("FoodShopBranch");
                });

            modelBuilder.Entity("Domain.Entity.OrderItem", b =>
                {
                    b.Property<int>("IdFood")
                        .HasColumnType("int");

                    b.Property<int>("IdFoodOrder")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("IdFood", "IdFoodOrder");

                    b.HasIndex("IdFoodOrder");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("Domain.Entity.Shipper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Avatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("AverageRatingScore")
                        .HasColumnType("float");

                    b.Property<string>("IdUser")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("NumDeliveriesCompleted")
                        .HasColumnType("int");

                    b.Property<int>("ReputationScore")
                        .HasColumnType("int");

                    b.Property<double>("TotalCommission")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Shipper");
                });

            modelBuilder.Entity("Domain.Entity.ShipperRating", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("IdShipper")
                        .HasColumnType("int");

                    b.Property<string>("IdUser")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("RateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RateScore")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("IdShipper");

                    b.HasIndex("UserId");

                    b.ToTable("ShipperRating");
                });

            modelBuilder.Entity("Domain.Entity.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Domain.Entity.UserToken", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpRefreshToken")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpToken")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Domain.Entity.CustomerAddress", b =>
                {
                    b.HasOne("Domain.Entity.User", "User")
                        .WithMany("CustomerAddresses")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entity.Delivery", b =>
                {
                    b.HasOne("Domain.Entity.Shipper", "Shipper")
                        .WithMany("Deliveries")
                        .HasForeignKey("IdShiper")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shipper");
                });

            modelBuilder.Entity("Domain.Entity.Food", b =>
                {
                    b.HasOne("Domain.Entity.Category", "Category")
                        .WithMany("Foods")
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.FoodShop", "FoodShop")
                        .WithMany("Foods")
                        .HasForeignKey("IdFoodShop")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("FoodShop");
                });

            modelBuilder.Entity("Domain.Entity.FoodBranchItem", b =>
                {
                    b.HasOne("Domain.Entity.FoodShopBranch", "FoodShopBranch")
                        .WithMany("FoodBranchItems")
                        .HasForeignKey("IdBranch")
                        .IsRequired();

                    b.HasOne("Domain.Entity.Food", "Food")
                        .WithMany("FoodBranchItems")
                        .HasForeignKey("IdFood")
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("FoodShopBranch");
                });

            modelBuilder.Entity("Domain.Entity.FoodOrder", b =>
                {
                    b.HasOne("Domain.Entity.Delivery", "Delivery")
                        .WithOne("FoodOrders")
                        .HasForeignKey("Domain.Entity.FoodOrder", "IdDelivery");

                    b.HasOne("Domain.Entity.FoodShopBranch", "FoodShopBranch")
                        .WithMany("FoodOrders")
                        .HasForeignKey("IdFoodShopBranch")
                        .IsRequired();

                    b.HasOne("Domain.Entity.User", "User")
                        .WithMany("FoodOrders")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Delivery");

                    b.Navigation("FoodShopBranch");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entity.FoodShop", b =>
                {
                    b.HasOne("Domain.Entity.User", "User")
                        .WithMany("FoodShops")
                        .HasForeignKey("IdUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entity.FoodShopBranch", b =>
                {
                    b.HasOne("Domain.Entity.FoodShop", "FoodShop")
                        .WithMany("FoodShopBranches")
                        .HasForeignKey("IdFoodShop")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FoodShop");
                });

            modelBuilder.Entity("Domain.Entity.OrderItem", b =>
                {
                    b.HasOne("Domain.Entity.Food", "Food")
                        .WithMany("OrderItems")
                        .HasForeignKey("IdFood")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.FoodOrder", "FoodOrder")
                        .WithMany("OrderItems")
                        .HasForeignKey("IdFoodOrder")
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("FoodOrder");
                });

            modelBuilder.Entity("Domain.Entity.Shipper", b =>
                {
                    b.HasOne("Domain.Entity.User", "User")
                        .WithMany("Shippers")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entity.ShipperRating", b =>
                {
                    b.HasOne("Domain.Entity.Shipper", "Shipper")
                        .WithMany("ShipperRatings")
                        .HasForeignKey("IdShipper")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.User", "User")
                        .WithMany("ShipperRatings")
                        .HasForeignKey("UserId");

                    b.Navigation("Shipper");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entity.UserToken", b =>
                {
                    b.HasOne("Domain.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                    b.HasOne("Domain.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.Entity.User", null)
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

                    b.HasOne("Domain.Entity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.Category", b =>
                {
                    b.Navigation("Foods");
                });

            modelBuilder.Entity("Domain.Entity.Delivery", b =>
                {
                    b.Navigation("FoodOrders")
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entity.Food", b =>
                {
                    b.Navigation("FoodBranchItems");

                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Domain.Entity.FoodOrder", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Domain.Entity.FoodShop", b =>
                {
                    b.Navigation("FoodShopBranches");

                    b.Navigation("Foods");
                });

            modelBuilder.Entity("Domain.Entity.FoodShopBranch", b =>
                {
                    b.Navigation("FoodBranchItems");

                    b.Navigation("FoodOrders");
                });

            modelBuilder.Entity("Domain.Entity.Shipper", b =>
                {
                    b.Navigation("Deliveries");

                    b.Navigation("ShipperRatings");
                });

            modelBuilder.Entity("Domain.Entity.User", b =>
                {
                    b.Navigation("CustomerAddresses");

                    b.Navigation("FoodOrders");

                    b.Navigation("FoodShops");

                    b.Navigation("ShipperRatings");

                    b.Navigation("Shippers");
                });
#pragma warning restore 612, 618
        }
    }
}