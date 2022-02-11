using NUnit.Framework;
using System;
using System.Collections.Generic;
using PointOfSale.Interfaces;
using PointOfSale.Models;

namespace PointOfSale.Test
{
    [TestFixture]
    public class PointOfSaleTerminalTests
    {
        private PointOfSaleTerminal _terminal;
        [SetUp]
        public void Setup()
        {
            // Arrange
            var basket = new Basket();
            var priceList = new PriceList();
            var priceCalculator = new PriceCalculator();

            var terminal = new PointOfSaleTerminal(basket, priceList, priceCalculator);
            terminal.SetPricing(new List<IProduct>
            {
                new Product { UnitCode = "A", SingleUnitPrice = 1.25M, Discount = new Discount { Volume = 3, Price = 3M } },
                new Product { UnitCode = "B", SingleUnitPrice = 4.25M },
                new Product { UnitCode = "C", SingleUnitPrice = 1M, Discount = new Discount { Volume = 6, Price = 5M } },
                new Product { UnitCode = "D", SingleUnitPrice = 0.75M }
            });

            _terminal = terminal;
        }

        [TestCase("", 0.0)]
        [TestCase("A", 1.25)]
        [TestCase("AA", 2.5)]
        [TestCase("AAA", 3.0)]
        [TestCase("AAACCCCCC", 8)]
        [TestCase("AAABB", 11.5)]
        [TestCase("ABCDABA", 13.25)]
        [TestCase("CCCCCCC", 6.0)]
        [TestCase("ABCD", 7.25)]
        public void ScanShoppingList_CorrectResult(string shoppingList, decimal expectedResult)
        {
            // Act
            _terminal.Scan(shoppingList);
            var totalPrice = _terminal.CalculateTotal();

            // Assert
            Assert.AreEqual((double)expectedResult, (double)totalPrice);
        }

        [TestCase("QWERTY")]
        public void ScanNonExistProduct_ArgumentExceptionThrown(string shoppingList)
        {
            // Act
            // Assert
            Assert.Throws(typeof(ArgumentException), () => _terminal.Scan(shoppingList));
        }
    }
}