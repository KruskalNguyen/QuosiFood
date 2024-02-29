using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class OrderItem
    {
        public  int? IdFoodOrder { get; set; }

        public  int IdFood { get; set; }

        public  double Price { get; set; }

        public  int Quantity { get; set; }

        public FoodOrder? FoodOrder { get; set; }

        public Food? Food { get; set; }
    }
}