using UnityEngine;
using System.Collections;






public class PlayerMovement : MonoBehaviour 
{


	private Vector3 move_direction;
	public float speed = 10.0f;
    //private Rigidbody2D rb;
    public SpriteRenderer sr;


	void Start()
	{
        //rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        sr.receiveShadows = true;
        Sprite s = Resources.Load<Sprite>("that guy.png");
        sr.sprite = s;
	}



	void Move () 
	{
		if(Input.GetAxis("Horizontal") !=0)	
		{
			move_direction = new Vector2(Input.GetAxis("Horizontal"), 0);
			move_direction *= speed * Time.deltaTime;
		    transform.position += move_direction;
	    }
	}
	
	// Update is called once per frame
	void Update () 

    {
		Move ();
	}


	void Jump ()
	{
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{

		}
	}
}
