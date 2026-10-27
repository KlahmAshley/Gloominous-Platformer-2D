using UnityEngine;

public class BlueOrb : MonoBehaviour, IOrb
{
    public SpriteRenderer PlayerSprite;
    public Sprite BluePlayer;

    public void Collect(SpriteRenderer PlayerSprite, Sprite BluePlayer)
    {
        PlayerSprite.sprite = BluePlayer;
    }
}
