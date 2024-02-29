using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class FoodBranchItem
    {
        public  int IdFood { get; set; }

        public  int IdBranch { get; set; }

        public  int Quantity { get; set; }

        public FoodShopBranch FoodShopBranch { get; set; }

        public Food Food { get; set; }
    }
}