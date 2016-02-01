using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

    void OnTriggerEnter2D (Collider2D collider_box)
    {
        Destroy(collider_box.gameObject);
    }
}
