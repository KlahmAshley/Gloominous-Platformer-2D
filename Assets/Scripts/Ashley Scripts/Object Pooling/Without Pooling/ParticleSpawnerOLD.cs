using UnityEngine;

public class ParticleSpawnerOLD : MonoBehaviour
{   public ParticleSystem spawnParticle(ParticleSystem ps, Transform player, ParticleSystem currentParticle)
    {
        ParticleSystem Ps = Instantiate(ps, player.position, player.rotation, transform.parent);
        Destroy(currentParticle.gameObject);
        currentParticle = Ps;
        return currentParticle;
    }
}
