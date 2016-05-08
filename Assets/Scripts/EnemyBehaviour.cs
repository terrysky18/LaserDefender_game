using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
    private float health = 150f;

	// Detect laser beam hit
	void OnTriggerEnter2D(Collider2D collider)
    {
        // extract a Projectile object
        Projectile laser_beam = collider.gameObject.GetComponent<Projectile>();
        if (laser_beam)
        {
            // laser_beam projectile exists
            health -= laser_beam.GetDamage();
            laser_beam.Hit();
            if (health <= 0)
            {
                // enemy health depleted
                Destroy(gameObject);
            }
        }
    }
}
