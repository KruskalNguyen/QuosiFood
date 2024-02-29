using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class FoodOrder
    {
        [Key]
        public int Id { get; set; }

        public int? IdDelivery { get; set; }

        [StringLength(450)]
        public string IdUser { get; set; }

        public int IdFoodShopBranch { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(100)]
        public string OrderStatus { get; set; }

        public double TotalPrice { get; set; }

        public int TotalAmount { get; set; }

        [StringLength(450)]
        public string? FoodShopAddress { get; set; }

        [StringLength(450)]
        public string? CustomerAddress { get; set; }

        public string? CancelReason { get; set; }

        public User User { get; set; }

        public FoodShopBranch FoodShopBranch { get; set; }

        public Delivery? Delivery { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}