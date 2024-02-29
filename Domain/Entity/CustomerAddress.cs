using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class CustomerAddress
    {
        [Key]
        public  int Id { get; set; }

        [StringLength(450)]
        public  string IdUser { get; set; }

        [StringLength(450)]
        public  string Address { get; set; }

        public  double Longitude { get; set; }

        public  double Latitude { get; set; }

        public User User { get; set; }
    }
}