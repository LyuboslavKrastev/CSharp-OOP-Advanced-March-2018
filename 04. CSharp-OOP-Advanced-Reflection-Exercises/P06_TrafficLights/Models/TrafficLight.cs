using System.Collections.Generic;

public class TrafficLight : ITrafficLight
{
    public ICollection<Light> Lights { get; private set; }

    public TrafficLight()
    {
        this.Lights = new List<Light>();
    }

    public void AddLight(Light light)
    {
        this.Lights.Add(light);
    }

    public void ChangeLights()
    {
        foreach (var light in Lights)
        {
            light.ChangeLight();
        }
    }

    public override string ToString()
    {
        return string.Join(" ", Lights);
    }
}
