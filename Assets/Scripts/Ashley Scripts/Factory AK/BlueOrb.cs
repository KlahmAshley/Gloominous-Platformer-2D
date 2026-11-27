using UnityEngine;

public class BlueOrb : MonoBehaviour, IOrb
{
    public SpriteRenderer PlayerSprite;
    private Color blue = Color.blue;

    public void Collect(SpriteRenderer PlayerSprite, Color OrbColor)
    {
        PlayerSprite.color = OrbColor;
    }
}
