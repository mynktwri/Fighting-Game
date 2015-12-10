using UnityEngine;
using System.Collections;

public class Player2Movement : MonoBehaviour
{

    private Vector3 move_direction;
    public float speed = 10.0f;
    //private Rigidbody2D rb;
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    void Move()
    {
        if (Input.GetAxis("Horizontal2") != 0)
        {
            move_direction = new Vector2(Input.GetAxis("Horizontal2"), 0);
            move_direction *= speed * Time.deltaTime;
            transform.position += move_direction;
        }
    }

    // Update is called once per frame
    void Update()

    {
        Move();
    }


    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

        }
    }
}
