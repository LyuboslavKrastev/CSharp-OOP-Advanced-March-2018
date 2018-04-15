using System;

public class Light
{
    private LightType lightType { get; set; }

    public Light(string light)
    {
        if (Enum.TryParse(typeof(LightType), light, out object validLight))
        {
            this.lightType = (LightType)validLight;
        }
        else
        {
            throw new ArgumentException("Invalid Light Type!");
        }
    }

    public void ChangeLight()
    {
        this.lightType += 1;

        if ((int)this.lightType > 2)
        {
            this.lightType = 0;
        }
    }

    public override string ToString()
    {
        return $"{this.lightType}";
    }
}
