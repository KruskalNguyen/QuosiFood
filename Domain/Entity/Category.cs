using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Category
    {
        [Key]
        public  int Id { get; set; }

        [StringLength(256)]
        public  string Name { get; set; }

        public  string Description { get; set; }

        public ICollection<Food> Foods { get; set; }
    }
}