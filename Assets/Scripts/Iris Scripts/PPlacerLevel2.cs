using UnityEngine;

public class PPlacerLevel2 : MonoBehaviour
{
    [SerializeField] PowerupFactory powerupFactory;

    void Start()
    {
        powerupFactory.CreatePower(Powerups.Speed, new Vector2(-13.38f, -0.05f));
        powerupFactory.CreatePower(Powerups.Jump, new Vector2(-4.39f, -2.74f));
        powerupFactory.CreatePower(Powerups.Jump, new Vector2(12.36f, 3.21f));
        powerupFactory.CreatePower(Powerups.Big, new Vector2(15.05f, -7.67f));
    }
}
