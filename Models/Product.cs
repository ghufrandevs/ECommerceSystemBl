using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace ECommerceSystemBl.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        public decimal OverallRating { get; set; }

        public int CategoryId { get; set; }

        public virtual Category? Category { get; set; }

        [JsonIgnore]

        public virtual ICollection<Review> Reviews { get;set; }

        [JsonIgnore]

        public virtual ICollection< OrderProducts> OrderProductss { get; set; }

    }
}
