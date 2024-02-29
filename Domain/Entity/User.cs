using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class User : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        [Required]
        [MaxLength(50)]
        public required string LastName { get; set; }

        public ICollection<CustomerAddress> CustomerAddresses { get; set; }

        public ICollection<Shipper> Shippers { get; set; }

        public ICollection<ShipperRating> ShipperRatings { get; set; }

        public ICollection<FoodShop> FoodShops { get; set; }

        public ICollection<FoodOrder> FoodOrders { get; set; }
    }
}
