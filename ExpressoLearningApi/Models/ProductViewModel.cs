using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressoLearningApi.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public int ProductPrice { get; set; }

        public string ProductImage { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string CategoryImage { get; set; }
    }
}
