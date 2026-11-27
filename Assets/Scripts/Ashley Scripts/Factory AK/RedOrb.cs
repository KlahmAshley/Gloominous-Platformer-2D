using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Unity;

public class RedOrb : MonoBehaviour, IOrb
{
    public SpriteRenderer PlayerSprite;
    private Color red = Color.red;

    public void Collect(SpriteRenderer PlayerSprite, Color OrbColor)
    {
        PlayerSprite.color = OrbColor;
    }
}
