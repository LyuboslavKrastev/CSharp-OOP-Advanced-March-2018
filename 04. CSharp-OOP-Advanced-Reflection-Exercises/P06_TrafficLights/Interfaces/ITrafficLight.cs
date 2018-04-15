using System.Collections.Generic;

public interface ITrafficLight
    {
        ICollection<Light> Lights { get; }

        void ChangeLights();
    }
