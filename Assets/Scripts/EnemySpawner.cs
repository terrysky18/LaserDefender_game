using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemy_prefab;
    public float width;
    public float height;

    private float x_min;
    private float x_max;

	// Use this for initialization
	void Start () {
        width = 10f;
        height = 5f;

        // private variables
        x_min = -2f;
        x_max = 2f;

        // spawn an enemy with the parent formation object
        foreach(Transform child in transform)
        {
            // create an enemy with Instantiate
            GameObject enemy = Instantiate(enemy_prefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
	}

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0f));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
