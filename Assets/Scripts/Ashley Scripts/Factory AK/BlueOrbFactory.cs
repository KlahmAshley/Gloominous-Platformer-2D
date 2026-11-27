using UnityEngine;

public class BlueOrbFactory : OrbFactory
{
    public override IOrb ChangeOrb(Color ColourChange)
    {
        return new BlueOrb();
    }

}
