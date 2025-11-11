using System;
using System.Collections.Generic;

namespace SmartHomeSystem
{
    public class SmartHomeController
    {
        private List<ISwitchable> _allDevices = new List<ISwitchable>();
        private List<IEnergyConsumer> _energyDevices = new List<IEnergyConsumer>();

        public void AddDevice(ISwitchable device)
        {
            _allDevices.Add(device);
        }

        public void AddEnergyDevice(IEnergyConsumer device)
        {
            _energyDevices.Add(device);
        }

        public void TurnAllOn()
        {
            for (int i = 0; i < _allDevices.Count; i++)
            {
                _allDevices[i].TurnOn();
            }
        }

        public void TurnAllOff()
        {
            for (int i = 0; i < _allDevices.Count; i++)
            {
                _allDevices[i].TurnOff();
            }
        }

        public void ShowEnergyReport(int hours)
        {
            Console.WriteLine(string.Format("\nЗвіт про споживання енергії за {0} год:", hours));

            double totalUsage = 0;

            foreach (var consumer in _energyDevices)
            {
                double deviceUsage = consumer.GetEnergyUsage(hours);
                totalUsage += deviceUsage;

                Console.WriteLine(
                    string.Format("- {0}: {1:F2} кВт·год (потужність: {2} Вт)",
                        consumer.DeviceName,
                        deviceUsage,
                        consumer.PowerConsumption)
                );
            }

            double totalCost = totalUsage * 4.0;
            Console.WriteLine(string.Format("Загальне споживання: {0:F2} кВт·год", totalUsage));
            Console.WriteLine(string.Format("Вартість (~4 грн/кВт·год): {0:F2} грн", totalCost));
        }
    }
}