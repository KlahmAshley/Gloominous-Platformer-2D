using UnityEngine;

public class OrbCollisionTester : MonoBehaviour
{
    [SerializeField] private OrbFactory orbFactory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RedOrb"))
        {
            collision.gameObject.SetActive(false);
            IOrb orb = orbFactory.GetOrb(RedOrb);
        }

    }
}