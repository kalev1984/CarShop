using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Model
    {
        private Car _car;
        private string _name;
        private int _year;
        private int _price;
        private int _discount;
        //private int _old_discount;
        private List<Accessory> _accessories = new List<Accessory>();
        private int _accessoryPrice;

        public Model(Car car, string name, int year, int price)
        {
            if (string.IsNullOrWhiteSpace(name) ||  name.Length < 3)
            {
                throw new ArgumentException("Model name must be at least 3 characters");
            }
            if (year < 1960 || year > DateTime.Now.Year)
            {
                throw new ArgumentException("Model year must be in range between 1960 and current year");
            }
            if (price < 1)
            {
                throw new ArgumentException("Model price cannot be smaller than 1");
            }

            _car = car;
            _name = name;
            _year = year;
            _price = price; 
        }

        public string GetModelName()
        {
            return _name;
        }

        public int GetModelYear()
        {
            return _year;
        }

        public int GetModelPrice()
        {
            return _price;
        }

        public Car GetModelCar()
        {
            return _car;
        }

        public void SetModelCar(Car car)
        {
            _car = car;
        }

        public void SetModelName(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
            {
                throw new ArgumentException("Model name must be at least 3 characters");
            }
            _name = name;
        }

        public void SetModelYear(int year)
        {
            _year = year;
        }

        public void SetModelPrice(int price)
        {
            if (price < 1)
            {
                throw new ArgumentException("Model price cannot be smaller than 1");
            }
            _price = price;
        }

        public int GetModelDiscount()
        {
            return _discount;
        }

        public void SetModelDiscount(int discount)
        {
            if(discount < 0 || discount > 100)
            {
                throw new ArgumentException("Discount cannot be less than 0 and more than 100");
            }
            _discount = discount;
            _price = ((_price - _accessoryPrice) * (100 - discount) / 100) + _accessoryPrice;
        }

        public void AddModelAccessory(Accessory a)
        {
            _accessories.Add(a);
            var price = _price - _accessoryPrice;
            _accessoryPrice += a.GetAccessoryPrice();
            _price = price + _accessoryPrice;
        }

        public List<Accessory> GetModelAccessories()
        {
            return _accessories;
        }

        public override string ToString()
        {
            string s = "Car: " + _car.GetCarName() + ", Model: " + _name + ", Year: " + _year + ", Price: " + _price + ", Discount: " + _discount;
            if (_accessories.Count == 0)
            {
                return s;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(s);
            sb.Append(" with following accessories: ");
            foreach(var i in _accessories)
            {
                sb.Append(i.ToString());
                sb.Append(", ");
            }
            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            var m = (Model)obj;
            var endResult = 
                _car.Equals(m.GetModelCar()) 
                && _name.Equals(m.GetModelName()) 
                && _year == m.GetModelYear() 
                && _price == m.GetModelPrice()
                && _discount == m.GetModelDiscount();

            if (_accessories.Count == 0 && m.GetModelAccessories().Count == 0)
            {
                return endResult;
            }

            if (_accessories.Count != m.GetModelAccessories().Count)
            {
                return false;
            }

            return !_accessories.Where((t, i) => t.Equals(m.GetModelAccessories()[i]) != true).Any() && endResult;
        }
    }
}
