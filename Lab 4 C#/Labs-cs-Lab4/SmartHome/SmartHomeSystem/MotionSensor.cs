using System;

namespace SmartHomeSystem
{
    public class MotionSensor : Device
    {
        public override void TurnOn()
        {
            if (IsOn) return;

            IsOn = true;
            Console.WriteLine($"{Name} активовано.");
        }

        public override void TurnOff()
        {
            if (!IsOn) return;

            IsOn = false;
            Console.WriteLine($"{Name} деактивовано.");
        }
    }
}