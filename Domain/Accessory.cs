using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Accessory
    {
        private string _name;
        private int _price;
        public Accessory(string name, int price)
        {
            if (String.IsNullOrWhiteSpace(name) || name.Length < 3)
            {
                throw new ArgumentException("Accessory name must be at least 3 characters!");
            }
            if (price < 0)
            {
                throw new ArgumentException("Accessory price must be bigger than 0");
            }
            _name = name;
            _price = price;
        }

        public string GetAccessoryName()
        {
            return _name;
        }

        public int GetAccessoryPrice()
        {
            return _price;
        }

        public override string ToString()
        {
            return "Accessory: " + _name + ", Price: " + _price;
        }
    }
}
