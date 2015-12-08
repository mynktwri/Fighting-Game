using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {

	//private GameObject player1;
	private GameObject player2;
	//private GameObject punchBox;
	//private BoxCollider2D bc;

	public EnemyHealth enemyHealth;
	public PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
		//bc = GetComponent<BoxCollider2D>();
	}

	void Awake () {
	
		//player1 = GameObject.FindGameObjectWithTag("Player");
		player2 = GameObject.FindGameObjectWithTag("Enemy");
		enemyHealth = player2.GetComponent<EnemyHealth>();
		//punchBox = GameObject.FindGameObjectWithTag("Punch");
	}
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") {
			enemyHealth.p2Health = enemyHealth.p2Health - 20;
			Debug.Log("DAMAGE");
		}
		
	} 

}
