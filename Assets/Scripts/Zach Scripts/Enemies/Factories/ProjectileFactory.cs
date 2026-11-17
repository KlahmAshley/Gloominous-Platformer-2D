using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileFactory", menuName = "Scriptable Objects/ProjectileFactory")]
public class ProjectileFactory : ScriptableObject
{
    [SerializeField] private Projectile projectilePrefab;

    public GameObject Create()
    {
        Projectile instance = Instantiate(projectilePrefab);
        return instance.gameObject;
    }
}
