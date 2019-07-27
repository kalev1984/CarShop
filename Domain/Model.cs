using System;
using System.Collections.Generic;
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

        public Model(Car car, string name, int year, int price)
        {
            if (String.IsNullOrWhiteSpace(name) ||  name.Length < 3)
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

        public void SetModelName(string name)
        {
            if (String.IsNullOrWhiteSpace(name) || name.Length < 3)
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
        }
    }
}
