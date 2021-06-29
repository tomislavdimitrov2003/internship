using Bakery.Core.Contracts;
using NUnit.Framework;
using Bakery.Core;
using Bakery.Models.Tables.Contracts;
using Bakery.Models.Tables;

namespace BakeryTest
{
    [TestFixture]
    public class ControllerTest
    {
        [Test]
        public void AddDrinkTest()
        {
            //Arange
            string type = "Tea";
            string name = "Healthy";
            int portion = 500;
            string brand = "Nestea";
            IController controller = new Controller();

            //Act
            string result = controller.AddDrink(type, name, portion, brand);
            
            //Assert
            Assert.AreEqual("Added Healthy (Nestea) to the drink menu", result);
        }

        [Test]
        public void AddFoodTest()
        {
            //Arange
            string type = "Bread";
            string name = "White";
            decimal price = 2.90M;
            IController controller = new Controller();

            //Act
            string result = controller.AddFood(type, name, price);

            //Assert
            Assert.AreEqual("Added White (Bread) to the menu", result);
        }

        [Test]
        public void AddTableTest()
        {
            //Arange
            string type = "InsideTable";
            int tableNumber = 1;
            int capacity = 10;
            IController controller = new Controller();

            //Act
            string result = controller.AddTable(type, tableNumber, capacity);

            //Assert
            Assert.AreEqual("Added table number 1 in the bakery", result);
        }

        [Test]
        public void GetFreeTablesInfoTest()
        {
            //Arange
            IController controller = new Controller();
            controller.AddTable("InsideTable", 1, 10);
            controller.AddTable("InsideTable", 2, 20);
            controller.ReserveTable(4);
            //Act
            string result = controller.GetFreeTablesInfo();

            //Assert
            Assert.AreEqual("Table: 2\nType: InsideTable\nCapacity: 20\nPrice Per Person: 2.5\n", result);
        }

        [Test]
        public void GetTotalIncome()
        {
            //Arrange
            IController controller = new Controller();
            controller.AddFood("Bread", "White", 2.9M);
            controller.AddDrink("Water", "Spring", 500, "Divna");
            controller.AddTable("InsideTable", 1, 10);
            controller.ReserveTable(5);
            controller.OrderFood(1, "White");
            controller.OrderDrink(1, "Spring", "Divna");
            controller.LeaveTable(1);

            //Act
            string result = controller.GetTotalIncome();

            //Assert
            Assert.AreEqual("Total income: 16.90lv", result);
        }

        [Test]
        public void OrderFoodTest() 
        {
            //Arrange
            IController controller = new Controller();
            controller.AddFood("Bread", "White", 2.9M);
            controller.AddTable("InsideTable", 1, 10);
            controller.ReserveTable(5);

            //Act
            string result = controller.OrderFood(1, "White");

            //Assert
            Assert.AreEqual("Table 1 ordered White", result);
        }

        [Test]
        public void OrderFoodWrongTableNumberTest()
        {
            //Arrange
            IController controller = new Controller();
            controller.AddFood("Bread", "White", 2.9M);
            controller.AddTable("InsideTable", 1, 10);
            controller.ReserveTable(5);

            //Act
            string result = controller.OrderFood(2, "White");

            //Assert
            Assert.AreEqual("Could not find table 2", result);
        }


        [Test]
        public void OrderFoodWrongFoodNameTest()
        {
            //Arrange
            IController controller = new Controller();
            controller.AddFood("Bread", "White", 2.9M);
            controller.AddTable("InsideTable", 1, 10);
            controller.ReserveTable(5);

            //Act
            string result = controller.OrderFood(1, "Black");

            //Assert
            Assert.AreEqual("No Black in the menu", result);
        }

        [Test]
        public void OrderDrinkTest()
        {
            //Arrange
            IController controller = new Controller();
            controller.AddDrink("Water", "Spring", 500, "Divna");
            controller.AddTable("InsideTable", 1, 10);
            controller.ReserveTable(5);

            //Act
            string result = controller.OrderDrink(1, "Spring", "Divna");

            //Assert
            Assert.AreEqual("Table 1 ordered Spring", result);
        }

        [Test]
        public void OrderDrinkWrongTableNumberTest()
        {
            //Arrange
            IController controller = new Controller();
            controller.AddDrink("Water", "Spring", 500, "Divna");
            controller.AddTable("InsideTable", 1, 10);
            controller.ReserveTable(5);

            //Act
            string result = controller.OrderDrink(2, "Spring", "Divna");

            //Assert
            Assert.AreEqual("Could not find table 2", result);
        }


        [Test]
        public void OrderDrinkWrongDrinkNameTest()
        {
            //Arrange
            IController controller = new Controller();
            controller.AddDrink("Water", "Spring", 500, "Divna");
            controller.AddTable("InsideTable", 1, 10);
            controller.ReserveTable(5);

            //Act
            string result = controller.OrderDrink(1, "Cheshmqna", "CEZ");

            //Assert
            Assert.AreEqual("There is no Cheshmqna CEZ available", result);
        }

        [Test]
        public void ReserveTableTest()
        {
            //Arrange
            IController controller = new Controller();
            controller.AddTable("InsideTable", 1, 10);
            
            //Act
            string result = controller.ReserveTable(5);

            //Assert
            Assert.AreEqual("Table 1 has been reserved for 5 people", result);
        }

        [Test]
        public void ReserveTableNoAvailableTest()
        {
            //Arrange
            IController controller = new Controller();
            controller.AddTable("InsideTable", 1, 10);

            //Act
            string result = controller.ReserveTable(15);

            //Assert
            Assert.AreEqual("No available table for 15 people", result);
        }
    }
}