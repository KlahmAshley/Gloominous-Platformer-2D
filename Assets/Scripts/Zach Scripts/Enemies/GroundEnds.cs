using UnityEngine;

public class GroundEnds : MonoBehaviour
{
    public AshleyEnemy enemy;
    private void Awake()
    {
        enemy = GetComponentInParent<AshleyEnemy>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            enemy.moveDirection *= -1;
        }
    }
}
