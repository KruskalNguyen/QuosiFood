using Domain.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ShopiiContext : IdentityDbContext<
        User, 
        IdentityRole,
        string, 
        IdentityUserClaim<string>, 
        IdentityUserRole<string>, 
        IdentityUserLogin<string>, 
        IdentityRoleClaim<string>, 
        UserToken>
    {
        public ShopiiContext(DbContextOptions<ShopiiContext> options) : base(options)
        {
            
        }

        public DbSet<CustomerAddress> CustomerAddress { get; set; }
        public DbSet<Shipper> Shipper { get; set; }
        public DbSet<ShipperRating> ShipperRating { get; set; }
        public DbSet<FoodShop> FoodShop { get; set; }
        public DbSet<FoodShopBranch> FoodShopBranch { get; set; }
        public DbSet<Food> Food { get; set; }
        public DbSet<FoodBranchItem> FoodBranchItem { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<FoodOrder> FoodOrder { get; set; }
        public DbSet<Delivery> Delivery { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FoodBranchItem>().HasKey(
                key => new {key.IdBranch, key.IdFood}
                );

            modelBuilder.Entity<OrderItem>().HasKey(
                key => new {key.IdFood, key.IdFoodOrder}
                );

            modelBuilder.Entity<User>()
            .HasMany(x => x.CustomerAddresses)
            .WithOne(y => y.User)
            .HasForeignKey(y => y.IdUser);

            modelBuilder.Entity<User>()
            .HasMany(x => x.Shippers)
            .WithOne(y => y.User)
            .HasForeignKey(y => y.IdUser);


            modelBuilder.Entity<Shipper>()
                .HasMany(x => x.ShipperRatings)
                .WithOne(y => y.Shipper)
                .HasForeignKey(y => y.IdShipper);

            modelBuilder.Entity<User>()
           .HasMany(x => x.FoodShops)
           .WithOne(y => y.User)
           .HasForeignKey(y => y.IdUser);

            modelBuilder.Entity<FoodShop>()
                .HasMany(x => x.FoodShopBranches)
                .WithOne(y => y.FoodShop)
                .HasForeignKey(y => y.IdFoodShop);

            modelBuilder.Entity<FoodShop>()
                .HasMany(x => x.Foods)
                .WithOne(y => y.FoodShop)
                .HasForeignKey(y => y.IdFoodShop);


            modelBuilder.Entity<FoodBranchItem>(
                e =>
                {
                    e.HasOne(fbi => fbi.FoodShopBranch)
                    .WithMany(x => x.FoodBranchItems)
                    .HasForeignKey(x => x.IdBranch)
                     .OnDelete(DeleteBehavior.ClientSetNull);

                    e.HasOne(fpi => fpi.Food)
                    .WithMany(x => x.FoodBranchItems)
                    .HasForeignKey(x => x.IdFood)
                     .OnDelete(DeleteBehavior.ClientSetNull);
                }
                );
                

            modelBuilder.Entity<Category>()
                .HasMany(x => x.Foods)
                .WithOne(y => y.Category)
                .HasForeignKey(y => y.IdCategory);

            modelBuilder.Entity<User>()
            .HasMany(y => y.FoodOrders)
            .WithOne(y => y.User)
            .HasForeignKey(y => y.IdUser);

            modelBuilder.Entity<FoodShopBranch>()
                .HasMany(x => x.FoodOrders)
                .WithOne(y => y.FoodShopBranch)
                .HasForeignKey(y => y.IdFoodShopBranch).OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Shipper>()
                .HasMany(x => x.Deliveries)
                .WithOne(y => y.Shipper)
                .HasForeignKey(y => y.IdShiper);

            modelBuilder.Entity<Delivery>()
            .HasOne(y => y.FoodOrders)
            .WithOne(y => y.Delivery)
            .HasForeignKey<FoodOrder>(x => x.IdDelivery).OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<FoodOrder>()
                .HasMany(x => x.OrderItems)
                .WithOne(y => y.FoodOrder)
                .HasForeignKey(y => y.IdFoodOrder).OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Food>()
                .HasMany(x => x.OrderItems)
                .WithOne(y => y.Food)
                .HasForeignKey(y => y.IdFood);
        }
    }
}
