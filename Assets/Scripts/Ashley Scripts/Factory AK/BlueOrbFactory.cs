using UnityEngine;

public class BlueOrbFactory : OrbFactory
{
    public override IOrb ChangeOrb(Sprite colourSprite)
    {
        return new BlueOrb();
    }

}
