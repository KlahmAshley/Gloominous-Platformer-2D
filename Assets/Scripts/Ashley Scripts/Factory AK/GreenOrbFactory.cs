using UnityEngine;

public class GreenOrbFactory : OrbFactory
{
    public override IOrb ChangeOrb(Sprite colourSprite)
    {
        return new GreenOrb();
    }

}
