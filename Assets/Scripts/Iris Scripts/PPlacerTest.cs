using UnityEngine;

public class PPlacerTest : MonoBehaviour
{
    [SerializeField] PowerupFactory powerupFactory;

    void Start()
    {
        powerupFactory.CreatePower(Powerups.Speed, new Vector2(-3.58f, 0.5f));
        powerupFactory.CreatePower(Powerups.Jump, new Vector2(2.12f, 1.48f));
        powerupFactory.CreatePower(Powerups.Big, new Vector2(4.08f, -1.79f));
    }
}
