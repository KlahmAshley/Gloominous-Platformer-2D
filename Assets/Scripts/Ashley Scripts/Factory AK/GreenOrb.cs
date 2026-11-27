using UnityEngine;

public class GreenOrb : MonoBehaviour, IOrb
{
    public SpriteRenderer PlayerSprite;
    private Color green = Color.green;

    public void Collect(SpriteRenderer PlayerSprite, Color OrbColor)
    {
        PlayerSprite.color = OrbColor;
    }
}
