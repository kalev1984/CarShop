using System;

namespace Domain
{
    public class Car
    {
        private string _name;
        public Car(string name)
        {
            if(String.IsNullOrWhiteSpace(name) || name.Length < 3)
            {
                throw new ArgumentException("Car name must be at least 3 characters");
            }
            _name = name;
        }

        public string GetCarName()
        {
            return _name;
        }

        public void SetCarName(string name)
        {
            if (String.IsNullOrWhiteSpace(name) || name.Length < 3)
            {
                throw new ArgumentException("Car name must be at least 3 characters");
            }
            _name = name;
        }
    }
}
