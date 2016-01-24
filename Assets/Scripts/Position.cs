using UnityEngine;
using System.Collections;

public class Position : MonoBehaviour {
    // an on draw Gizmo script to show the position in editor
    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1);
    }
}
