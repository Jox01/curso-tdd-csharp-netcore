
using System.Collections.Generic;
using NUnit.Framework;

namespace ArgentRose.Tests
{
    public class ArgentRoseTest
    {


        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void Update_EmptyInventory()
        {
            Inventory inventory = new();

            inventory.Update();
            
            Inventory expectedInventory = new Inventory();
            Assert.That(inventory, Is.EqualTo(expectedInventory));
        }

        [Test]
        public void Update_Regular()
        {
            Inventory inventory = new();
            Product regularProduct = new Product("Corcho", 3, 6);

            inventory.AddProduct(regularProduct);

            inventory.Update();

            Inventory expectedInventory = new Inventory();
            expectedInventory.AddProduct(new Product("Corcho", 1, 5));
            Assert.That(inventory, Is.EqualTo(expectedInventory));
        }

        [Test]
        public void Update_Regulars()
        {
            Inventory inventory = new();

            inventory.AddProduct(new Product("Corcho", 3, 6));
            inventory.AddProduct(new Product("Corcho", 3, 6));

            inventory.Update();

            Inventory expectedInventory = new Inventory();
            expectedInventory.AddProduct(new Product("Corcho", 1, 5));
            expectedInventory.AddProduct(new Product("Corcho", 1, 5));
            Assert.That(inventory, Is.EqualTo(expectedInventory));
        }
    }
}
