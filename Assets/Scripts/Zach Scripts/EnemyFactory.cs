using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject CreateEnemy(EnemyType type, Vector3 position)
    {
        GameObject enemy = null;
        switch (type)
        {
            case EnemyType.Zach:
                enemy = Instantiate(Resources.Load("Prefabs/ZachEnemy"), position, Quaternion.identity) as GameObject;
                break;
            case EnemyType.Ashley:
                enemy = Instantiate(Resources.Load("Prefabs/AshleyEnemy"), position, Quaternion.identity) as GameObject;
                break;
            case EnemyType.Iris:
                enemy = Instantiate(Resources.Load("Prefabs/IrisEnemy"), position, Quaternion.identity) as GameObject;
                break;
        }
        return enemy;
    }
}

public enum EnemyType
{
    Zach,
    Ashley,
    Iris
}