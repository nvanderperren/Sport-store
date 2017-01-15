using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Models
{
    public class ProductCategory
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ProductCategory(Product product, Category category)
        {
            Product = product;
            Category = category;
            ProductId = product.ProductId;
            CategoryId = category.CategoryId;
        } 
    }
}
