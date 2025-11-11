using System;

namespace DeliverySystem
{
    public class Car : Vehicle
    {
        protected int doors;
        protected double fuelLevel;

        public Car(string brand, int year, double mileage, int doorCount)
            : base(brand, year, mileage, 180.0)
        {
            doors = doorCount;
            fuelLevel = 50.0;
        }

        public Car(string brand, int year, double mileage, int doorCount, double maxSpeed)
            : base(brand, year, mileage, maxSpeed)
        {
            doors = doorCount;
            fuelLevel = 50.0;
        }

        public override string GetInfo()
        {
            return $"Car: {brand} ({year}), Doors: {doors}, Fuel: {fuelLevel}L";
        }

        public override void Move(double distance)
        {
            base.Move(distance);
            fuelLevel -= distance * 0.1;
            fuelLevel = Math.Max(0, fuelLevel);
        }

        public void Refuel(double liters)
        {
            fuelLevel += liters;
            fuelLevel = Math.Min(50, fuelLevel);
        }
    }
}