using System;
using System.Collections.Generic;
using System.Linq;

namespace SportStore.Models
{
    public class Category
    {
        #region Properties
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<ProductCategory> Products { get; private set; }
	

        #endregion

        #region Constructor and Methods
        protected Category()
        {
            Products = new List<ProductCategory>();

        }

        public Category(string name) : this()
        {
            Name = name;
            Products = new List<ProductCategory>();
        }


        public void AddProduct(string name, decimal price, string description, string thumbnail = null)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product product)
        {
            if (FindProduct(product.Name) == null)
                Products.Add(new ProductCategory(product, this));
                
        }

        public void RemoveProduct(Product product)
        {
            ProductCategory pc = Products.FirstOrDefault(p => p.Product.Equals(product));
            Products.Remove(pc);
        }

        public Product FindProduct(string name)
        {
            return Products.FirstOrDefault(p => p.Product.Name == name)?.Product ;
        }
        #endregion
    }
}
