using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Shipper
    {
        [Key]
        public  int Id { get; set; }

        [StringLength(11)]
        public  string LicensePlate { get; set; }

        [StringLength(450)]
        public  string IdUser { get; set; }

        public  bool IsActive { get; set; }

        [StringLength(450)]
        public  string Address { get; set; }

        public  string Avatar { get; set; }

        public  double AverageRatingScore { get; set; }

        public  int ReputationScore { get; set; }

        public  int NumDeliveriesCompleted { get; set; }

        public  double TotalCommission { get; set; }

        public User User { get; set; }

        public ICollection<ShipperRating> ShipperRatings { get; set; }

        public ICollection<Delivery> Deliveries { get; set; }
    }
}