using System;

namespace DeliverySystem
{
    public class Scooter : Vehicle
    {
        private int batteryCapacity;
        private double batteryLevel;

        public Scooter(string brand, int year, double mileage, int capacity)
            : base(brand, year, mileage, 45.0)
        {
            batteryCapacity = capacity;
            batteryLevel = 100;
        }

        public override string GetInfo()
        {
            return $"Scooter: {brand} ({year}), Battery: {batteryLevel}% of {batteryCapacity}Ah";
        }

        public override void Move(double distance)
        {
            base.Move(distance);
            batteryLevel -= distance * 0.5;
            batteryLevel = Math.Max(0, batteryLevel);
        }

        public void Charge()
        {
            batteryLevel = 100.0;
            Console.WriteLine($"{brand} has been fully charged.");
        }
    }
}