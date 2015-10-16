using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour {
	private Animator anim_action;


	// Use this for initialization
	void Start () 
	{
		anim_action = GetComponent<Animator>();
	}


	void Punch () 
	{
		if(Input.GetKeyDown(KeyCode.P))
		{

		}
	}
}
