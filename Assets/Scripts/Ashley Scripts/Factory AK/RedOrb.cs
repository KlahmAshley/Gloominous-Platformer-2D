using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Unity;

public class RedOrb : Orb
{
    public SpriteRenderer PlayerSprite;
    public Sprite RedPlayer;

    public override void Collect()
    {
        PlayerSprite.sprite = RedPlayer;
    }
}
