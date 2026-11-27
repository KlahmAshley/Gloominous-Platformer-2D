using UnityEngine;

public class GreenOrbFactory : OrbFactory
{
    public override IOrb ChangeOrb(Color ColourChange)
    {
        return new GreenOrb();
    }

}
