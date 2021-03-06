using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressoLearningApi.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProductDescription { get; set; }

        [Required]
        public int ProductPrice { get; set; }

        [Required]
        public string ProductImage { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
    }
}
