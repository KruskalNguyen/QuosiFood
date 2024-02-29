using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class FoodShop
    {
        [Key]
        public  int Id { get; set; }

        [StringLength(450)]
        public  string? Banner { get; set; }

        [StringLength(450)]
        public  string? Avatar { get; set; }

        [StringLength(256)]
        public  string? Name { get; set; }

        public  int? NumBranch { get; set; }

        public  int? NumFood { get; set; }

        public  string? Description { get; set; }

        [StringLength(450)]
        public  string? IdUser { get; set; }

        [StringLength(100)]
        public  string? IsActive { get; set; }

        public User User { get; set; }

        public ICollection<FoodShopBranch> FoodShopBranches { get; set; }

        public ICollection<Food> Foods { get; set; }


    }
}