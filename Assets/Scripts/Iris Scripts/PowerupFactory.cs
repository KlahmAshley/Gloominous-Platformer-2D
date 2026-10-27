using UnityEngine;

public class PowerupFactory : MonoBehaviour
{
    [SerializeField] GameObject powerSpeed;
    [SerializeField] GameObject powerJump;
    [SerializeField] GameObject powerBig;

    void Start()
    {
        if (powerSpeed == null)
        {
            powerSpeed = Resources.Load("Prefabs/Powerup_Speed") as GameObject;
        }
        if (powerJump == null)
        {
            powerJump = Resources.Load("Prefabs/Powerup_Jump") as GameObject;
        }
        if (powerBig == null)
        {
            powerBig = Resources.Load("Prefabs/Powerup_Big") as GameObject;
        }
    }

    public GameObject CreatePower(Powerups type, Vector3 position)
    {
        GameObject power = null;
        switch (type)
        {
            case Powerups.Speed:
                power = powerSpeed;
                break;
            case Powerups.Jump:
                power = powerJump;
                break;
            case Powerups.Big:
                power = powerBig;
                break;
        }
        return Instantiate(power, position, Quaternion.identity);
    }
}

public enum Powerups
{
    Speed,
    Jump,
    Big
}