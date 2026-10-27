using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Unity;

public class RedOrb : MonoBehaviour, IOrb
{
    public SpriteRenderer PlayerSprite;
    public Sprite RedPlayer;

    public void Collect(SpriteRenderer PlayerSprite, Sprite RedPlayer)
    {
        PlayerSprite.sprite = RedPlayer;
    }
}
