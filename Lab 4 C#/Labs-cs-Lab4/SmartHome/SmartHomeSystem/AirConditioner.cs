using System;

namespace SmartHomeSystem
{
    public class AirConditioner : Device, IEnergyConsumer
    {
        public int PowerConsumption => 2000;
        public string DeviceName => Name;

        public override void TurnOn()
        {
            if (!IsOn)
            {
                IsOn = true;
                Console.WriteLine($"{Name} почав охолодження.");
            }
        }

        public override void TurnOff()
        {
            if (IsOn)
            {
                IsOn = false;
                Console.WriteLine($"{Name} зупинено.");
            }
        }

        public double GetEnergyUsage(int hours)
        {
            if (IsOn)
            {
                return (PowerConsumption * hours) / 1000.0;
            }
            else
            {
                return 0;
            }
        }
    }
}