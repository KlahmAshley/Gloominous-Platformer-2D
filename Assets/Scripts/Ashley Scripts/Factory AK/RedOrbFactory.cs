using UnityEngine;

public class RedOrbFactory : OrbFactory
{
    public override IOrb ChangeOrb(Color ColourChange)
    {
        return new RedOrb();
    }

}
