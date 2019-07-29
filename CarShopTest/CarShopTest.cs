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
        public void TestCarReturnName()
        {
            var expected = "Opel";

            var c1 = new Car("Opel");

            Assert.AreEqual(expected, c1.GetCarName());
        }

        [TestMethod]
        public void TestCarChangeName()
        {
            var c1 = new Car("Opel");
            var expected = "Toyota";

            c1.SetCarName("Toyota");

            Assert.AreEqual(expected, c1.GetCarName());
        }

        [TestMethod]
        public void TestCarEmptyNameThrows()
        {
            Assert.ThrowsException<System.ArgumentException>(() => new Car(""));
        }

        [TestMethod]
        public void TestCarNameLessThanThreeCharactersThrows()
        {
            Assert.ThrowsException<System.ArgumentException>(() => new Car("12"));
        }

        [TestMethod]
        public void TestCarNameNullThrows()
        {
            Assert.ThrowsException<System.ArgumentException>(() => new Car(null));
        }

        [TestMethod]
        public void TestCarSetNameEmptyThrows()
        {
            var c = new Car("car");

            Assert.ThrowsException<System.ArgumentException>(() => c.SetCarName(""));
        }

        [TestMethod]
        public void TestCarSetName_LessThan_ThreeCharacters_Throws()
        {
            var c = new Car("car");

            Assert.ThrowsException<System.ArgumentException>(() => c.SetCarName("12"));
        }

        [TestMethod]
        public void TestCarSetNameNullThrows()
        {
            var c = new Car("car");

            Assert.ThrowsException<System.ArgumentException>(() => c.SetCarName(null));
        }

        [TestMethod]
        public void TestModelReturnsName()
        {
            var opel = new Car("Opel");
            var expected = "Omega";

            var omega = new Model(opel, "Omega", 2002, 1500);

            Assert.AreEqual(expected, omega.GetModelName());
        }

        [TestMethod]
        public void TestModelReturnsYear()
        {
            var opel = new Car("Opel");
            var expected = 2002;

            var omega = new Model(opel, "Omega", 2002, 1500);

            Assert.AreEqual(expected, omega.GetModelYear());
        }

        [TestMethod]
        public void TestModelReturnsPrice()
        {
            var opel = new Car("Opel");
            var expected = 1500;

            var omega = new Model(opel, "Omega", 2002, 1500);

            Assert.AreEqual(expected, omega.GetModelPrice());
        }

        [TestMethod]
        public void TestModelChangeName()
        {
            var toyota = new Car("Toyota");
            var expected = "Corolla";

            var m = new Model(toyota, "Avensis", 2013, 7500);
            m.SetModelName("Corolla");

            Assert.AreEqual(expected, m.GetModelName());
        }

        [TestMethod]
        public void TestModelChangeYear()
        {
            var toyota = new Car("Toyota");
            var expected = 2006;

            var m = new Model(toyota, "Avensis", 2013, 7500);
            m.SetModelYear(2006);

            Assert.AreEqual(expected, m.GetModelYear());
        }

        [TestMethod]
        public void TestModelChangePrice()
        {
            var toyota = new Car("Toyota");
            var expected = 5000;

            var m = new Model(toyota, "Avensis", 2013, 7500);
            m.SetModelPrice(5000);
          
            Assert.AreEqual(expected, m.GetModelPrice());
        }

        [TestMethod]
        public void TestModelEmptyNameThrows()
        {
            var c = new Car("car");

            Assert.ThrowsException<System.ArgumentException>(() => new Model(c, "", 2000, 2000));
        }

        [TestMethod]
        public void TestModelNameLessThanThreeCharactersThrows()
        {
            var c = new Car("car");

            Assert.ThrowsException<System.ArgumentException>(() => new Model(c, "12", 2000, 2000));
        }

        [TestMethod]
        public void TestModelNameNullThrows()
        {
            var c = new Car("car");

            Assert.ThrowsException<System.ArgumentException>(() => new Model(c, null, 2000, 2000));
        }

        [TestMethod]
        public void TestModelYearLessThan1960()
        {
            var c = new Car("car");

            Assert.ThrowsException<System.ArgumentException>(() => new Model(c, "model", 1959, 2000));
        }

        [TestMethod]
        public void TestModelYearBiggerThanCurrentYear()
        {
            var c = new Car("car");

            Assert.ThrowsException<System.ArgumentException>(() => new Model(c, "model", 2020, 2000));
        }

        [TestMethod]
        public void TestModelPriceIsLessThanOneThrows()
        {
            var c = new Car("car");
         
            Assert.ThrowsException<System.ArgumentException>(() => new Model(c, "model", 2020, 0));
        }

        [TestMethod]
        public void TestModelPriceIsNegativeThrows()
        {
            var c = new Car("car");

            Assert.ThrowsException<System.ArgumentException>(() => new Model(c, "model", 2020, -2));
        }

        [TestMethod]
        public void TestModelChangePriceToLessThanOneThrows()
        {
            var c = new Car("car");

            Assert.ThrowsException<System.ArgumentException>(() => new Model(c, "model", 2020, 2000).SetModelPrice(0));
        }

        [TestMethod]
        public void TestModelChangePriceToNegativeThrows()
        {
            var c = new Car("car");

            Assert.ThrowsException<System.ArgumentException>(() => new Model(c, "model", 2020, 2000).SetModelPrice(-2));
        }

        [TestMethod]
        public void TestModelChangeNameTooSmallThrows()
        {
            var c = new Car("car");

            Assert.ThrowsException<System.ArgumentException>(() => new Model(c, "model", 2020, 2000).SetModelName("12"));
        }

        [TestMethod]
        public void TestModelChangeNameToEmptyThrows()
        {
            var c = new Car("car");

            Assert.ThrowsException<System.ArgumentException>(() => new Model(c, "model", 2020, 2000).SetModelName(""));
        }

        [TestMethod]
        public void TestModelChangeNameToNullThrows()
        {
            var c = new Car("car");

            Assert.ThrowsException<System.ArgumentException>(() => new Model(c, "model", 2020, 2000).SetModelName(null));
        }

        [TestMethod]
        public void TestModelReturnDefaultDiscount()
        {
            var c = new Car("car");
            var expected = 0;

            var m = new Model(c, "model", 2013, 1500);

            Assert.AreEqual(expected, 0);
        }

        [TestMethod]
        public void TestModelChangeDiscount()
        {
            var c = new Car("car");
            var expected = 20;

            var m = new Model(c, "model", 2013, 1500);
            m.SetModelDiscount(20);

            Assert.AreEqual(expected, m.GetModelDiscount());
        }

        [TestMethod]
        public void TestModelChangeDiscountLessThanZeroThrows()
        {
            var c = new Car("car");
            
            Assert.ThrowsException<System.ArgumentException>(() => new Model(c, "model", 2020, 2000).SetModelDiscount(-1));
        }

        [TestMethod]
        public void TestModelChangeDiscountBiggerThanHundred()
        {
            var c = new Car("car");

            Assert.ThrowsException<System.ArgumentException>(() => new Model(c, "model", 2020, 2000).SetModelDiscount(101));
        }

        [TestMethod]
        public void TestModelCalculateDiscountPrice()
        {
            var c = new Car("car");
            var expected = 1200;

            var m = new Model(c, "model", 2013, 1500);
            m.SetModelDiscount(20);

            Assert.AreEqual(expected, m.GetModelPrice());
        }

        [TestMethod]
        public void TestAccessoryReturnsName() {
            var a = new Accessory("LED lights", 200);
            var expected = "LED lights";

            Assert.AreEqual(expected, a.GetAccessoryName());
        }

        [TestMethod]
        public void TestAccessoryReturnsPrice()
        {
            var a = new Accessory("LED lights", 200);
            var expected = 200;

            Assert.AreEqual(expected, a.GetAccessoryPrice());
        }

        [TestMethod]
        public void TestAccessoryNameLessThanThreeThrows()
        {
            Assert.ThrowsException<System.ArgumentException>(() => new Accessory("12", 100));
        }

        [TestMethod]
        public void TestAccessoryNameNullThrows()
        {
            Assert.ThrowsException<System.ArgumentException>(() => new Accessory(null, 100));
        }

        [TestMethod]
        public void TestAccessoryNameEmptyThrows()
        {
            Assert.ThrowsException<System.ArgumentException>(() => new Accessory("", 100));
        }

        [TestMethod]
        public void TestAccessoryPriceSmallerThanOneThrows()
        {
            Assert.ThrowsException<System.ArgumentException>(() => new Accessory("abc", 0));
        }

        [TestMethod]
        public void TestAccessoryPriceSmallerThanZeroThrows()
        {
            Assert.ThrowsException<System.ArgumentException>(() => new Accessory("abc", -1));
        }

        [TestMethod]
        public void TestModelAddAccessory()
        {
            var c = new Car("abc");
            var expected = 1;

            var m = new Model(c, "abc", 1984, 1500);
            var a = new Accessory("abc", 100);
            m.AddModelAccessory(a);

            Assert.AreEqual(expected, m.GetModelAccessories().Count);
        }

        [TestMethod]
        public void TestModelPriceWithAccessory()
        {
            var c = new Car("abc");
            var expected = 1600;

            var a = new Accessory("abc", 100);
            var m = new Model(c, "abc", 1984, 1500);
            m.AddModelAccessory(a);

            Assert.AreEqual(expected, m.GetModelPrice());
        }

        [TestMethod]
        public void TestModelDiscountDoesNotApplyToAccessory()
        {
            var c = new Car("abc");
            var expected = 1300;

            var a = new Accessory("abc", 100);
            var m = new Model(c, "abc", 1984, 1500);
            m.AddModelAccessory(a);
            m.SetModelDiscount(20);

            Assert.AreEqual(expected, m.GetModelPrice());
        }

        [TestMethod]
        public void TestModelDiscountDoesNotApplyToAccessories()
        {
            var c = new Car("abc");
            var expected = 1500;

            var a = new Accessory("abc", 100);
            var b = new Accessory("def", 200);
            var m = new Model(c, "abc", 1984, 1500);
            m.AddModelAccessory(a);
            m.AddModelAccessory(b);
            m.SetModelDiscount(20);

            Assert.AreEqual(expected, m.GetModelPrice());
        }

        [TestMethod]
        public void TestCarToStringOverride()
        {
            var expected = "Car: abc";

            var c = new Car("abc");

            Assert.AreEqual(expected, c.ToString());
        }

        [TestMethod]
        public void TestAccessoryOverrideToString()
        {
            var expected = "Accessory: abc, Price: 100";

            var a = new Accessory("abc", 100);

            Assert.AreEqual(expected, a.ToString());
        }

        [TestMethod]
        public void TestModelOverrideToString()
        {
            var c = new Car("abc");
            var expected = "Car: abc, Model: abc, Year: 1984, Price: 1500, Discount: 0";

            var m = new Model(c, "abc", 1984, 1500);

            Assert.AreEqual(expected, m.ToString());
        }

        [TestMethod]
        public void TestModelOverrideToStringWithAccessories()
        {
            var c = new Car("abc");
            var expected = "Car: abc, Model: abc, Year: 1984, Price: 1500, Discount: 0 with following accessories: " +
                "Accessory: Cruise Control, Price: 500, Accessory: Trolley Hook, Price: 200";

            var m = new Model(c, "abc", 1984, 1500);
            m.AddModelAccessory(new Accessory("Cruise Control", 500));
            m.AddModelAccessory(new Accessory("Trolley Hook", 200));

            Assert.AreEqual(expected, m.ToString());
        }

        [TestMethod]
        public void TestCarOverrideEquals()
        {
            var c = new Car("abc");
            var expected = true;

            var d = new Car("abc");

            Assert.AreEqual(expected, c.Equals(d));
        }

        [TestMethod]
        public void TestAccessoryOverrideEquals()
        {
            var c = new Accessory("abc", 100);
            var expected = true;

            var d = new Accessory("abc", 100);

            Assert.AreEqual(expected, c.Equals(d));
        }

        [TestMethod]
        public void TestModelOverrideEqualsNoAccessories()
        {
            var c = new Car("abc");
            var expected = true;

            var m1 = new Model(c, "model", 2000, 2000);
            var m2 = new Model(c, "model", 2000, 2000);

            Assert.AreEqual(expected, m1.Equals(m2));
        }

        [TestMethod]
        public void TestModelOverrideEqualsOneModelHasAccessories()
        {
            var c = new Car("abc");
            var expected = false;

            var m1 = new Model(c, "model", 2000, 2000);
            var m2 = new Model(c, "model", 2000, 2000);
            var a = new Accessory("abc", 100);
            m1.AddModelAccessory(a);

            Assert.AreEqual(expected, m1.Equals(m2));
        }

        [TestMethod]
        public void TestModelOverrideEqualsBothHaveAccessories()
        {
            var c = new Car("abc");
            var expected = true;

            var m1 = new Model(c, "model", 2000, 2000);
            var m2 = new Model(c, "model", 2000, 2000);
            var a = new Accessory("abc", 100);
            m1.AddModelAccessory(a);
            m2.AddModelAccessory(a);


            Assert.AreEqual(expected, m1.Equals(m2));
        }

        [TestMethod]
        public void TestModelReturnCar()
        {
            var c = new Car("abc");
            var expected = true;

            var d = new Model(c, "abc", 2000, 2000);

            Assert.AreEqual(expected, d.GetModelCar().Equals(c));
        }

        [TestMethod]
        public void TestModelChangeCar()
        {
            var c = new Car("abc");
            var expected = false;

            var d = new Model(c, "abc", 2000, 2000);
            d.SetModelCar(new Car("bcd"));

            Assert.AreEqual(expected, d.GetModelCar().Equals(c));
        }
    }
}   
