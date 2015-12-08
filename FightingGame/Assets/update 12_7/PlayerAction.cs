using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;


public class PlayerAction : MonoBehaviour {
	private Animator anim_action;
	//private Rigidbody2D rb;
	//private PlatformerCharacter2D pc;
	//private Vector2 point;
	private BoxCollider2D bc;

	public EnemyHealth enemyHealth;
	public PlayerHealth playerHealth;
	public GameObject player1;
	public GameObject player2;

	//private bool isHit = false;

	BoxCollider2D punchBox;
	//float radius = 1.0f;




    // Use this for initialization
    void Start () 
	{
		//pc = GetComponent<PlatformerCharacter2D>();
		//rb = GetComponent<Rigidbody2D>();
		bc = GetComponent<BoxCollider2D>();
		anim_action = GetComponent<Animator>();

	}

    void Awake ()
    {
		player1 = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Enemy");
		punchBox = bc;
        enemyHealth = player2.GetComponent<EnemyHealth>();
		//punchBox = GameObject.FindGameObjectWithTag("Punch");
    }

	void Update()
	{
		// IgnoreCollider
		//Physics2D.IgnoreCollision(player1.GetComponent<Collider2D>(), player2.GetComponent<Collider2D>()); // Remove bumping damage

		Punch();

		punchBox.gameObject.SetActive(false);
	}



	void Punch () //make a collision object with collision script attached
	{
        if (Input.GetKeyDown(KeyCode.P))
        {
			//isHit = true;

			//anim_action.SetBool("Punch", isHit);
            anim_action.SetTrigger("Punch");
			punchBox.gameObject.SetActive(true);

			         
			//isHit = false;
			punchBox.gameObject.SetActive(false);

        }

	}


}
