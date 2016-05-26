using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
    public GameObject eProjectile_prefab;

    private float health = 150f;
    private Rigidbody2D eRb2D;
    private float fireFrequency = 0.5f;

    void Update()
    {
        float fire_probability = Time.deltaTime * fireFrequency;
        if (Random.value < fire_probability)
        {
            // enemy fires at random time
            Shoot();
        }
    }

	// Detect player laser beam hit
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

    void Shoot()
    {
        Vector3 start_pos = transform.position + new Vector3(0, -0.3f, 0);
        GameObject enemy_laser = Instantiate(eProjectile_prefab, start_pos, Quaternion.identity) as GameObject;
        // attach a Rigidbody2D to the laser beam
        eRb2D = enemy_laser.GetComponent<Rigidbody2D>();
        eRb2D.velocity = new Vector2(0, -10f);
    }
}
