using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class FoodShopBranch
    {
        [Key]
        public  int Id { get; set; }

        public  int IdFoodShop { get; set; }

        [StringLength(450)]
        public  string? ThumbNail { get; set; }

        [StringLength(256)]
        public  string? StreetName { get; set; }

        public  string? Longitude { get; set; }

        public  string? Latitude { get; set; }

        [StringLength(450)]
        public  string? Address { get; set; }

        [StringLength(450)]
        public  string? Desription { get; set; }

        public FoodShop FoodShop { get; set; }

        public ICollection<FoodBranchItem> FoodBranchItems { get; set; }
        public ICollection<FoodOrder> FoodOrders { get; set; }
    }
}