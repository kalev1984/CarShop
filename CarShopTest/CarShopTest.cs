using System;
using System.Collections.Generic;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarShopTest
{
    [TestClass]
    public class CarShopTest
    {
        [TestMethod]
        public void CarHasName()
        {
            Car c1 = new Car("Opel");
            Assert.AreEqual(c1.GetCarName(), "Opel");
        }

        [TestMethod]
        public void CarChangeName()
        {
            Car c1 = new Car("Opel");
            c1.SetCarName("Toyota");
            Assert.AreEqual(c1.GetCarName(), "Toyota");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Car name must be at least 3 characters")]
        public void CarEmptyNameThrowsError()
        {
            _ = new Car("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Car name must be at least 3 characters")]
        public void CarNullNameThrowsError()
        {
            _ = new Car(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Car name must be at least 3 characters")]
        public void CarNameTooSmallThrowsError()
        {
            _ = new Car("ab");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Car name must be at least 3 characters")]
        public void CarSetNameEmptyStringThrowsError()
        {
            Car c = new Car("car");
            c.SetCarName("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Car name must be at least 3 characters")]
        public void CarSetNameNullThrowsError()
        {
            Car c = new Car("car");
            c.SetCarName(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Car name must be at least 3 characters")]
        public void CarSetNameTooSmallThrowsError()
        {
            Car c = new Car("car");
            c.SetCarName("ab");
        }

        [TestMethod]
        public void ModelHasNamePriceAndYear()
        {
            Car opel = new Car("Opel");
            Model omega = new Model(opel, "Omega", 2002, 1500);
            Assert.AreEqual(omega.GetModelName(), "Omega");
            Assert.AreEqual(omega.GetModelYear(), 2002);
            Assert.AreEqual(omega.GetModelPrice(), 1500);
        }

        [TestMethod]
        public void ModelChangeNamePriceAndYear()
        {
            Car toyota = new Car("Toyota");
            Model avensis = new Model(toyota, "Avensis", 2013, 7500);
            avensis.SetModelName("Corolla");
            avensis.SetModelYear(2006);
            avensis.SetModelPrice(5000);
            Assert.AreEqual(avensis.GetModelName(), "Corolla");
            Assert.AreEqual(avensis.GetModelYear(), 2006);
            Assert.AreEqual(avensis.GetModelPrice(), 5000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Model name must be at least 3 characters")]
        public void ModelNameTooSmallThrowsError()
        {
            Car c = new Car("car");
            _ = new Model(c, "ab", 2002, 1400);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Model name must be at least 3 characters")]
        public void ModelNameEmptyStringThrowsError()
        {
            Car c = new Car("car");
            _ = new Model(c, "", 2002, 1400);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Model name must be at least 3 characters")]
        public void ModelNameIsNullThrowsError()
        {
            Car c = new Car("car");
            _ = new Model(c, null, 2002, 1400);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Model year must be in range between 1960 and current year")]
        public void ModelYearIsTooSmallThrowsError()
        {
            Car c = new Car("car");
            _ = new Model(c, "model", 0, 1400);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Model year must be in range between 1960 and current year")]
        public void ModelYearIsTooBigThrowsError()
        {
            Car c = new Car("car");
            _ = new Model(c, "model", 3000, 1400);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Model price cannot be smaller than 1")]
        public void ModelPriceIsTooSmallThrowsError()
        {
            Car c = new Car("car");
            _ = new Model(c, "model", 2013, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Model price cannot be smaller than 1")]
        public void ModelSetPriceIsTooSmallThrowsError()
        {
            Car c = new Car("car");
            Model m = new Model(c, "model", 2013, 1500);
            m.SetModelPrice(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Model name must be at least 3 characters")]
        public void ModelSetNameIsTooSmallThrowsError()
        {
            Car c = new Car("car");
            Model m = new Model(c, "model", 2013, 1500);
            m.SetModelName("ab");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Model name must be at least 3 characters")]
        public void ModelSetNameIsEmptyThrowsError()
        {
            Car c = new Car("car");
            Model m = new Model(c, "model", 2013, 1500);
            m.SetModelName("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Model name must be at least 3 characters")]
        public void ModelSetNameIsNullThrowsError()
        {
            Car c = new Car("car");
            Model m = new Model(c, "model", 2013, 1500);
            m.SetModelName(null);
        }

        [TestMethod]
        public void GetModelPrice()
        {
            Car c = new Car("car");
            Model m = new Model(c, "model", 2013, 1500);
            Assert.AreEqual(m.GetModelPrice(), 1500);
        }

        [TestMethod]
        public void GetModelDiscount()
        {
            Car c = new Car("car");
            Model m = new Model(c, "model", 2013, 1500);
            Assert.AreEqual(m.GetModelDiscount(), 0);
        }

        [TestMethod]
        public void SetModelDiscount()
        {
            Car c = new Car("car");
            Model m = new Model(c, "model", 2013, 1500);
            m.SetModelDiscount(20);
            Assert.AreEqual(m.GetModelDiscount(), 20);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Discount cannot be less than 0 and more than 100")]
        public void ModelSetDiscountTooSmallThrowsError()
        {
            Car c = new Car("car");
            Model m = new Model(c, "model", 2013, 1500);
            m.SetModelDiscount(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Discount cannot be less than 0 and more than 100")]
        public void ModelSetDiscountTooBigThrowsError()
        {
            Car c = new Car("car");
            Model m = new Model(c, "model", 2013, 1500);
            m.SetModelDiscount(150);
        }

        [TestMethod]
        public void ModelCalculateDiscountPrice()
        {
            Car c = new Car("car");
            Model m = new Model(c, "model", 2013, 1500);
            m.SetModelDiscount(20);
            Assert.AreEqual(m.GetModelDiscount(), 20);
            Assert.AreEqual(m.GetModelPrice(), 1200);
        }

        [TestMethod]
        public void AccessoryHasNameAndPrice() {
            Accessory a = new Accessory("LED lights", 200);
            Assert.AreEqual(a.GetAccessoryName(), "LED lights");
            Assert.AreEqual(a.GetAccessoryPrice(), 200);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Accessory name must be at least 3 characters!")]
        public void AccessoryNameMinimumLengthThrowsError()
        {
            Accessory a = new Accessory("ab", 200);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Accessory name must be at least 3 characters!")]
        public void AccessoryNameCannotBeNullThrowsError()
        {
            Accessory a = new Accessory(null, 200);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Accessory name must be at least 3 characters!")]
        public void AccessoryNameCannotBeEmptyThrowsError()
        {
            Accessory a = new Accessory("", 200);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Accessory price must be bigger than 0")]
        public void AccessoryPriceCannotBeLessThanZeroThrowsError()
        {
            Accessory a = new Accessory("accessory", -1);
        }

        [TestMethod]
        public void AddAccessoryToModel()
        {
            Accessory a = new Accessory("abc", 100);
            Car c = new Car("abc");
            Model m = new Model(c, "abc", 1984, 1500);
            m.AddModelAccessory(a);
            Assert.AreEqual(m.GetModelAccessories().Count, 1);
        }

        [TestMethod]
        public void AddAccessoryToPrice()
        {
            Accessory a = new Accessory("abc", 100);
            Car c = new Car("abc");
            Model m = new Model(c, "abc", 1984, 1500);
            m.AddModelAccessory(a);
            Assert.AreEqual(m.GetModelPrice(), 1600);
        }

        [TestMethod]
        public void NoDiscountToAccessory()
        {
            Accessory a = new Accessory("abc", 100);
            Car c = new Car("abc");
            Model m = new Model(c, "abc", 1984, 1500);
            m.AddModelAccessory(a);
            m.SetModelDiscount(20);
            Assert.AreEqual(m.GetModelPrice(), 1300);
        }

        [TestMethod]
        public void NoDiscountToAccessories()
        {
            Accessory a = new Accessory("abc", 100);
            Accessory b = new Accessory("def", 200);
            Car c = new Car("abc");
            Model m = new Model(c, "abc", 1984, 1500);
            m.AddModelAccessory(a);
            m.AddModelAccessory(b);
            m.SetModelDiscount(20);
            Assert.AreEqual(m.GetModelPrice(), 1500);
        }

        [TestMethod]
        public void NoDiscountWithAccessory()
        {
            Accessory a = new Accessory("abc", 100);
            Car c = new Car("abc");
            Model m = new Model(c, "abc", 1984, 1500);
            m.AddModelAccessory(a);
            Assert.AreEqual(m.GetModelPrice(), 1600);
        }

        [TestMethod]
        public void NoDiscountWithAccessories()
        {
            Accessory a = new Accessory("abc", 100);
            Accessory b = new Accessory("def", 200);
            Car c = new Car("abc");
            Model m = new Model(c, "abc", 1984, 1500);
            m.AddModelAccessory(a);
            m.AddModelAccessory(b);
            Assert.AreEqual(m.GetModelPrice(), 1800);
        }

        [TestMethod]
        public void CarToString()
        {
            Car c = new Car("abc");
            Assert.AreEqual(c.ToString(), "Car: abc");
        }

        [TestMethod]
        public void AccessoryToString()
        {
            Accessory a = new Accessory("abc", 100);
            Assert.AreEqual(a.ToString(), "Accessory: abc, Price: 100");
        }

        [TestMethod]
        public void ModelToString()
        {
            Car c = new Car("abc");
            Model m = new Model(c, "abc", 1984, 1500);
            Assert.AreEqual(m.ToString(), "Car: abc, Model: abc, Year: 1984, Price: 1500, Discount: 0");
        }

        [TestMethod]
        public void ModelToStringAlsoListsAccessories()
        {
            Car c = new Car("abc");
            Model m = new Model(c, "abc", 1984, 1500);
            m.AddModelAccessory(new Accessory("Cruise Control", 500));
            m.AddModelAccessory(new Accessory("Trolley Hook", 200));
            Assert.AreEqual(
                m.ToString(),
                "Car: abc, Model: abc, Year: 1984, Price: 1500, Discount: 0 with following accessories: " +
                "Accessory: Cruise Control, Price: 500, Accessory: Trolley Hook, Price: 200");
        }
    }
}   
