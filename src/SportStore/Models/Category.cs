using System;
using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Models
{
    public class Category
    {
        #region Properties
        public int CategoryId { get; set; }
        public string Name { get; set; }
	//category contains 1..many products (a product can belong to 1..many categories)

        #endregion

        #region Constructor and Methods
        protected Category()
        {
   
        }

        public Category(string name) : this()
        {
            Name = name;
        }


        public void AddProduct(string name, decimal price, string description, string thumbnail = null)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product product)
        {
           throw new NotImplementedException();
        }

        public void RemoveProduct(Product product)
        {
           throw new NotImplementedException();
        }

        public Product FindProduct(string name)
        {
           throw new NotImplementedException();
        }
        #endregion
    }
}
