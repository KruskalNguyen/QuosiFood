using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Food
    {
        [Key]
        public  int id { get; set; }

        [StringLength(256)]
        public  string Name { get; set; }

        public  string? Description { get; set; }

        public  int? NumSold { get; set; }

        public  double Price { get; set; }

        public  double? DiscountAmount { get; set; }

        public  int IdFoodShop { get; set; }

        public  string? Note { get; set; }

        public  bool IsActive { get; set; }

        public  bool Publish { get; set; }

        public  int IdCategory { get; set; }

        public FoodShop FoodShop { get; set; }

        public ICollection<FoodBranchItem> FoodBranchItems { get; set; }

        public Category Category { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}