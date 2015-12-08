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



    // Use this for initialization
    void Start () 
	{
		// IgnoreCollider
		Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Enemy").GetComponent<Collider2D>()); // Remove bumping damage
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


		Punch();

		punchBox.gameObject.SetActive(false);
	}



	void Punch () //make a collision object with collision script attached
	{
        if (Input.GetKeyDown(KeyCode.P))
        {
			//anim_action.SetBool("Punch", isHit);
            anim_action.SetTrigger("Punch");
			punchBox.gameObject.SetActive(true);

			         
			punchBox.gameObject.SetActive(false);
        }

	}


}
