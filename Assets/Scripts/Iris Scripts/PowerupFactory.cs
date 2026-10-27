using UnityEngine;

public class PowerupFactory : MonoBehaviour
{
    [SerializeField] GameObject powerSpeed;
    [SerializeField] GameObject powerJump;
    [SerializeField] GameObject powerBig;

    void Awake()
    {
        if (powerSpeed == null)
        {
            powerSpeed = Resources.Load("Prefabs/SpeedPower") as GameObject;
        }
        if (powerJump == null)
        {
            powerJump = Resources.Load("Prefabs/JumpPower") as GameObject;
        }
        if (powerBig == null)
        {
            powerBig = Resources.Load("Prefabs/BigPower") as GameObject;
        }
    }

    public GameObject CreateEnemy(Powerups type, Vector3 position)
    {
        GameObject power = null;
        switch (type)
        {
            case Powerups.Speed:
                power = powerSpeed;
                break;
            case Powerups.JumpHeight:
                power = powerJump;
                break;
            case Powerups.ExtraHit:
                power = powerBig;
                break;
        }
        return Instantiate(power, position, Quaternion.identity);
    }
}

public enum Powerups
{
    Speed,
    JumpHeight,
    ExtraHit
}