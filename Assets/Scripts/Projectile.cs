using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    // The script defines behaviour of projectiles
    private float damage = 100f;

    public float GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        // destroy the project when it hits
        Destroy(gameObject);
    }
}
