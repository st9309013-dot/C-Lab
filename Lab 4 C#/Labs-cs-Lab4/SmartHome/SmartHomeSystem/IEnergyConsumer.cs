namespace SmartHomeSystem
{
    public interface IEnergyConsumer
    {
        int PowerConsumption { get; }
        string DeviceName { get; }
        double GetEnergyUsage(int hours);
    }
}