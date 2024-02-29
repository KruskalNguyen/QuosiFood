using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class ShipperRating
    {
        [Key]
        public  int id { get; set; }

        public  int RateScore { get; set; }

        public  DateTime RateDate { get; set; }

        [StringLength(450)]
        public  string IdUser { get; set; }

        public  int IdShipper { get; set; }

        public User User { get; set; }

        public Shipper Shipper { get; set; }
    }
}