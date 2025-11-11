using System;

namespace SmartHomeSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            SmartHomeController controller = new SmartHomeController();

            Light light = new Light();
            light.Name = "Лампа у вітальні";

            AirConditioner ac = new AirConditioner();
            ac.Name = "Кондиціонер у спальні";

            CoffeeMachine coffeeMachine = new CoffeeMachine();
            coffeeMachine.Name = "Кавомашина на кухні";

            MotionSensor sensor = new MotionSensor();
            sensor.Name = "Датчик руху у коридорі";

            controller.AddDevice(light);
            controller.AddEnergyDevice(light);

            controller.AddDevice(ac);
            controller.AddEnergyDevice(ac);

            controller.AddDevice(coffeeMachine);
            controller.AddEnergyDevice(coffeeMachine);

            controller.AddDevice(sensor);

            controller.TurnAllOn();

            Console.WriteLine();
            light.PrintStatus();
            ac.PrintStatus();
            coffeeMachine.PrintStatus();
            sensor.PrintStatus();

            controller.ShowEnergyReport(5);

            Console.WriteLine();
            controller.TurnAllOff();
        }
    }
}