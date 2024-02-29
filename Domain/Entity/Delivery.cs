using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Delivery
    {
        [Key]
        public  int Id { get; set; }

        public  int IdShiper { get; set; }

        public  double TotalKilomet { get; set; }

        public  double KilometFromShop { get; set; }

        public  double KilometFromCustomer { get; set; }

        [StringLength(100)]
        public  string DeliveryStatus { get; set; }

        public  int IdDeliveryStatus { get; set; }

        public  int Commission { get; set; }

        public  double LatCustomer { get; set; }

        public  double LengCustomer { get; set; }

        public  double LatFoodShop { get; set; }

        public  double LengFoodShop { get; set; }

        public  double LatAtTheStart { get; set; }

        public  double LengAtStart { get; set; }

        public Shipper Shipper { get; set; }

        public FoodOrder FoodOrders { get; set; }
    }
}