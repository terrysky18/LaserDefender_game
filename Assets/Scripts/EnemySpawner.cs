using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemy_prefab;
    public float width;
    public float height;

    // private variables
    private float x_min;
    private float x_max;
    private float y_min;
    private float y_max;
    private bool x_at_limit;
    private bool y_at_limit;
    private float x_direct;
    private float y_direct;
    private bool x_moving;
    private bool y_moving;

	// Use this for initialization
	void Start () {
        // movement limits
        float distant_2_camera = transform.position.z - Camera.main.transform.position.z;
        Vector3 left_bound = Camera.main.ViewportToWorldPoint(new Vector3(0.15f, 0f, distant_2_camera));
        Vector3 right_bound = Camera.main.ViewportToWorldPoint(new Vector3(0.85f, 0f, distant_2_camera));
        Vector3 upper_bound = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0.8f, distant_2_camera));
        Vector3 lower_bound = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0.2f, distant_2_camera));

        x_min = left_bound.x;
        x_max = right_bound.x;
        y_min = lower_bound.y;
        y_max = upper_bound.y;
        x_at_limit = true;
        y_at_limit = false;

        // movement direction, cannot be 0f
        x_direct = -1f;
        y_direct = -1f;

        // movement boolean
        x_moving = false;
        y_moving = false;

        // spawn an enemy with the parent formation object
        foreach (Transform child in transform)
        {
            // create an enemy with Instantiate
            GameObject enemy = Instantiate(enemy_prefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
	}

    public void OnDrawGizmos ()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0f));
    }
	
	// Update is called once per frame
	void Update () {
        BoxMovement();
	}

    // Enemy formation moves in a box pattern
    void BoxMovement ()
    {
        float step = 6f;
        Vector3 formation_pos = new Vector3(0f, 0f, 0f);
        // move vertically
        if (x_at_limit || y_moving)
        {
            y_moving = true; // continue moving y until at limit
            Debug.Log("moving y " + y_direct);
            float y_pos = transform.position.y;

            y_pos += step * y_direct * Time.deltaTime;
            formation_pos = new Vector3(transform.position.x, y_pos, 0f);
            
            if (y_pos > y_max || y_pos < y_min)
            {
                y_at_limit = true;
                y_moving = false;
                x_at_limit = false;
                Debug.Log("stop moving y");
                y_direct *= -1f;    // reverse direction
            }
        }
        // move horizontally
        if (y_at_limit || x_moving)
        {
            x_moving = true;    // continue moving x until at limit
            Debug.Log("moving x " + x_direct);
            float x_pos = transform.position.x;

            x_pos += step * x_direct * Time.deltaTime;
            formation_pos = new Vector3(x_pos, transform.position.y, 0f);

            if (x_pos > x_max || x_pos < x_min)
            {
                x_at_limit = true;
                x_moving = false;
                y_at_limit = false;
                Debug.Log("stop moving x");
                x_direct *= -1f;
            }
        }

        transform.position = formation_pos;
        Debug.Log(transform.position);
    }
}
