using System;

namespace DeliverySystem
{
    public class Vehicle
    {
        protected string brand;
        protected double mileage;
        protected int year;
        protected double maxSpeed;

        public Vehicle(string brandName, int carYear, double currentMileage, double topSpeed)
        {
            brand = brandName;
            year = carYear;
            mileage = currentMileage;
            maxSpeed = topSpeed;
        }

        public virtual void Move(double distance)
        {
            mileage += distance;
            Console.WriteLine($"{brand} drove {distance} km.");
        }

        public virtual string GetInfo()
        {
            return string.Format("{0} ({1}), Mileage: {2} km", brand, year, mileage);
        }

        public virtual double GetMaxSpeed()
        {
            return maxSpeed;
        }
    }
}