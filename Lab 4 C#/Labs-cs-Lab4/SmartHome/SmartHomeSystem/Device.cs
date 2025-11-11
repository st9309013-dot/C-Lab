using System;

namespace SmartHomeSystem
{
    public abstract class Device : ISwitchable
    {
        public string Name { get; set; }
        public bool IsOn { get; protected set; }

        public abstract void TurnOn();
        public abstract void TurnOff();

        public void PrintStatus()
        {
            string status = "вимкнено";
            if (IsOn)
            {
                status = "увімкнено";
            }
            Console.WriteLine(string.Format("{0}: {1}", Name, status));
        }
    }
}