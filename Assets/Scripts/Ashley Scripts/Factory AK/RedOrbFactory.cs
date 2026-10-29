using UnityEngine;

public class RedOrbFactory : OrbFactory
{
   public override IOrb ChangeOrb(Sprite colourSprite)
    {
        return new RedOrb();
    }

}
