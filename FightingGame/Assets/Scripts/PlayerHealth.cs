using UnityEngine;
using System.Collections;



public class PlayerHealth : MonoBehaviour 
{

	public int maxHealth = 100;
	public int p1Health = 100;

	public float healthBarLength;

	// Use this for initialization
	void Start () {
		healthBarLength = Screen.width / 2;
	}
	
	// Update is called once per frame
	void Update () 
	{
		AdjustPlayerHealth(0);
	}

	void OnGUI()
	{
		GUI.Box(new Rect(10 , 10, healthBarLength, 20), p1Health + "/" + maxHealth);
	}

	public void AdjustPlayerHealth (int adj)
	{
		if (p1Health < 1)
		{
			p1Health = 0;
		}

		if (p1Health > maxHealth)
		{
			p1Health = maxHealth;
		}

		if (maxHealth < 1)
		{
			maxHealth = 1;
		}
		p1Health += adj;
		healthBarLength = (Screen.width / 2) * (p1Health / (float)maxHealth);
	}
}
