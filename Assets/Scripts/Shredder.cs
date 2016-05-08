using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {
    // Destroy game objects that collide with the Shredder object

    void OnTriggerEnter2D (Collider2D collider_box)
    {
        Destroy(collider_box.gameObject);
    }
}
