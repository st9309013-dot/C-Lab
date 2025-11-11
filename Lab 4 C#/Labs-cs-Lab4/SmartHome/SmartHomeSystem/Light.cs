using System;

namespace SmartHomeSystem
{
    public class Light : Device, IEnergyConsumer
    {
        public override void TurnOn()
        {
            if (IsOn) return;

            IsOn = true;
            Console.WriteLine($"{Name} засвітилася.");
        }

        public override void TurnOff()
        {
            if (!IsOn) return;

            IsOn = false;
            Console.WriteLine($"{Name} вимкнена.");
        }

        public int PowerConsumption => 60;
        public string DeviceName => Name;

        public double GetEnergyUsage(int hours)
        {
            return IsOn ? (PowerConsumption * hours) / 1000.0 : 0;
        }
    }
}