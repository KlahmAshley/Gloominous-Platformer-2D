using UnityEngine;

public abstract class OrbFactory
{
    //Factory Method changing colour (abstract so other orb factories can override it)
    public abstract IOrb ChangeOrb(Sprite colourSprite);
}

