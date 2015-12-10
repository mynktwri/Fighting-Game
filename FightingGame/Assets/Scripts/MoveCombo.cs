using UnityEngine;
using System.Collections;

public class MoveCombo : MonoBehaviour {

	private MoveCheck fireBlast = new MoveCheck(new string[] {"down", "right","punch"});
	private MoveCheck doubleKick = new MoveCheck(new string[] {"down", "forward", "kick"});
	private MoveCheck ultBlast = new MoveCheck(new string[] {"down", "forward", "down", "forward", "punch", "heavy punch"});
	
	void Update () {
		if (fireBlast.Check())
		{
			// do fire blast
			Debug.Log("fire blast!"); 
		}		

		if (doubleKick.Check())
		{
			Debug.Log("double kick!"); 
		}		

		if (ultBlast.Check())
		{
			Debug.Log("ULTIMATE!");

			// stop time

			// animation
		}		

	}
}


