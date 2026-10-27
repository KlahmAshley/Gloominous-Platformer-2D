using UnityEngine;

public class RedOrbFactory : OrbFactory
{
   public override IOrb DestoryandChangeOrb(Sprite colourSprite)
    {
        return new RedOrb();
    }

}
