using UnityEngine;
using System.Collections;



public class EnemyHealth : MonoBehaviour 
{
	
	public int maxHealth = 100;
	public int p2Health = 100;
	
	public float healthBarLength;
	
	// Use this for initialization
	void Start () {
		healthBarLength = Screen.width / 2;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Adjustp2Health(0);
	}
	
	void OnGUI()
	{
		GUI.Box(new Rect(500 , 10, healthBarLength, 20), p2Health + "/" + maxHealth);
	}
	
	public void Adjustp2Health (int adj)
	{
		if (p2Health < 1)
			p2Health = 0;
		
		if (p2Health > maxHealth)
			p2Health = maxHealth;
		
		if (maxHealth < 1)
			maxHealth = 1;

		p2Health += adj;
		healthBarLength = (Screen.width / 2) * (p2Health / (float)maxHealth);
	}
}
