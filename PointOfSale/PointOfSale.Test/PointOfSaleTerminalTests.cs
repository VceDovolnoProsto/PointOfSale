using NUnit.Framework;
using System;
using System.Collections.Generic;
using PointOfSale.PriceCalculators;
using PointOfSale.Product;

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
            var terminal = new PointOfSaleTerminal();
            terminal.SetPricing(new List<IProduct>() {
                new Product.Product() { UnitCode = "A", PriceCalculator = new WholesalePriceCalculator(1.25M, 3, 3M)},
                new Product.Product() { UnitCode = "B", PriceCalculator = new SingleUnitPriceCalculator(4.25M) },
                new Product.Product() { UnitCode = "C", PriceCalculator = new WholesalePriceCalculator(1M, 6, 5M)},
                new Product.Product() { UnitCode = "D", PriceCalculator = new SingleUnitPriceCalculator(0.75M )},
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