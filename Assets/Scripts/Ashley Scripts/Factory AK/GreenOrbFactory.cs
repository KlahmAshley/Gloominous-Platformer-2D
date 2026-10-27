using UnityEngine;

public class GreenOrbFactory : OrbFactory
{
    public override IOrb DestoryandChangeOrb(Sprite colourSprite)
    {
        return new GreenOrb();
    }

}
