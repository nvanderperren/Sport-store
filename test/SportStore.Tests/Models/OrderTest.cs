﻿using SportStore.Models;
using Xunit;

namespace SportsStore.Tests.Models
{
    public class OrderTest
    {
        private Order _order;
        private Product _p1;
        private Product _p3;

        public OrderTest()
        {
            Cart cart = new Cart();
            _p1 = new Product(1, "Football", 10);
            Product p2 = new Product(2, "Short", 5);
            _p3 = new Product ( 3, "NotInOrder",  5);
            cart.AddLine(_p1, 1);
            cart.AddLine(p2, 10);
            _order = new Order(cart, null, false, "Teststraat 10", new City(){Postalcode = "3000", Name="Gent"});
        }

        [Fact]
        public void Total_ReturnsSumOfOrderlines()
        {
               Assert.Equal(60, _order.Total);
        }
        [Fact]
        public void HasOrdered_ProductInOrder_ReturnsTrue()
        {
            Assert.True(_order.HasOrdered(_p1));
        }

        [Fact]
        public void HasOrdered_ProductNotInOrder_ReturnsFalse()
        {
            Assert.False(_order.HasOrdered(_p3));
        }
     
    }
}
