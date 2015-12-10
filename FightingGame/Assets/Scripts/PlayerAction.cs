using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;


public class PlayerAction : MonoBehaviour {
	private Animator anim_action;


	public EnemyHealth enemyHealth;
	public PlayerHealth playerHealth;
	public GameObject player1;
	public GameObject player2;
	private GameObject punchBox;

	private float punchTimer = .1f;



    // Use this for initialization
    void Start () 
	{
		// IgnoreCollider
		//Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Enemy").GetComponent<Collider2D>()); // Remove bumping damage
		anim_action = GetComponent<Animator>();

	}

    void Awake ()
    {
		player1 = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Enemy");
		punchBox = GameObject.FindGameObjectWithTag("Punch");
        enemyHealth = player2.GetComponent<EnemyHealth>();
    }

	void Update()
	{
		punchTimer -= Time.deltaTime;
		if(punchTimer <0)  
			punchBox.gameObject.SetActive(false);
		Punch();

		//punchBox.gameObject.SetActive(false);
	}



	void Punch () //overlap circle
	{
        if (Input.GetKeyDown(KeyCode.P))
        {

            //Physics2D.OverlapCircle();



			punchTimer = .5f;
			punchBox.gameObject.SetActive(true);
			//anim_action.SetBool("Punch", isHit);
            anim_action.SetTrigger("Punch");




        }



	}


}
