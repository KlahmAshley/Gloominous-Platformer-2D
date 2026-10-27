using UnityEngine;

public class BlueOrbFactory : OrbFactory
{
    public override IOrb DestoryandChangeOrb(Sprite colourSprite)
    {
        return new BlueOrb();
    }

}
