using UnityEngine;

public class GreenOrb : MonoBehaviour, IOrb
{
    public SpriteRenderer PlayerSprite;
    public Sprite GreenPlayer;

    public void Collect(SpriteRenderer PlayerSprite, Sprite GreenPlayer)
    {
        PlayerSprite.sprite = GreenPlayer;
    }
}
