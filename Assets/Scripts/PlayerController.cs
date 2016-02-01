using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public GameObject projectile_prefab;

    private float ship_speed;
    private Rigidbody2D rb2D;
    //direction variables
    private float hori_direct;
    private float vert_direct;

    //ship position limits
    private float x_min;
    private float x_max;
    private float y_min;
    private float y_max;

	// Use this for initialization
	void Start () {
        ship_speed = 5.8f;
        hori_direct = 0f;
        vert_direct = 0f;

        //use camera view to clamp the ship position
        // distance between object and camera
        float distance = transform.position.z - Camera.main.transform.position.z;

        Vector3 left_down_limit = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 right_limit = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        Vector3 up_limit = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, distance));
        // define the limits of Mathf.Clamp
        float clamp_margin = 1f;
        x_min = left_down_limit.x + clamp_margin;
        x_max = right_limit.x - clamp_margin;
        y_min = left_down_limit.y + clamp_margin;
        y_max = up_limit.y - clamp_margin;
    }
	
	// Update is called once per frame
	void Update () {
        CheckKeyDown();
        PlayerMove();

        // player shoots
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("PlayerShoot", 0f, 0.2f);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("PlayerShoot");
        }
    }

    void CheckKeyDown ()
    {
        // check horizontal direction
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            hori_direct = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            hori_direct = 1f;
        }
        else //stop movement when key up
        {
            hori_direct = 0f;
        }

        // check vertical direction
        if (Input.GetKey(KeyCode.UpArrow))
        {
            vert_direct = 1f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            vert_direct = -1f;
        }
        else //stop movement when key up
        {
            vert_direct = 0f;
        }
    }

    void PlayerMove()
    {
        // make ship velocity frame rate independent, use Time.deltaTime
        float hori_delta = hori_direct * ship_speed * Time.deltaTime;
        float vert_delta = vert_direct * ship_speed * Time.deltaTime;

        float hori_pos = Mathf.Clamp(transform.position.x + hori_delta, x_min, x_max);
        float vert_pos = Mathf.Clamp(transform.position.y + vert_delta, y_min, y_max);
        Vector3 ship_Pos = new Vector3(hori_pos, vert_pos, 0);
        transform.position = ship_Pos;
    }

    void PlayerShoot()
    {
        GameObject player_laser = Instantiate(projectile_prefab, transform.position, Quaternion.identity) as GameObject;
        // attach a Rigidbody2D to the laser beam
        rb2D = player_laser.GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(0, 16f);
    }
}
