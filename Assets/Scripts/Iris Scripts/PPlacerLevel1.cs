using UnityEngine;

public class PPlacerTest : MonoBehaviour
{
    [SerializeField] PowerupFactory powerupFactory;

    void Start()
    {
        powerupFactory.CreatePower(Powerups.Speed, new Vector2(-1.85f, -6.78f));
        powerupFactory.CreatePower(Powerups.Speed, new Vector2(-12.96f, 6.15f));
        powerupFactory.CreatePower(Powerups.Jump, new Vector2(17.02f, -4.00f));
        powerupFactory.CreatePower(Powerups.Big, new Vector2(-12.03f, -4.00f));
        powerupFactory.CreatePower(Powerups.Big, new Vector2(12.12f, 6.99f));
        powerupFactory.CreatePower(Powerups.Big, new Vector2(2.73f, 6.29f));
    }
}
